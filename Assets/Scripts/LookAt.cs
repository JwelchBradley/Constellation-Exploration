using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject t = null;
        for(int a =0; a < this.gameObject.transform.childCount; a++)
        {
            
            transform.GetChild(a).transform.LookAt(cam.transform.position, transform.GetChild(a).transform.up);
        }
        //transform.LookAt(cam.transform.position, transform.up);
    }
}
