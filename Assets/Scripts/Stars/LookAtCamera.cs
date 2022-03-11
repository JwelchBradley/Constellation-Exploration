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

    [SerializeField]
    private bool isPlaceable = false;

    [SerializeField]
    private bool shouldMove = true;

    [SerializeField]
    private bool shouldWait = false;

    // Start is called before the first frame update
    void Start()
    {

        camTransform = Camera.main.transform;
        if(shouldMove)
        transform.position = (transform.position - camTransform.position).normalized * 1000;

        if (!isText)
        {
            transform.LookAt(camTransform.position);

            if (shouldWait)
            {
                Invoke("LookAtCameraWait", 0.51f);
            }
        }
    }

    private void LookAtCameraWait()
    {
        transform.LookAt(camTransform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isText)
        {
            transform.rotation = camTransform.rotation;
        }
        else if (isPlaceable)
        {
            transform.LookAt(camTransform.position);

            //transform.position = (transform.position - camTransform.position).normalized * 1000;

            
            if (transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
    }
}
