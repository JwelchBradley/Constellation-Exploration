using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryScript : MonoBehaviour
{
    //private float timer;
    public bool test;
    public int timer;
    public List<LineRenderer> lrst = new List<LineRenderer>();
    public List<LinePoints> points = new List<LinePoints>();
    public List<GameObject> refrence;
    public GameObject line;
    public Vector3 tests = new Vector3(0, 0, 0);
    public float DistanceToPoint;
    public int currentLine = 1;
    public int currentLineRenderer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //StarCreator.ConnectTheDotGames.TryGetValue(, out List<GameObject> name);
        StartCoroutine(WaitWhileX(1, DisableLineRenderer()));
        //make new line render to next 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

        }
    }
    /*
    private void LateUpdate()
    {
        if (!test)
        {
            test = !test;
            StarCreator.ConnectTheDotGames.TryGetValue("Perseus", out List<GameObject> name);
            StarCreator.Constellations.TryGetValue("Perseus", out List<LineRenderer> lr);
            foreach (LineRenderer lrs in lr)
            {
                lrs.enabled = false;
            }
        }
    }*/

    private void FixedUpdate()
    {
        if (test)
        {
            DrawLines(currentLine, ConstelationStuff("Perseus"), currentLineRenderer);
        }
    }

    /*IEnumerable Help()
    {
        while (test != true)
        {
            try
            {
                StarCreator.ConnectTheDotGames.TryGetValue("Perseus", out List<GameObject> name);
                StarCreator.Constellations.TryGetValue("Perseus", out List<LineRenderer> lr);
                test = true;
            }
            catch
            {
                test = false;
            }
            timer++;
        }a
        yield return null;
    }
    */
    IEnumerator DisableLineRenderer()
    {
        if (!test)
        {
            try
            {
                StarCreator.Constellations.TryGetValue("Perseus", out List<LineRenderer> lr);
                foreach (LineRenderer lrs in lr)
                {
                    lrst.Add(lrs);
                    points.Add(new LinePoints());
                    for (int a = 0; a < lrs.positionCount; a++)
                    {
                        points[points.Count-1].linePoints.Add(lrs.GetPosition(a));
                        lrs.SetPosition(a, lrs.GetPosition(0));
                    }
                }
                test = true;
                //DrawLines();
            }
            catch
            {
                test = false;
            }
            timer++;
        }
        else
        {
            yield return null;
        }

    }

    private IEnumerator WaitWhileX(float waitTime, IEnumerator c)
    {
        if (c != null)
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                StartCoroutine(c);
            }
        }
        else
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
            }
        }
    }

    private void DrawLines(int num, List<LineRenderer> lr, int linerRendererIndex)
    {
        if(DistanceToPoint == 0 && currentLine < lr[linerRendererIndex].positionCount)
        {
            num++;
            currentLine++;
        }
        else if(currentLine == lr[linerRendererIndex].positionCount && linerRendererIndex < lr.Count-1)
        {
            currentLine = 0;
            num = 0;
            linerRendererIndex++;
            currentLineRenderer++;
        }
        for (int a = num; a < lr[linerRendererIndex].positionCount; a++)
        {
            tests = Vector3.MoveTowards(lr[linerRendererIndex].GetPosition(a), points[linerRendererIndex].linePoints[num], 25 * Time.deltaTime);
            lr[linerRendererIndex].SetPosition(a, tests);
            DistanceToPoint = Vector3.Distance(lr[linerRendererIndex].GetPosition(a), points[linerRendererIndex].linePoints[num]);
        }

    }

    private List<LineRenderer> ConstelationStuff(string test)
    {
        StarCreator.Constellations.TryGetValue(test, out List<LineRenderer> lr);
        return lr;
    }
}

[System.Serializable]
public class LinePoints
{
    public List<Vector3> linePoints = new List<Vector3>();
}
