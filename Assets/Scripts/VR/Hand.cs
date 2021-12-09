/*****************************************************************************
// File Name :         Hand.cs
// Author :            Jacob Welch
// Creation Date :     13 November 2021
//
// Brief Description : Handles the animations of the hands.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    #region Fields
    /// <summary>
    /// The animator of the hand.
    /// </summary>
    private Animator anim;


    /// <summary>
    /// The skinnedmeshrender child component.
    /// </summary>
    private SkinnedMeshRenderer smr;

    #region Grip
    /// <summary>
    /// The target value of the grip action.
    /// </summary>
    private float gripTarget;

    /// <summary>
    /// The current grip action value.
    /// </summary>
    private float gripCurrent;

    [SerializeField]
    [Tooltip("The speed of the grip animation")]
    [Range(0, 1)]
    private float gripSpeed;

    [SerializeField]
    [Tooltip("The name of the grip animation parameter")]
    private string animatorGripParam = "Grip";
    #endregion

    #region Trigger
    /// <summary>
    /// The target value of the trigger action.
    /// </summary>
    private float triggerTarget;

    /// <summary>
    /// The current value of the trigger action.
    /// </summary>
    private float triggerCurrent;

    [SerializeField]
    [Tooltip("The speed of the trigger animation")]
    [Range(0, 1)]
    private float triggerSpeed;

    [SerializeField]
    [Tooltip("The name of the trigger animation parameter")]
    private string animatorTriggerParam = "Trigger";
    #endregion
    #endregion

    #region Functions
    #region Initialization
    /// <summary>
    /// Initalizes necessary components.
    /// </summary>
    void Awake()
    {
        anim = GetComponent<Animator>();
        smr = GetComponentInChildren<SkinnedMeshRenderer>();
    }
    #endregion

    #region Animation
    /// <summary>
    /// Updates the hand animation once per frame.
    /// </summary>
    void Update()
    {
        AnimateHand();
    }

    /// <summary>
    /// Animates the hand to its target state.
    /// </summary>
    private void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            GripAnimation();
        }

        if (triggerCurrent != triggerTarget)
        {
            TriggerAnimation();
        }
    }

    /// <summary>
    /// Animates the hand to its grip position.
    /// </summary>
    private void GripAnimation()
    {
        gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime / gripSpeed);
        anim.SetFloat(animatorGripParam, gripCurrent);
    }

    /// <summary>
    /// Animates the hand to its trigger position.
    /// </summary>
    private void TriggerAnimation()
    {
        triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime / triggerSpeed);
        anim.SetFloat(animatorTriggerParam, triggerCurrent);
    }
    #endregion

    #region Set Values
    /// <summary>
    /// Sets the gripTarget value.
    /// </summary>
    /// <param name="v">New value of gripTarget</param>
    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    /// <summary>
    /// Set the triggerTarget value.
    /// </summary>
    /// <param name="v">New value of triggerTarget</param>
    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    public void ToggleVisibility()
    {
        smr.enabled = !smr.enabled;
    }
    #endregion

    #endregion
}
