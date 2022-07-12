using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int HP;
    
    public float speed = 10f;

    private Transform target;
    int WavePointIndex = 0;
    Vector3 m_dir;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.WaypointTransforms[0];
    }

    // Update is called once per frame
    void Update()
    {
        m_dir = (target.position - transform.position).normalized;
        transform.position += m_dir * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) 
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint() 
    {
        if (WavePointIndex >= Waypoints.WaypointTransforms.Length - 1)
            Destroy(gameObject);
        else
            target = Waypoints.WaypointTransforms[++WavePointIndex];
    }
}
