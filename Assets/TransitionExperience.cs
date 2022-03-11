using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionExperience : Experience
{
    [SerializeField]
    private bool isEnd;
    [SerializeField]
    private GameObject nextToSpawn;
    [SerializeField]
    private bool endAfterAudio = false;

    protected override void Awake()
    {
        base.Awake();

        if (endAfterAudio)
            Destroy(gameObject, ExperienceTimer);
    }

    protected void OnDestroy()
    {
        if (isEnd)
        {
            FindObjectOfType<ConstellationInteraction>().EndExperience();
        }
        else
        {
            Instantiate(nextToSpawn, transform.position, Quaternion.identity);
        }
    }
}
