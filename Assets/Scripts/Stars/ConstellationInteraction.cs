using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ConstellationInteraction : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField]
    private ConstellationData constellationData;

    // Constellation selection strings
    private static string currentSelected = "";
    private static string rightSelected = "";
    private static string leftSelected = "";

    // Button Stuff
    private static bool hasStarted = false;
    private bool isOnButton = false;
    private static bool rightOnButton = false;
    private static bool leftOnButton = false;
    private DisableAfterShortTime disableButton;

    [SerializeField]
    private bool isRight = true;

    private static bool canHoverSound = true;

    private static Dictionary<string, bool> alreadySelectedExperiences = new Dictionary<string, bool>();

    private static List<string> NotFinished = new List<string>();

    private AudioSource aud;

    public static GameObject activeExperience;

    bool isGroup = false;
    private static List<string> currentGroupNames = new List<string>();

    private void Awake()
    {
        if (isRight)
        {
            Invoke("DisableLate", 0.05f);
        }

        aud = GetComponent<AudioSource>();
        foreach(GameObject displayName in displayNameList)
        {
            displayNames.Add(displayName.name, displayName);
            displayNameRenderers.Add(displayName.name, displayName.GetComponentInChildren<SpriteRenderer>());
        }
    }

    private void DisableLate()
    {
        foreach (GameObject not in constellationData.NotFinished)
        {
            NotFinished.Add(not.name);
            ChangeConstellationColor(constellationData.AlreadyClickedColor, not.name);
        }
    }

    #region Hover
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hasStarted)
        {
            CheckForButton();
        }
       else if(activeExperience == null)
        {
            CheckForHoverChange();
        }
    }

    #region Start button
    private void CheckForButton()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, constellationData.ButtonLayer))
        {
            if (disableButton == null)
                disableButton = hit.transform.root.gameObject.GetComponentInChildren<DisableAfterShortTime>();

            if (!isOnButton) { PlayHoverSound(); }

            SetButtonStatics(true);
            disableButton.Hover(true);
            isOnButton = true;
        }
        else
        {
            SetButtonStatics(false);

            if (disableButton != null && !rightOnButton && !leftOnButton)
            {
                disableButton.Hover(false);
                isOnButton = false;
            }
        }
    }

    private void SetButtonStatics(bool on)
    {
        if (isRight)
        {
            rightOnButton = on;
        }
        else
        {
            leftOnButton = on;
        }
    }

    public void ButtonClick()
    {
        if (isOnButton && !hasStarted)
        {
            aud.PlayOneShot(constellationData.ClickSound);

            disableButton.Fade();
            hasStarted = true;
        }
    }
    #endregion

    private void CheckForHoverChange()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, constellationData.ConstellationLayer))
        {
            string name = hit.transform.gameObject.name;

            if (NotFinished.Contains(name)) return;

            if (name != "" && !alreadySelectedExperiences.ContainsKey(name))
            {
                if (isRight)
                {
                    if(name != rightSelected && name != currentSelected)
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
                    if (name != leftSelected && name != currentSelected)
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

                    SetNewHover();
                }
                else
                {
                    currentSelected = rightSelected;

                    SetNewHover();
                }
            }
        }
        else if (!currentSelected.Equals(""))
        {
            string current = "";

            if (isRight)
            {
                current = rightSelected;
                rightSelected = "";
            }
            else
            {
                current = leftSelected;
                leftSelected = "";
            }

            if(current != "")
            {
                ResetCurrent();
                if (rightSelected == "" && leftSelected == "")
                {
                    currentSelected = "";
                }
                else if (isRight)
                {
                    currentSelected = leftSelected;

                    SetNewHover();
                }
                else
                {
                    currentSelected = rightSelected;

                    SetNewHover();
                }
            }
        }
    }

    private void SetNewHover()
    {
        ChangeDisplayName(currentSelected, true);
        ChangeStarSize(constellationData.HoverStarSizeMod);
        ChangeConstellationColor(constellationData.HoverColor);

        CheckForConstellationGroup(constellationData.GroupColor, constellationData.HoverGroupedStarSizeMod, true);

        PlayHoverSound();
    }

    private void ResetCurrent()
    {
        ChangeDisplayName(currentSelected, false);
        ChangeStarSize(1 / constellationData.HoverStarSizeMod);
        ChangeConstellationColor(constellationData.DefaultColor);

        isGroup = false;
        CheckForConstellationGroup(constellationData.DefaultColor, 1/(constellationData.HoverGroupedStarSizeMod), false);
    }

    private void CheckForConstellationGroup(Color newColor, float sizeMod, bool active)
    {
        foreach(ListWrapper group in constellationData.GroupedConstellations)
        {
            if (group.names.Contains(currentSelected))
            {
                isGroup = active;
                currentGroupNames = group.names;

                foreach (string s in group.names)
                {
                    if(s != currentSelected)
                    {
                        ChangeDisplayName(s, active);
                        ChangeDisplayNameColor(s, Color.white/2);
                        ChangeStarSizeOverrid(sizeMod, s);
                        SetGroupConstellationColor(s, newColor);
                    }
                    else
                    {
                        ChangeDisplayNameColor(s, Color.white);
                    }
                }
            }
        }
    }

    private void SetGroupConstellationColor(string name, Color newColor)
    {
        foreach (LineRenderer lr in StarCreator.Constellations[name])
        {
            lr.material.color = newColor;
        }
    }

    #region Sound
    private void PlayHoverSound()
    {
        if (canHoverSound)
        {
            aud.PlayOneShot(constellationData.HoverSound);
            canHoverSound = false;
            StartCoroutine(HoverSoundWait());
        }
    }

    private IEnumerator HoverSoundWait()
    {
        yield return new WaitForSeconds(constellationData.HoverBufferTime);
        canHoverSound = true;
    }
    #endregion
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentSelected != "")
            Interact(true);
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isOnButton)
            ButtonClick();
    }

    #region Interact
    public void Interact(bool isRight)
    {
        if (isRight && rightSelected == "") return;
        else if (!isRight && leftSelected == "") return;

        if(activeExperience == null && !alreadySelectedExperiences.ContainsKey(currentSelected))
        {
            string toSpawn = "";

            if (isGroup)
            {
                foreach (ListWrapper group in constellationData.GroupedConstellations)
                {
                    if (group.names.Contains(currentSelected))
                    {
                        foreach(string name in group.names)
                        {
                            if(name != currentSelected)
                            {
                                ChangeStarSizeOverrid(1 / constellationData.HoverGroupedStarSizeMod, name);
                                ChangeStarSizeOverrid(constellationData.HoverStarSizeMod, name);
                                ChangeDisplayName(name, false);
                                alreadySelectedExperiences.Add(name, true);
                            }
                        }

                        toSpawn = group.toSpawn;
                    }
                }

                ChangeConstellationColor(constellationData.GroupColor);
            }
            else
            {
                toSpawn = currentSelected;
            }

            activeExperience = Instantiate(Resources.Load("Prefabs/Stars/Constellation Experiences/" + toSpawn, typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
            alreadySelectedExperiences.Add(currentSelected, true);
            if(isGroup) { activeExperience = Instantiate(new GameObject("Empty")); }

            aud.PlayOneShot(constellationData.ClickSound);
            ChangeOtherLines(false);
            ChangeDisplayName(currentSelected, false);
        }
    }

    public void EndExperience()
    {
        Destroy(activeExperience);

        activeExperience = null;
        ChangeConstellationColor(constellationData.AlreadyClickedColor);
        ChangeStarSizeOverrid(1 / constellationData.HoverStarSizeMod, currentSelected);

        currentSelected = "";
        rightSelected = "";
        leftSelected = "";
        ChangeOtherLines(true);
    }
    #endregion

    #region Change Stuff
    private void ChangeStarSize(float hoverStarSizeMod)
    {
        if (alreadySelectedExperiences.TryGetValue(currentSelected, out bool hasBeenSelected))
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

        Debug.Log(true);
    }

    [SerializeField]
    private List<GameObject> displayNameList;
    private static Dictionary<string, GameObject> displayNames = new Dictionary<string, GameObject>();
    private static Dictionary<string, SpriteRenderer> displayNameRenderers = new Dictionary<string, SpriteRenderer>();
    private void ChangeDisplayName(string name, bool on)
    {
        if (displayNames.TryGetValue(name, out GameObject displayName))
        {
            displayName.SetActive(on);
        }
    }

    private void ChangeDisplayNameColor(string name, Color newColor)
    {
        if (displayNameRenderers.TryGetValue(name, out SpriteRenderer sr))
        {
            sr.color = newColor;
        }
    }

    private void ChangeOtherLines(bool shouldBeOn)
    {
        foreach(string name in StarCreator.ConstellationNames)
        {
            if(currentGroupNames.Contains(name)) { continue; }

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
    #endregion
}

[System.Serializable]
public class ListWrapper
{
    public List<string> names;

    public string toSpawn;
}