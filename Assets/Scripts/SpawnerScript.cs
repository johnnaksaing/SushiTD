using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //prefabs
    public GameObject m_SpawnObject;
    //public List<GameObject> m_SpawnObjects;

    [SerializeField]
    float m_SpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj",0.5f, m_SpawnTime);
    }
    void SpawnObj() 
    {
        Debug.Log("PEW");
        Instantiate(m_SpawnObject);
    }
}
