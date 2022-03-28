using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectTheDotsData : MonoBehaviour
{
    private List<GameObject> nodes;
    public Vector3 h;
    public string constelation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = transform.position;
    }
}
