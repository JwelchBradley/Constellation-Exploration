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
    Vector3 enlargePos;

    Vector3 startingScale;

    Vector3 enlargeScale = Vector3.one*3f;

    protected override void Awake()
    {
        enlargePos = new Vector3(spawnPos.x, 500, spawnPos.z);
        startingScale = transform.localScale;
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

        StartCoroutine(MoveVideoDown());

        mr.material = onMaterial;
    }

    private IEnumerator MoveVideoDown()
    {
        while(transform.position != enlargePos)
        {
            MoveVideoHelper(enlargeScale, enlargePos);
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds((float)vp.length - 10);
        Debug.Log("make smaller");
        while (transform.position != spawnPos)
        {
            MoveVideoHelper(startingScale, spawnPos);
            yield return new WaitForFixedUpdate();
        }
    }

    private void MoveVideoHelper(Vector3 targetScale, Vector3 targetPos)
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, Time.fixedDeltaTime / 3);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.fixedDeltaTime * 200);
    }

    private void RemoveLines()
    {
        string name = gameObject.name;
        string a = "(Clone)";
        name = name.Replace(a, "");

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

    protected override void OnDestroy()
    {
        base.OnDestroy();

        foreach (LineRenderer lr in StarCreator.Constellations[name])
        {
            if(lr != null)
            lr.enabled = true;
        }
        ChangeStarColor(Color.white);
    }
}
