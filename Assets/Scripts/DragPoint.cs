using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPoint : MonoBehaviour
{
    [SerializeField]
    private DraggingExperience de;

    [SerializeField]
    private GameObject snapObject;

    [SerializeField]
    private float snapDist = 30f;

    private Dragable dragable;

    private bool hasNotSnapped = true;

    private bool isCloseEnough;

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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.Equals(snapObject))
        {
            if(Vector3.Distance(other.gameObject.transform.position, transform.position) <= snapDist)
            {
                isCloseEnough = true;
            }
            else
            {
                isCloseEnough = false;
            }
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

            if (!dragable.isBeingDragged && isCloseEnough)
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

        dragable.thisXR.SendHapticImpulse(0.3f, 0.2f);
    }
}
