using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die",0.5f);        
    }

    void Die() 
    {
        Destroy(gameObject);
    }
}
