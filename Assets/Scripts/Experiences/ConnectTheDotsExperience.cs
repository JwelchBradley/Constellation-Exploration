using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ConnectTheDotsExperience : TransitionExperience
{
    [SerializeField]
    private AudioClip connectDotSound;

    [SerializeField]
    private ConstellationData constellationData;

    public List<Vector3> points = new List<Vector3>();

    public static ConnectTheDotsExperience thisScript;

    public string name;

    public int totalPoints;
    public int currentPoints;

    public static bool audioFinished = false;

    [SerializeField]
    public Dictionary<int, List<int>> pointer = new Dictionary<int, List<int>>();

    private RaycastedDots dot;

    public Color lerped;
    public float value = 0;
    public float time;
    public float particleStartSize;

    public Color aimedColor;

    protected override void Awake()
    {
        base.Awake();
        audioFinished = false;
        name = this.gameObject.name.Substring(0, this.gameObject.name.IndexOf('('));
        thisScript = this;

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

        StartCoroutine("wait");

    }

    public List<Vector3> NextPoint()
    {
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);
        pointer.TryGetValue(currentPoints, out List<int> nums);

        //Color Shit
        /*
        value = Mathf.PingPong(Time.time, 1);
        lerped = Color.Lerp(Color.white, aimedColor, value);
        StarCreator.ConstellationParticleSystems.TryGetValue(name, out ParticleSystem h);
        Particle[] particles = new Particle[h.main.maxParticles];

        h.GetParticles(particles);
        */
        List<Vector3> nextPoints = new List<Vector3>();
        foreach (int num in nums)
        {
            //need to switch color only once
            nextPoints.Add(points[num]);
            //particles[num].startColor = lerped;
        }
        //h.SetParticles(particles);
        return nextPoints;
    }

    public bool AddPoint()
    {
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);
        lrs[0].positionCount++;
        totalPoints++;
        lrs[0].SetPosition(totalPoints, lrs[0].GetPosition(totalPoints-1));

        SetStartSize();
        StartCoroutine("ChangingColor");

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
        particles[currentPoints].startSize = particleStartSize;
        foreach (int num in nums)
        {
            particles[num].startColor = Color.white;
        }
        k.SetParticles(particles);
    }

    public bool SetPoint(Vector3 pos, bool hit)
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

    public IEnumerator ChangingColor()
    {
        do
        {
            time += Time.deltaTime;
            value = Mathf.PingPong(time, 1);
            lerped = Color.Lerp(Color.white, aimedColor, value);
            StarCreator.ConstellationParticleSystems.TryGetValue(name, out ParticleSystem h);
            Particle[] particles = new Particle[h.main.maxParticles];
            h.GetParticles(particles);

            particles[currentPoints].startSize = value * 100 + particleStartSize;
            particles[currentPoints].startColor = lerped;

            h.SetParticles(particles);

            yield return null;
        } while (value > .06f);
        time = 0;
        value = 0;
        
        
    }

    public void SetStartSize()
    {
        StarCreator.ConstellationParticleSystems.TryGetValue(name, out ParticleSystem h);
        Particle[] particles = new Particle[h.main.maxParticles];
        h.GetParticles(particles);
        particleStartSize = particles[currentPoints].startSize;
    }


}
