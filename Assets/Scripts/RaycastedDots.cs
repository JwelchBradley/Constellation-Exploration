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

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(transform.position, subtract, Color.blue);

        if (Input.GetKeyDown(KeyCode.Mouse0) || useable)
        {

            if (!useable && Physics.Raycast(transform.position, transform.forward.normalized, out dotHit, Mathf.Infinity, dotsLayer) &&
                ConnectTheDotsExperience.thisScript.points.IndexOf(dotHit.collider.gameObject.transform.localPosition) == 0)
            {
                expirence = ConnectTheDotsExperience.thisScript.SetPoint(dotHit.collider.gameObject.transform.localPosition, true);
                useable = true;
            }
            else if(useable)
            {
                if (!expirence)
                {
                    if (Physics.Raycast(transform.position, transform.forward.normalized, out dotHit, Mathf.Infinity, dotsLayer))
                    {
                        point = dotHit.collider.gameObject.transform.localPosition;
                        Debug.DrawLine(this.gameObject.transform.position, dotHit.point, Color.red);

                        //print(dotHit.collider.gameObject.transform.localPosition);
                        //print(ConnectTheDotsExperience.thisScript.points.IndexOf(dotHit.collider.gameObject.transform.localPosition));

                        expirence = ConnectTheDotsExperience.thisScript.SetPoint(dotHit.collider.gameObject.transform.localPosition, true);
                    }
                    else
                    {
                        point = transform.position + transform.forward * 1000;
                        expirence = ConnectTheDotsExperience.thisScript.SetPoint(point, false);

                        //print(point);
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


        //positions of the line inbetween the sphere
        //transform.forward.normalized * 1000 + transform.position
    }
}
