using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShefController : MonoBehaviour
{
    GameObject[] pfb_Sushies;
    public enum E_InputCommand
    {
        a = 1,
        d = 2
    };
    Queue<E_InputCommand> q;
    // Start is called before the first frame update
    void Start()
    {
        q = new Queue<E_InputCommand>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            q.Enqueue(E_InputCommand.a);
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            q.Enqueue(E_InputCommand.d);
        }
    }
}
