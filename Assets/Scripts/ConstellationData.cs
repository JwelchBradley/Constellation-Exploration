using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ConstellationData")]
public class ConstellationData : ScriptableObject
{
    [SerializeField]
    private float hapticFeedbackDuration;
    public float HapticFeedbackDuration { get => hapticFeedbackDuration; }

    [SerializeField]
    private float hapticFeedbackAmplitude;
    public float HapticFeedbackAmplitude { get => hapticFeedbackAmplitude; }

    [SerializeField]
    private float lineWidth = 3.0f;
    public float LineWidth { get => lineWidth; }

    #region Star Twinkle
    [SerializeField]
    private float minStarSize = 0.8f;
    public float MinStarSize { get => minStarSize; }

    [SerializeField]
    private float maxStarSize = 0.8f;
    public float MaxStarSize { get => maxStarSize; }

    [SerializeField]
    private float minStarTime = 0.8f;
    public float MinStarTime { get => minStarTime; }

    [SerializeField]
    private float maxStarTime = 4.0f;
    public float MaxStarTime { get => maxStarTime; }
    #endregion

    #region Constellation Star Twinkle
    [SerializeField]
    private float minConstellationStarSize = 0.8f;
    public float MinConstellationStarSize { get => minConstellationStarSize; }

    [SerializeField]
    private float maxConstellationStarSize = 0.8f;
    public float MaxConstellationStarSize { get => maxConstellationStarSize; }

    [SerializeField]
    private float minConstellationStarTime = 0.8f;
    public float MinConstellationStarTime { get => minConstellationStarTime; }

    [SerializeField]
    private float maxConstellationStarTime = 3.0f;
    public float MaxConstellationStarTime { get => maxConstellationStarTime; }
    #endregion

    #region LayerMasks
    [SerializeField]
    private LayerMask constellationLayer;

    public LayerMask ConstellationLayer
    {
        get => constellationLayer;
    }

    [SerializeField]
    private LayerMask buttonLayer;
    public LayerMask ButtonLayer { get => buttonLayer; }
    #endregion

    #region Lists
    [SerializeField]
    List<ListWrapper> groupedConstellations = new List<ListWrapper>();
    public List<ListWrapper> GroupedConstellations { get => groupedConstellations; }

    [SerializeField]
    private List<GameObject> notFinished = new List<GameObject>();
    public List<GameObject> NotFinished { get => notFinished; }
    #endregion

    #region Colors
    [Header("Color")]
    [SerializeField]
    [ColorUsageAttribute(true, true)]
    private Color hoverColor;
    public Color HoverColor { get => hoverColor; }

    [SerializeField]
    [ColorUsageAttribute(true, true)]
    private Color defaultColor;
    public Color DefaultColor
    {
        get => defaultColor;
    }

    [SerializeField]
    private Color groupColor;  
    public Color GroupColor { get => groupColor; }

    [SerializeField]
    [ColorUsageAttribute(true, true)]
    private Color alreadyClickedColor;  
    public Color AlreadyClickedColor { get => alreadyClickedColor; }
    #endregion

    #region Hover
    [Header("Hover")]
    #region Hover Size
    [SerializeField]
    private float hoverStarSizeMod = 3.0f;
    public float HoverStarSizeMod { get => hoverStarSizeMod; }

    [SerializeField]
    private float hoverGroupedStarSizeMod = 1.5f;
    public float HoverGroupedStarSizeMod { get => hoverGroupedStarSizeMod; }
    #endregion

    #region Audio
    [Tooltip("The sound made when the user hovers over the constellation")]
    [SerializeField] private AudioClip hoverSound;
    public AudioClip HoverSound { get => hoverSound; }

    [Tooltip("The time between potential hover sounds")]
    [SerializeField] private float hoverBufferTime = 0.1f;
    public float HoverBufferTime { get => hoverBufferTime; }

    [Tooltip("The sound made when the user clicks on the constellation")]
    [SerializeField] private AudioClip clickSound;
    public AudioClip ClickSound { get => clickSound; }
    #endregion
    #endregion
}
