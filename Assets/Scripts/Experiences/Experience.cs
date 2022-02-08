using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    /// <summary>
    /// How long this exprience takes to finish.
    /// </summary>
    private float experienceTimer;

    public float ExperienceTimer
    {
        get => experienceTimer;
    }

    AudioSource aud;

    // Start is called before the first frame update
    void Awake()
    {
        aud = GetComponent<AudioSource>();
        experienceTimer = aud.clip.length;
    }
}
