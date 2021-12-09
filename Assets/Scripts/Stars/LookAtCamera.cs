using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    /// <summary>
    /// The main camera's transform.
    /// </summary>
    private Transform camTransform;

    [SerializeField]
    [Tooltip("Mark true if this is a text object")]
    private bool isText = true;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
        transform.position = (transform.position - camTransform.position).normalized * 1000;

        if (!isText)
        {
            transform.LookAt(camTransform.position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isText)
        {
            transform.rotation = camTransform.rotation;
        }        
    }
}
