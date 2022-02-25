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
    // Start is called before the first frame update
    void Start()
    {
        starCreator = GameObject.FindObjectOfType<StarCreator>().gameObject;
        print(starCreator.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        //add = transform.forward.normalized + starCreator.transform.forward.normalized;
        //subtract = Vector3.Cross(transform.forward.normalized, starCreator.transform.forward.normalized).normalized;
        Debug.DrawLine(transform.position, subtract, Color.blue);
        //print(transform.forward.normalized + " " + starCreator.transform.localPosition);
        if (!expirence)
        {
            /*
            if (Physics.Raycast(transform.position, transform.forward.normalized, out constellationHit, Mathf.Infinity, constelationLayer))
            {*/

                if (Physics.Raycast(transform.position, transform.forward.normalized, out dotHit, Mathf.Infinity, dotsLayer))
                {
                    point = dotHit.collider.gameObject.transform.localPosition;
                    Debug.DrawLine(this.gameObject.transform.position, dotHit.point, Color.red);
                    print(dotHit.collider.gameObject.transform.localPosition);
                    print(ConnectTheDotsExperience.thisScript.points.IndexOf(dotHit.collider.gameObject.transform.localPosition));
                    //StarCreator.Constellations.TryGetValue(ConnectTheDotsExperience.thisScript.name, out List<LineRenderer> lrs);
                    expirence = ConnectTheDotsExperience.thisScript.SetPoint(dotHit.collider.gameObject.transform.localPosition, true);
                }
                else
                {
                //Debug.DrawLine(constellationHit.point - constellationHit.collider.transform.position, constellationHit.point, Color.blue);
                //expirence = ConnectTheDotsExperience.thisScript.SetPoint(constellationHit.point - constellationHit.collider.transform.position);
                //point = constellationHit.point;
                point = transform.position + transform.forward * 1000;
                expirence = ConnectTheDotsExperience.thisScript.SetPoint(point, false);
                    
                Debug.Log(point);
                }
            //}
        }
        else
        {
            expirence = false;
            ConnectTheDotsExperience.thisScript.RemoveFinalPoint();
            enabled = false;
        }


        //positions of the line inbetween the sphere
        //transform.forward.normalized * 1000 + transform.position
    }
}
