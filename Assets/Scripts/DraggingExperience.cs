using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingExperience : Experience
{
    [SerializeField]
    private List<GameObject> placeables = new List<GameObject>();
    DraggingPlacable[] dragging;
    private int completed = 0;

    [SerializeField]
    private AudioClip dragSpotPingSound;

    [SerializeField]
    private List<GameObject> toDisable = new List<GameObject>();

    [SerializeField]
    private Animator animator;

    protected override void Awake()
    {
        base.Awake();

       dragging = FindObjectsOfType<DraggingPlacable>();
        EnableDragging(true);

    }

    public void Complete()
    {
        if (++completed == placeables.Count)
        {
            aud.Play();
            StartCoroutine(PlaySubtitles());
            DisableObjects();
            animator.SetBool("HasBuilt", true);
            animator.transform.localScale /= 1.5f;
            animator.transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -90));
            Destroy(gameObject, ExperienceTimer);
        }
        aud.PlayOneShot(dragSpotPingSound);
    }

    private void DisableObjects()
    {
        foreach(GameObject obj in toDisable)
        {
            obj.SetActive(false);
        }
    }

    protected void OnDestroy()
    {
        EnableDragging(false);
        FindObjectOfType<ConstellationInteraction>().EndExperience();
    }

    private void EnableDragging(bool shouldEnable)
    {
        foreach (DraggingPlacable drag in dragging)
        {
            drag.enabled = shouldEnable;
        }
    }
}
