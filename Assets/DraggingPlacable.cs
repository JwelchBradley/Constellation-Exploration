using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingPlacable : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField]
    private LayerMask draggingLayer;

    [SerializeField]
    private HandController hand;

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
            d.isBeingDragged = true;
            isAttached = true;
        }
    }

    private void MoveToHandPos()
    {
        if(hit.transform != null)
        hit.transform.position = transform.position + transform.forward * 1000;
    }
}
