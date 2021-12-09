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

    #region Constellation Interactions
    static List<ConstellationInteraction> cis = new List<ConstellationInteraction>();

    [SerializeField]
    ConstellationInteraction ci;
    #endregion

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

        if(controller.selectAction.action.ReadValue<float>() == 1)
        {
            ci.enabled = true;

            if (controller.activateAction.action.ReadValue<float>() == 1)
            {
                ci.Interact();
            }
        }
        else if(ci.enabled)
        {
            bool neitherEnabled = false;
            ci.enabled = false;

            if (neitherEnabled)
            {
                foreach(ConstellationInteraction ci in cis)
                {
                    if (!ci.enabled)
                    {
                        neitherEnabled = true;
                        break;
                    }
                }
            }
        }

        hand.SetTrigger(controller.activateAction.action.ReadValue<float>());
    }
}
