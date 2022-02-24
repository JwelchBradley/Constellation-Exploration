using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastedDots : MonoBehaviour
{
    [SerializeField]
    private LayerMask dotsLayer;
    public Vector3 point;

    RaycastHit hit;

    public bool expirence;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!expirence)
        {
            if (Physics.Raycast(transform.position, transform.forward.normalized, out hit, Mathf.Infinity, dotsLayer))
            {

                Debug.DrawLine(this.gameObject.transform.position, hit.point, Color.red);
                print(hit.collider.gameObject.transform.localPosition);
                print(ConnectTheDotsExperience.thisScript.points.IndexOf(hit.collider.gameObject.transform.localPosition));
                StarCreator.Constellations.TryGetValue(ConnectTheDotsExperience.thisScript.name, out List<LineRenderer> lrs);
                expirence = ConnectTheDotsExperience.thisScript.SetPoint(hit.collider.gameObject.transform.localPosition);


            }
            else
            {
                expirence = ConnectTheDotsExperience.thisScript.SetPoint(transform.forward.normalized * 1000 + transform.position);
                point = transform.forward.normalized * 1000 + transform.position;
            }
        }
        else
        {
            expirence = false;
            enabled = false;
        }


        //positions of the line inbetween the sphere
        //transform.forward.normalized * 1000 + transform.position
    }
}
