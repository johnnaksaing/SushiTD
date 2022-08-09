using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum E_SushiState 
    {
        Taken,
        Running,
        Default
    }

    public float HP;
    
    public float speed = 10f;
    public E_SushiState m_State = E_SushiState.Default;


    private Transform target;
    int WavePointIndex = 0;
    Vector3 m_dir;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.WaypointTransforms[0];
        m_State = E_SushiState.Running;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_State == E_SushiState.Running)
        {
            m_dir = (target.position - transform.position).normalized;
            transform.position += m_dir * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }

        else if (m_State == E_SushiState.Taken) 
        {

        }
    }
    void GetNextWaypoint() 
    {
        WavePointIndex = (WavePointIndex + 1)% Waypoints.WaypointTransforms.Length;
        target = Waypoints.WaypointTransforms[WavePointIndex];
        return;

        if (WavePointIndex > Waypoints.WaypointTransforms.Length - 1)
        {
            WavePointIndex = 0;
            //Destroy(gameObject);
        }
        else
        {
            target = Waypoints.WaypointTransforms[++WavePointIndex];

        }
    }
}
