using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject cam;
    //public bool artEnabled;
    public enum ArtOnType { FULL, FRACTURE, OFF };

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>().gameObject;
        gameObject.name = "Looking At " +gameObject.transform.parent.name.ToString();
        ChangeArt(ArtOnType.OFF);
    }

    public void ChangeArt(ArtOnType state)
    {
        if (state.Equals(ArtOnType.FRACTURE))
        {
            Debug.Log(true);
            for (int a = 0; a < this.gameObject.transform.childCount; a++)
            {
                if (a == 0)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                else if (!transform.GetChild(a).gameObject.activeSelf)
                {
                    transform.GetChild(a).transform.LookAt(cam.transform.position, transform.GetChild(a).transform.up);
                    transform.GetChild(a).gameObject.SetActive(true);
                }
            }
        }
        else if (state.Equals(ArtOnType.FULL))
        {
            for (int a = 0; a < this.gameObject.transform.childCount; a++)
            {
                if (!transform.GetChild(0).gameObject.activeSelf)
                {
                    //transform.GetChild(0).transform.LookAt(cam.transform.position, transform.GetChild(a).transform.up);
                    transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (transform.GetChild(a).gameObject.activeSelf)
                {
                    transform.GetChild(a).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int a = 0; a < this.gameObject.transform.childCount; a++)
            {
                transform.GetChild(a).gameObject.SetActive(false);
            }
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (artEnabled)
        {
            for (int a = 0; a < this.gameObject.transform.childCount; a++)
            {
                if (!transform.GetChild(0).gameObject.activeSelf)
                {
                    //transform.GetChild(0).transform.LookAt(cam.transform.position, transform.GetChild(a).transform.up);
                    transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (transform.GetChild(a).gameObject.activeSelf)
                {
                    transform.GetChild(a).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int a = 0; a < this.gameObject.transform.childCount; a++)
            {
                if (transform.GetChild(0).gameObject.activeSelf)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                else if (!transform.GetChild(a).gameObject.activeSelf && !transform.GetChild(a).name.Equals("ignore"))
                {
                    transform.GetChild(a).transform.LookAt(cam.transform.position, transform.GetChild(a).transform.up);
                    transform.GetChild(a).gameObject.SetActive(true);
                }
            }
        }
    }*/
}
