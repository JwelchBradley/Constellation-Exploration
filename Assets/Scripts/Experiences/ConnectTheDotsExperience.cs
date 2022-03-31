using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.ParticleSystem;

public class ConnectTheDotsExperience : TransitionExperience
{
    [SerializeField]
    private AudioClip connectDotSound;

    [SerializeField]
    private ConstellationData constellationData;

    public List<Vector3> points = new List<Vector3>();

    //public GameObject completedArt;

    public static ConnectTheDotsExperience thisScript;

    public string name;

    public int totalPoints;
    public int currentPoints;

    public static bool audioFinished = false;

    [SerializeField]
    public Dictionary<int, List<int>> pointer = new Dictionary<int, List<int>>();

    [SerializeField]
    private float hapticFeedbackAmplitude = 0.25f;

    [SerializeField]
    private float hapticFeedbackDuration = 0.1f;

    private RaycastedDots dot;

    public Color lerped;
    public float value = 0;
    public float time;

    public Color aimedColor;

    private bool check = true;

    protected override void Awake()
    {
        base.Awake();
        audioFinished = false;
        name = this.gameObject.name.Substring(0, this.gameObject.name.IndexOf('('));
        thisScript = this;



        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);

        switch (name)
        {
            case ("Perseus"):
                pointer.Add(0, new List<int> { 1 });
                pointer.Add(1, new List<int> { 0, 2 });
                pointer.Add(2, new List<int> { 1, 3, 8 });
                pointer.Add(3, new List<int> { 2, 4 });
                pointer.Add(4, new List<int> { 3, 5 });
                pointer.Add(5, new List<int> { 4, 6 });
                pointer.Add(6, new List<int> { 5, 7 });
                pointer.Add(7, new List<int> { 2 , 6 });
                pointer.Add(8, new List<int> { 2, 9 });
                pointer.Add(9, new List<int> { 8, 10 });
                pointer.Add(10, new List<int> { 2 , 9 });
                break;
            case ("Cassiopeia"):
                pointer.Add(0, new List<int> { 1 });
                pointer.Add(1, new List<int> { 0, 2 });
                pointer.Add(2, new List<int> { 1, 3 });
                pointer.Add(3, new List<int> { 2, 4 });
                pointer.Add(4, new List<int> { 3 });
                break;
            case ("Cepheus"):
                pointer.Add(0, new List<int> { 1, 2, 3 });
                pointer.Add(1, new List<int> { 0, 2 });
                pointer.Add(2, new List<int> { 0, 1, 4 });
                pointer.Add(3, new List<int> { 0, 4 });
                pointer.Add(4, new List<int> { 2, 3 });
                break;
            default:
                break;
        }
        /*
        var totalX = 0f;
        var totalY = 0f;
        var totalZ = 0f;
        int numTotal = 0;

        List<Vector3> vector3s = new List<Vector3>();

        foreach (LineRenderer lr in lrs)
        {
            for (int a = 0; a < lr.positionCount; a++)
            {
                totalX += lr.GetPosition(a).x;
                totalY += lr.GetPosition(a).y;
                totalZ += lr.GetPosition(a).z;
                numTotal++;

                vector3s.Add(lr.GetPosition(a));
            }
        }

        numTotal++;
        
        var centerX = totalX / numTotal;
        var centerY = totalY / numTotal;
        var centerZ = totalZ / numTotal;


        Vector3 newHell = new Vector3(centerX, centerY, centerZ);

        print(newHell);

        gameObject.transform.position = Vector3.zero;

        gameObject.transform.GetChild(1).transform.position += newHell;
        */
        StartCoroutine("wait");
        
    }

    private void Update()
    {
        /*if (check)
        {
            var totalX = 0f;
            var totalY = 0f;
            var totalZ = 0f;
            int numTotal = 0;


            foreach (ConnectTheDotsData he in GameObject.FindObjectsOfType<ConnectTheDotsData>())
            {
                if (!he.constelation.Equals(""))
                {
                    totalX += he.h.x;
                    totalY += he.h.y;
                    totalZ += he.h.z;
                    numTotal++;
                }
            }

            

            var centerX = totalX / numTotal;
            var centerY = totalY / numTotal;
            var centerZ = totalZ / numTotal;

            Vector3 newHell = new Vector3(centerX, centerY, centerZ);
            print(newHell);
            if(numTotal > 0)
            {
                check = false;
            }
        }*/
    }

    public List<Vector3> NextPoint()
    {
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);
        pointer.TryGetValue(currentPoints, out List<int> nums);

        //Color Shit
        value = Mathf.PingPong(Time.time, 1);
        lerped = Color.Lerp(Color.white, aimedColor, value);
        StarCreator.ConstellationParticleSystems.TryGetValue(name, out ParticleSystem h);
        Particle[] particles = new Particle[h.main.maxParticles];

        h.GetParticles(particles);

        List<Vector3> nextPoints = new List<Vector3>();
        foreach (int num in nums)
        {
            nextPoints.Add(points[num]);
            particles[num].startColor = lerped;
        }
        h.SetParticles(particles);
        return nextPoints;
    }

    public bool AddPoint()
    {
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);
        lrs[0].positionCount++;
        totalPoints++;
        lrs[0].SetPosition(totalPoints, lrs[0].GetPosition(totalPoints-1));

        List<bool> h = new List<bool>();
        for (int a = 0; a < pointer.Count; a++)
        {
            pointer.TryGetValue(a, out List<int> vals);
            if (vals.Count <= 0)
            {
                h.Add(true);
            }
            else
            {
                h.Add(false);
            }
        }
        if(h.Contains(false))
        {
            return false;
        }
        return true;
    }

    public void ResetColor()
    {
        pointer.TryGetValue(currentPoints, out List<int> nums);

        //Particle shit
        StarCreator.ConstellationParticleSystems.TryGetValue(name, out ParticleSystem k);
        Particle[] particles = new Particle[k.main.maxParticles];
        k.GetParticles(particles);

        foreach (int num in nums)
        {
            particles[num].startColor = Color.white;
        }
        k.SetParticles(particles);
    }

    public bool SetPoint(Vector3 pos, bool hit, ActionBasedController xr)
    {
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);
        if (!hit)
        {
            pos = lrs[0].transform.InverseTransformPoint(pos);
        }
        lrs[0].SetPosition(totalPoints, pos);

        List<Vector3> nextPoints = NextPoint();
        if (nextPoints.Contains(pos))
        {
            xr.SendHapticImpulse(hapticFeedbackAmplitude, hapticFeedbackDuration);

            aud.PlayOneShot(connectDotSound);

            pointer.TryGetValue(currentPoints, out List<int> nums);


            foreach (int num in nums)
            {
                if(points[num] == pos)
                {
                    if(currentPoints == 7)
                    {
                        
                        for (int a = currentPoints-1; a >= 2; a--)
                        {
                            if (a != 2)
                            {
                                lrs[0].positionCount++;
                                lrs[0].SetPosition(totalPoints, points[a]);
                                totalPoints++;
                            }
                            else
                            {
                                lrs[0].SetPosition(totalPoints, points[a]);
                            }

                        }
                        pointer.TryGetValue(10, out List<int> rem);
                        rem.Remove(2);
                    }
                    else if(currentPoints == 10)
                    {
                        for (int a = currentPoints - 1; a > 7; a--)
                        {
                                lrs[0].positionCount++;
                                lrs[0].SetPosition(totalPoints, points[a]);
                                totalPoints++;
                        }
                        lrs[0].SetPosition(totalPoints, points[2]);
                        pointer.TryGetValue(7, out List<int> rem);
                        rem.Remove(2);
                    }

                    pointer.TryGetValue(num, out List<int> numer);
                    ResetColor();
                    numer.Remove(currentPoints);
                    currentPoints = num;
                    
                    break;
                }
                
            }
            nums.Remove(currentPoints);
            //print(pointer.Count);
            /*

            pointer.TryGetValue(totalPoints - 1, out List<int> val);
                currentPoints = val[val.IndexOf(points.IndexOf(pos))];

                pointer.TryGetValue(currentPoints, out List<int> newVal);
                val.Remove(points.IndexOf(pos));
                print(newVal.IndexOf(totalPoints - 1) + " " + newVal[newVal.IndexOf(totalPoints - 1)]);
                newVal.Remove(newVal.IndexOf(totalPoints - 1));*/

            return AddPoint();
            //}
            //else
            //{
                //return false;
            //}
        }
        return false;
    }

    bool hasEnded = true;
    public void RemoveFinalPoint()
    {
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);
        lrs[0].positionCount--;
        Destroy(gameObject, 1f);
    }

    public bool IsEmpty()
    {
        return false;
    }

    public IEnumerator wait()
    {
        /*
        while (!audioFinished)
        {
            yield return null;
        }*/
        yield return null;

        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);

        foreach (LineRenderer lr in lrs)
        {
            lr.material.color = constellationData.HoverColor;
        }

        for (int lrsNum = 0; lrsNum < lrs.Count; lrsNum++)
        {
            for (int a = 0; a < lrs[lrsNum].positionCount; a++)
            {
                if (points.Contains(lrs[lrsNum].GetPosition(a)))
                {

                }
                else
                {
                    points.Add(lrs[lrsNum].GetPosition(a));
                }
            }
            lrs[lrsNum].positionCount = 1;
        }

        lrs[0].positionCount = 1;

        dot = GameObject.FindObjectOfType<RaycastedDots>();
        dot.enabled = true;

        AddPoint();

    }
}
