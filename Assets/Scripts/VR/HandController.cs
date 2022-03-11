/*****************************************************************************
// File Name :         HandController.cs
// Author :            Jacob Welch
// Creation Date :     13 November 2021
//
// Brief Description : Takes in input values for hand animations.
*****************************************************************************/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    /// <summary>
    /// The ActionBasedController attached to this gameobject.
    /// </summary>
    private ActionBasedController controller;

    [SerializeField]
    [Tooltip("The hand that this script controls")]
    private Hand hand;

    [HideInInspector]
    public bool isPressed = false;

    #region Constellation Interactions
    //static List<ConstellationInteraction> cis = new List<ConstellationInteraction>();

    [SerializeField]
    ConstellationInteraction ci;

    [SerializeField]
    private bool isRight = true;

    private static bool neitherEnabled = true;
    #endregion

    [SerializeField]
    DraggingPlacable dp;

    /// <summary>
    /// Initializes necessary components.
    /// </summary>
    private void Awake()
    {
        controller = GetComponent<ActionBasedController>();
    }

    /// <summary>
    /// Sends the current animations values to the Hand script.
    /// </summary>
    private void Update()
    {
        hand.SetGrip(controller.selectAction.action.ReadValue<float>());

        #region Old Other trigger stuff
        /*
        if(neitherEnabled && controller.selectAction.action.ReadValue<float>() == 1)
        {
            //neitherEnabled = false;
            //ci.enabled = true;
        }
        else if(!neitherEnabled && ci.enabled && controller.selectAction.action.ReadValue<float>() == 0)
        {
            //neitherEnabled = true;
            //ci.enabled = false;

            if (neitherEnabled)
            {
                /*
                foreach(ConstellationInteraction ci in cis)
                {
                    if (!ci.enabled)
                    {
                        neitherEnabled = true;
                        break;
                    }
                }
    }
}*/
#endregion

if (ci.enabled)
        {
            if (controller.activateAction.action.ReadValue<float>() == 1)
            {
                if (!isPressed)
                {
                    ci.Interact(isRight);
                    ci.ButtonClick();

                    if (dp.enabled)
                    {
                        dp.Attach();
                    }
                }

                isPressed = true;
            }
            else
            {
                isPressed = false;
            }
        }

        hand.SetTrigger(controller.activateAction.action.ReadValue<float>());
    }
}
