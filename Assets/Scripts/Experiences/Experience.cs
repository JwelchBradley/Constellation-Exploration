using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

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

    protected AudioSource aud;

    [SerializeField]
    private List<SubtitleObject> subtitle = new List<SubtitleObject>();

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        aud = GetComponent<AudioSource>();
        if(aud.clip != null)
        experienceTimer = aud.clip.length;

        if (subtitle.Count != 0)
        {
            StartCoroutine(PlaySubtitles());
        }
    }

    protected IEnumerator PlaySubtitles()
    {
        yield return null;

        foreach(SubtitleObject sub in subtitle)
        {
            Debug.Log(sub.Subtitle);
            Subtitle.sub.SetText(sub.Subtitle);
            yield return new WaitForSeconds(sub.SubtitleTime);
        }

        Subtitle.sub.SetText("");
    }

    protected virtual void OnDestroy()
    {
        Subtitle.sub.SetText("");
    }
}

[Serializable]
public class SubtitleObject
{
    [TextArea]
    [SerializeField]
    private string subtitle;

    public string Subtitle { get => subtitle; }

    [SerializeField]
    [Range(0, 10.0f)]
    private float subtitleTime = 0;

    public float SubtitleTime { get => subtitleTime; }
}
