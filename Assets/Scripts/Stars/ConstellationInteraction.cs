using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationInteraction : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField]
    private LayerMask constellationLayer;

    private static string currentSelected = "";

    private string thisSelected = "";

    [SerializeField]
    private Color hoverColor;

    [SerializeField]
    private Color defaultColor;

    public Color DefaultColor
    {
        get => defaultColor;
    }

    private Color inactiveColor;

    private GameObject activeExperience;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, constellationLayer))
        {
            string name = hit.transform.gameObject.name;

            if (!currentSelected.Equals(name))
            {
                if (!currentSelected.Equals(""))
                {
                    ChangeConstellationColor(Color.gray);
                }

                currentSelected = name;

                ChangeConstellationColor(hoverColor);
            }
        }
        else if (!currentSelected.Equals(""))
        {
            ChangeConstellationColor(Color.gray);
            currentSelected = "";
        }
    }

    public void Interact()
    {
        if(activeExperience == null)
        activeExperience = Instantiate(Resources.Load("Prefabs/Stars/Constellation Experiences/Orion", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
    }

    private void ChangeConstellationColor(Color newColor)
    {
        if(currentSelected == "")
        {
            return;
        }

        foreach(LineRenderer lr in StarCreator.Constellations[currentSelected])
        {
            lr.material.color = newColor;
        }
    }
}
