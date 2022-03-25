using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPoint : MonoBehaviour
{
    [SerializeField]
    private DraggingExperience de;

    [SerializeField]
    private GameObject snapObject;

    private Dragable dragable;

    private bool hasNotSnapped = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(snapObject))
        {
            if(dragable==null)
            dragable = other.gameObject.GetComponent<Dragable>();

            if(dragable.isBeingDragged)
            StartCoroutine(SnapRoutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(snapObject))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator SnapRoutine()
    {
        while (hasNotSnapped)
        {
            yield return null;

            if (!dragable.isBeingDragged)
            {
                Snap();
            }
        }
    }

    public void Snap()
    {
        snapObject.layer = 0;
        snapObject.transform.position = transform.position;
        de.Complete();
        hasNotSnapped = false;
    }
}
