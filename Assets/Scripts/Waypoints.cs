using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] WaypointTransforms;
    // Start is called before the first frame update
    void Awake()
    {
        WaypointTransforms = new Transform[transform.childCount];

        for (int i = 0; i < WaypointTransforms.Length; i++)
        {
            WaypointTransforms[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
