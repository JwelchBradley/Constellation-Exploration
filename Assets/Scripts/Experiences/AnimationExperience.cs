using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using static UnityEngine.ParticleSystem;

public class AnimationExperience : Experience
{
    string name;
    VideoPlayer vp;
    MeshRenderer mr;
    [SerializeField]
    Material onMaterial;
    [SerializeField]
    Vector3 spawnPos;
    protected override void Awake()
    {
        transform.position = spawnPos;
        base.Awake();

        vp = GetComponentInChildren<VideoPlayer>();
        mr = GetComponentInChildren<MeshRenderer>();

        StartCoroutine(StartVideo());

        RemoveLines();

        FindObjectOfType<ConstellationInteraction>().Invoke("EndExperience", ExperienceTimer);
    }

    private IEnumerator StartVideo()
    {
        while (!vp.isPlaying)
        {
            yield return new WaitForFixedUpdate();
        }

        mr.material = onMaterial;
    }

    private void RemoveLines()
    {
        string name = gameObject.name;
        string a = "(Clone)";
        name = name.Replace(a, "");
        Debug.Log(name);
        foreach (LineRenderer lr in StarCreator.Constellations[name])
        {
            lr.enabled = false;
            //lr.material.color = Color.clear;
        }

        this.name = name;
        ChangeStarColor(Color.clear);
    }

    private void ChangeStarColor(Color col)
    {
        if (StarCreator.ConstellationParticleSystems.TryGetValue(name, out ParticleSystem ps))
        {
            Particle[] particles = new Particle[ps.main.maxParticles];
            ps.GetParticles(particles);

            for (int i = 0; i < particles.Length; i++)
            {
                //particles[i].startSize = particles[i].size * hoverStarSizeMod;
                particles[i].color = col;
            }

            ps.SetParticles(particles);
        }
    }

    private void OnDestroy()
    {
        foreach (LineRenderer lr in StarCreator.Constellations[name])
        {
            if(lr != null)
            lr.enabled = true;
        }
        ChangeStarColor(Color.white);
    }
}
