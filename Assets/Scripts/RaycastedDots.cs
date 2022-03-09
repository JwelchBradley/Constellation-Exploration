using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastedDots : MonoBehaviour
{
    [SerializeField]
    private LayerMask dotsLayer;

    [SerializeField]
    private LayerMask constelationLayer;
    public Vector3 point;

    public RaycastHit dotHit;
    public RaycastHit constellationHit;

    public GameObject starCreator;

    public Vector3 add;
    public Vector3 subtract;

    public bool expirence;
    public bool useable;
    // Start is called before the first frame update
    void Start()
    {
        starCreator = GameObject.FindObjectOfType<StarCreator>().gameObject;
        print(starCreator.gameObject.name);
    }

    private void Update()
    {
        if (!expirence)
        {
            if (Physics.Raycast(transform.position, transform.forward.normalized, out dotHit, Mathf.Infinity, dotsLayer))
            {
                point = dotHit.collider.gameObject.transform.localPosition;
                Debug.DrawLine(this.gameObject.transform.position, dotHit.point, Color.red);

                expirence = ConnectTheDotsExperience.thisScript.SetPoint(dotHit.collider.gameObject.transform.localPosition, true);
            }
            else
            {
                point = transform.position + transform.forward * 1000;
                expirence = ConnectTheDotsExperience.thisScript.SetPoint(point, false);
            }

        }

        else
        {
            expirence = false;
            ConnectTheDotsExperience.thisScript.RemoveFinalPoint();
            enabled = false;
            useable = false;
        }
    }


    
}
