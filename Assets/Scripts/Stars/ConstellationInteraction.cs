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

    private static string rightSelected = "";
    private static string leftSelected = "";
    [SerializeField]
    private bool isRight = true;

    #region Colors
    [SerializeField]
    [ColorUsageAttribute(true, true)]
    private Color hoverColor;

    [SerializeField]
    [ColorUsageAttribute(true, true)]
    private Color defaultColor;

    public Color DefaultColor
    {
        get => defaultColor;
    }

    [SerializeField]
    [ColorUsageAttribute(true, true)]
    private Color alreadyClickedColor;
    #endregion

    #region Hover
    [SerializeField]
    private float hoverStarSizeMod = 3.0f;

    [Tooltip("The sound made when the user hovers over the constellation")]
    [SerializeField] private AudioClip hoverSound;

    [Tooltip("The time between potential hover sounds")]
    [SerializeField] private float hoverBufferTime = 0.1f;

    private static bool canHoverSound = true;

    [Tooltip("The sound made when the user clicks on the constellation")]
    [SerializeField] private AudioClip clickSound;
    #endregion

    private static Dictionary<string, bool> alreadySelectedExperiences = new Dictionary<string, bool>();

    [SerializeField]
    private List<GameObject> notFinished = new List<GameObject>();
    private static List<string> NotFinished = new List<string>();

    private AudioSource aud;

    public static GameObject activeExperience;

    private void Awake()
    {
        if (isRight)
        {
            Invoke("DisableLate", 0.05f);
        }

        aud = GetComponent<AudioSource>();
    }

    private void DisableLate()
    {
        foreach (GameObject not in notFinished)
        {
            NotFinished.Add(not.name);
            ChangeConstellationColor(alreadyClickedColor, not.name);
        }
    }

    #region Hover
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

            if (NotFinished.Contains(name)) return;

            if (name != "" && !alreadySelectedExperiences.ContainsKey(name))
            {
                if (isRight)
                {
                    if(name != rightSelected)
                    {
                        if (leftSelected != "" || rightSelected != "")
                        {
                            ResetCurrent();
                        }

                        rightSelected = name;
                        currentSelected = rightSelected;

                        SetNewHover();
                    }
                }
                else
                {
                    if (name != leftSelected)
                    {
                        if (leftSelected != "" || rightSelected != "")
                        {
                            ResetCurrent();
                        }

                        leftSelected = name;
                        currentSelected = leftSelected;

                        SetNewHover();
                    }
                }
            }
            else if(currentSelected != "")
            {
                if (isRight)
                {
                    rightSelected = "";
                }
                else
                {
                    leftSelected = "";
                }

                ResetCurrent();
                if (rightSelected == "" && leftSelected == "")
                {
                    currentSelected = "";
                }
                else if (isRight)
                {
                    currentSelected = leftSelected;

                    ChangeStarSize(hoverStarSizeMod);
                    ChangeConstellationColor(hoverColor);
                }
                else
                {
                    currentSelected = rightSelected;

                    ChangeStarSize(hoverStarSizeMod);
                    ChangeConstellationColor(hoverColor);
                }
            }
        }
        else if (!currentSelected.Equals(""))
        {
            if (isRight)
            {
                rightSelected = "";
            }
            else
            {
                leftSelected = "";
            }

            ResetCurrent();
            if (rightSelected == "" && leftSelected == "")
            {
                currentSelected = "";
            }
            else if (isRight)
            {
                currentSelected = leftSelected;

                ChangeStarSize(hoverStarSizeMod);
                ChangeConstellationColor(hoverColor);
            }
            else
            {
                currentSelected = rightSelected;

                ChangeStarSize(hoverStarSizeMod);
                ChangeConstellationColor(hoverColor);
            }
        }
    }

    private void SetNewHover()
    {
        ChangeStarSize(hoverStarSizeMod);
        ChangeConstellationColor(hoverColor);

        PlayHoverSound();
    }

    private void ResetCurrent()
    {
        ChangeConstellationColor(defaultColor);
        ChangeStarSize(1 / hoverStarSizeMod);
    }

    #region Sound
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
    #endregion
    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && currentSelected != "")
        Interact(true);
    }

    private void ChangeStarSize(float hoverStarSizeMod)
    {
        if(alreadySelectedExperiences.TryGetValue(currentSelected, out bool hasBeenSelected))
        {
            return;
        }

        ChangeStarSizeOverrid(hoverStarSizeMod, currentSelected);
    }

    private void ChangeStarSizeOverrid(float hoverStarSizeMod, string name)
    {
        if (StarCreator.ConstellationParticleSystems.TryGetValue(name, out ParticleSystem ps))
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

    public void Interact(bool isRight)
    {
        if (isRight && rightSelected == "") return;
        else if (!isRight && leftSelected == "") return;

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
        if(activeExperience.TryGetComponent(out ConnectTheDotsExperience ctde))
        {
            while (ctde.HasNotEnded())
            {
                yield return new WaitForFixedUpdate();
            }
        }

        EndExperience();
    }

    private void EndExperience()
    {
        Destroy(activeExperience);

        activeExperience = null;
        ChangeConstellationColor(alreadyClickedColor);
        ChangeStarSizeOverrid(1 / hoverStarSizeMod, currentSelected);

        currentSelected = "";
        rightSelected = "";
        leftSelected = "";
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

    private void ChangeConstellationColor(Color newColor, string name)
    {
        foreach (LineRenderer lr in StarCreator.Constellations[name])
        {
            lr.material.color = newColor;
        }
    }
}
