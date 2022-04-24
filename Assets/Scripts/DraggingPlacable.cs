using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DraggingPlacable : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField]
    private LayerMask draggingLayer;

    [SerializeField]
    private HandController hand;

    [SerializeField]
    private ActionBasedController xrController;

    private Dragable d;

    private bool isAttached = false;

    private bool isHovering = false;

    private void Update()
    {
        if (!isAttached && Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, draggingLayer))
        {
            isHovering = true;
        }
        else if (!hand.isPressed)
        {
            if (isAttached)
            {
                d.isBeingDragged = false;
                isAttached = false;

            }

            isHovering = false;
        }
        else
        {
            isHovering = false;
        }
    }

    private void LateUpdate()
    {
        if (isAttached)
            MoveToHandPos();
    }

    public void Attach()
    {
        if (isHovering)
        {
            d = hit.transform.GetComponentInChildren<Dragable>();
            d.thisXR = xrController;
            d.isBeingDragged = true;
            isAttached = true;
        }
    }

    private void MoveToHandPos()
    {
        if(hit.transform != null)
        {
            hit.transform.position = transform.position + transform.forward * 1000;
            if(hit.transform.position.y < 0)
            {
                hit.transform.position = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);
            }
        }
    }
}
