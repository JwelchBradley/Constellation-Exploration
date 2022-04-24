using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Dragable : MonoBehaviour
{
    [HideInInspector]
    public bool isBeingDragged = false;

    [HideInInspector]
    public ActionBasedController thisXR;
}
