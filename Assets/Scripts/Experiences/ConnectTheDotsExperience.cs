using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectTheDotsExperience : Experience
{
    [SerializeField]
    private AudioClip connectDotSound;

    public List<Vector3> points = new List<Vector3>();

    public static ConnectTheDotsExperience thisScript;

    public string name;

    public int totalPoints;
    public int currentPoints;


    public List<int> p0;
    public List<int> p1;
    public List<int> p2;
    public List<int> p3;
    public List<int> p4;
    public List<int> p5;
    public List<int> p6;
    public List<int> p7;
    public List<int> p8;
    public List<int> p9;
    public List<int> p10;

    [SerializeField]
    public Dictionary<int, List<int>> pointer = new Dictionary<int, List<int>>();

    private RaycastedDots dot;

    protected override void Awake()
    {
        base.Awake();
        name = this.gameObject.name.Substring(0, this.gameObject.name.IndexOf('('));
        dot = GameObject.FindObjectOfType<RaycastedDots>();
        dot.enabled = true;
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
        AddPoint();
    }
    private void Update()
    {
        for (int a = 0; a < 10; a++)
        {
            pointer.TryGetValue(a, out List<int> nums);
            switch (a)
            {
                case (0):
                    p0 = nums;
                    break;
                case (1):
                    p1 = nums;
                    break;
                case (2):
                    p2 = nums;
                    break;
                case (3):
                    p3 = nums;
                    break;
                case (4):
                    p4 = nums;
                    break;
                case (5):
                    p5 = nums;
                    break;
                case (6):
                    p6 = nums;
                    break;
                case (7):
                    p7 = nums;
                    break;
                case (8):
                    p8 = nums;
                    break;
                case (9):
                    p9 = nums;
                    break;
                case (10):
                    p10 = nums;
                    break;
            }
        }
    }

    public List<Vector3> NextPoint()
    {
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);
        pointer.TryGetValue(currentPoints, out List<int> nums);

        print(nums[0] + " number ");
        List<Vector3> nextPoints = new List<Vector3>();
        foreach (int num in nums)
        {
            nextPoints.Add(points[num]);
            print(num);
        }

        return nextPoints;
    }


    public bool AddPoint()
    {
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);
        lrs[0].positionCount++;
        totalPoints++;
        lrs[0].SetPosition(totalPoints, lrs[0].GetPosition(totalPoints-1));
        print(totalPoints + " " + lrs[0].GetPosition(totalPoints));
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

    public bool SetPoint(Vector3 pos, bool hit)
    {
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);
        if (!hit)
        {
            pos = lrs[0].transform.InverseTransformPoint(pos);
        }
        lrs[0].SetPosition(totalPoints, pos);

        print("SettingPoint");
        List<Vector3> nextPoints = NextPoint();
        if (nextPoints.Contains(pos))
        {

            //if (pos == points[0] && currentPoints != 0 || pos != points[0] && currentPoints == 0)
            //{
            //print(true);

            aud.PlayOneShot(connectDotSound);

            pointer.TryGetValue(currentPoints, out List<int> nums);

            print(nums[0] + " number ");
            //List<Vector3> nextPoints = new List<Vector3>();
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
                    print(num + " HOW ARE YOU ");
                    pointer.TryGetValue(num, out List<int> numer);
                    numer.Remove(currentPoints);
                    currentPoints = num;
                    
                    break;
                }
                
            }
            nums.Remove(currentPoints);
            print(pointer.Count);
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

    public void RemoveFinalPoint()
    {
        StarCreator.Constellations.TryGetValue(name, out List<LineRenderer> lrs);
        lrs[0].positionCount--;
    }

    public bool IsEmpty()
    {
        return false;
    }

}
