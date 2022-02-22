using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectTheDotsExperience : Experience
{
    public List<Vector3> points = new List<Vector3>();
    public List<Vector3> otherPoints = new List<Vector3>();
    public Vector3[] newPoints;
    private bool test;
    public static ConnectTheDotsExperience thisScript;

    private void Awake()
    {
        thisScript = this;
        StarCreator.Constellations.TryGetValue(this.gameObject.name, out List<LineRenderer> lrs);

        if (lrs.Count > 1)
        {
            for (int a = 0; a < lrs[0].positionCount; a++)
            {
                points.Add(lrs[0].GetPosition(a));
            }
            for (int a = 0; a < lrs[1].positionCount; a++)
            {
                otherPoints.Add(lrs[1].GetPosition(a));
            }
            foreach (LineRenderer lr in lrs)
            {
                if(lr == lrs[0])
                {
                    lr.positionCount = 1;
                }
                else
                {
                    Destroy(lr);
                }
            }
        }
        else
        {
            foreach (LineRenderer lr in lrs)
            {
                for (int a = 0; a < lr.positionCount; a++)
                {
                    points.Add(lr.GetPosition(a));
                }
                lr.positionCount = 1;
            }
        }
        //lr[0].GetPosition[0];

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public Vector3 NextPoint()
    {
        StarCreator.Constellations.TryGetValue(this.gameObject.name, out List<LineRenderer> lrs);
        return points[lrs[0].positionCount];
    }

    public void addPoint()
    {
        StarCreator.Constellations.TryGetValue(this.gameObject.name, out List<LineRenderer> lrs);
        lrs[0].positionCount++;
    }

    public void SetPoint(Vector3 pos)
    {
        StarCreator.Constellations.TryGetValue(this.gameObject.name, out List<LineRenderer> lrs);
        lrs[0].SetPosition(lrs[0].positionCount-1, pos);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !test)
        {
            test = true;
            StarCreator.Constellations.TryGetValue("Perseus", out List<LineRenderer> lrs);
            if (lrs.Count > 1)
            {
                for (int a = 0; a < lrs[0].positionCount; a++)
                {
                    points.Add(lrs[0].GetPosition(a));
                }
                for (int a = 0; a < lrs[1].positionCount; a++)
                {
                    otherPoints.Add(lrs[1].GetPosition(a));
                }
                foreach (LineRenderer lr in lrs)
                {
                    if (lr == lrs[0])
                    {
                        lr.positionCount = 1;
                    }
                    else
                    {
                        Destroy(lr);
                    }
                }
            }
            else
            {
                foreach (LineRenderer lr in lrs)
                {
                    for (int a = 0; a < lr.positionCount; a++)
                    {
                        points.Add(lr.GetPosition(a));
                    }
                    lr.positionCount = 1;
                }
            }

        }
    }

}
