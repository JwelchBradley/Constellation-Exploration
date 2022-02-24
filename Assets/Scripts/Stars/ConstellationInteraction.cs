using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ConstellationInteraction : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField]
    private LayerMask constellationLayer;

    private static string currentSelected = "";

    private string thisSelected = "";

    [SerializeField]
    [ColorUsageAttribute(true, true)]
    private Color hoverColor;

    [SerializeField]
    [ColorUsageAttribute(true, true)]
    private Color defaultColor;

    [SerializeField]
    [ColorUsageAttribute(true, true)]
    private Color disabledColor;

    [SerializeField]
    [ColorUsageAttribute(true, true)]
    private Color alreadyClickedColor;

    [SerializeField]
    private float hoverStarSizeMod = 3.0f;

    public Color DefaultColor
    {
        get => defaultColor;
    }

    [Tooltip("The sound made when the user hovers over the constellation")]
    [SerializeField] private AudioClip hoverSound;

    [Tooltip("The time between potential hover sounds")]
    [SerializeField] private float hoverBufferTime = 0.1f;

    private bool canHoverSound = true;

    [Tooltip("The sound made when the user clicks on the constellation")]
    [SerializeField] private AudioClip clickSound;

    private Dictionary<string, bool> alreadySelectedExperiences = new Dictionary<string, bool>();

    private AudioSource aud;

    private GameObject activeExperience;


    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(activeExperience == null)
        {
            CheckForHoverChange();
        }
    }

    private void CheckForHoverChange()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, constellationLayer))
        {
            string name = hit.transform.gameObject.name;

            if (!alreadySelectedExperiences.ContainsKey(name))
            {
                if (!currentSelected.Equals(name))
                {
                    if (!currentSelected.Equals(""))
                    {
                        ChangeConstellationColor(defaultColor);
                        ChangeStarSize(1 / hoverStarSizeMod);
                    }

                    currentSelected = name;

                    ChangeStarSize(hoverStarSizeMod);
                    ChangeConstellationColor(hoverColor);

                    PlayHoverSound();
                }
            }
            else
            {
                ChangeConstellationColor(defaultColor);
                ChangeStarSize(1/hoverStarSizeMod);
                currentSelected = "";
            }
        }
        else if (!currentSelected.Equals(""))
        {
            ChangeConstellationColor(defaultColor);
            ChangeStarSize(1/hoverStarSizeMod);
            currentSelected = "";
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && currentSelected != "")
        Interact();
    }

    private void ChangeStarSize(float hoverStarSizeMod)
    {
        if(alreadySelectedExperiences.TryGetValue(currentSelected, out bool hasBeenSelected))
        {
            return;
        }

        if(StarCreator.ConstellationParticleSystems.TryGetValue(currentSelected, out ParticleSystem ps))
        {
            Particle[] particles = new Particle[ps.main.maxParticles];
            ps.GetParticles(particles);

            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].startSize = particles[i].size * hoverStarSizeMod;
            }

            ps.SetParticles(particles);
        }
    }

    public void Interact()
    {
        if(activeExperience == null && !alreadySelectedExperiences.ContainsKey(currentSelected))
        {
            activeExperience = Instantiate(Resources.Load("Prefabs/Stars/Constellation Experiences/" + currentSelected, typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
            alreadySelectedExperiences.Add(currentSelected, true);

            if(activeExperience != null)
            StartCoroutine(ConstellationExperienceTimer(activeExperience.GetComponent<Experience>().ExperienceTimer));
            aud.PlayOneShot(clickSound);
            ChangeOtherLines(false);
        }
    }

    private IEnumerator ConstellationExperienceTimer(float time)
    {
        yield return new WaitForSeconds(time);
        activeExperience = null;

        ChangeConstellationColor(alreadyClickedColor);

        currentSelected = "";
        ChangeOtherLines(true);
    }

    private void ChangeOtherLines(bool shouldBeOn)
    {
        foreach(string name in StarCreator.ConstellationNames)
        {
            if(name != currentSelected && ((!shouldBeOn && !alreadySelectedExperiences.ContainsKey(name) || shouldBeOn)))
            foreach (LineRenderer lr in StarCreator.Constellations[name])
            {
                lr.enabled = shouldBeOn;
            }
        }
    }

    private void ChangeConstellationColor(Color newColor)
    {
        if(currentSelected == "")
        {
            return;
        }

        foreach(LineRenderer lr in StarCreator.Constellations[currentSelected])
        {
            lr.material.color = newColor;
        }
    }

    private void PlayHoverSound()
    {
        if (canHoverSound)
        {
            aud.PlayOneShot(hoverSound);
            canHoverSound = false;
            StartCoroutine(HoverSoundWait());
        }
    }

    private IEnumerator HoverSoundWait()
    {
        yield return new WaitForSeconds(hoverBufferTime);
        canHoverSound = true;
    }
}
