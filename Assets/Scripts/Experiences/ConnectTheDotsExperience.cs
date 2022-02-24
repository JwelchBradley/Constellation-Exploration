using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectTheDotsExperience : Experience
{
    public List<Vector3> points = new List<Vector3>();
    public List<Vector3> otherPoints = new List<Vector3>();
    public List<Vector3> newPoints = new List<Vector3>();
    private bool test;
    public static ConnectTheDotsExperience thisScript;
    public string name;
    public int currentPoint;
    public int maxPoint;
    [SerializeField]
    private int currentLR = 0;

    private void Awake()
    {
        name = this.gameObject.name.Substring(0, this.gameObject.name.IndexOf('('));
        GameObject.FindObjectOfType<RaycastedDots>().enabled = true;
        thisScript = this;
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);

        

        if (lrs.Count > 1)
        {
            for (int a = 0; a < lrs[0].positionCount; a++)
            {
                points.Add(lrs[0].GetPosition(a));
                maxPoint++;
            }
            for (int a = 0; a < lrs[1].positionCount; a++)
            {
                otherPoints.Add(lrs[1].GetPosition(a));
            }
            foreach (LineRenderer lr in lrs)
            {
                lr.positionCount = 1;
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
        newPoints.Add(lrs[0].GetPosition(0));
        print(lrs[currentLR].positionCount);
        AddPoint();
    }

    // Start is called before the first frame update
    void Start()
    {
        //transformforward of hand
        //if(Physics.Raycast(hand))
    }

    public Vector3 NextPoint()
    {
        StarCreator.Constellations.TryGetValue(this.gameObject.name.Substring(0, this.gameObject.name.IndexOf('(')), out List<LineRenderer> lrs);
        if (currentLR == 0)
        {
            return points[lrs[currentLR].positionCount - 1];
        }
        else
        {
            return otherPoints[lrs[currentLR].positionCount - 1];
        }
    }

    public bool AddPoint()
    {
        StarCreator.Constellations.TryGetValue(this.gameObject.name.Substring(0, this.gameObject.name.IndexOf('(')), out List<LineRenderer> lrs);
        currentPoint++;
        print(lrs.Count + " " + currentLR);
        if (currentPoint == maxPoint && lrs.Count == currentLR + 1)
        {
            //Finish Expirence
            return true;
        }
        else
        {
            if (currentPoint == maxPoint)
            {
                currentPoint = 0;
                currentLR++;
                maxPoint = otherPoints.Count;
            }
            else
            {
                lrs[currentLR].positionCount++;
            }
        }
        return false;
    }

    public bool SetPoint(Vector3 pos)
    {
        StarCreator.Constellations.TryGetValue(this.gameObject.name.Substring(0, this.gameObject.name.IndexOf('(')), out List<LineRenderer> lrs);
        lrs[currentLR].SetPosition(currentPoint, pos);

        if(pos == NextPoint())
        {
            return AddPoint();
        }
        return false;
    }

}
