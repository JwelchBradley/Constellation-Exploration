using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveConstellationArt : MonoBehaviour
{
    [SerializeField]
    private List<string> constellationNames = new List<string>();

    // Start is called before the first frame update
    void OnDestroy()
    {
        foreach (LookAt h in GameObject.FindObjectsOfType<LookAt>())
        {
            Debug.Log(h.gameObject.name);
            if (constellationNames.Contains(h.gameObject.name))
            {
                h.ChangeArt(LookAt.ArtOnType.OFF);
            }
        }
    }
}
