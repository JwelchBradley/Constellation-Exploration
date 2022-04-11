using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    public static Subtitle sub;
    private TextMeshProUGUI text;

    private void Awake()
    {
        sub = this;
        text = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string subtitle)
    {
        text.text = subtitle;
    }
}
