using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingExperience : Experience
{
    [SerializeField]
    private List<GameObject> placeables = new List<GameObject>();
    DraggingPlacable[] dragging;
    private int completed = 0;

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
            Destroy(gameObject, ExperienceTimer);
        }
        aud.Play();
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
