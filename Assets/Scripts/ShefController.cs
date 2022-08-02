using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Combo Manager
public class ShefController : MonoBehaviour
{
    //maybe this would help..?
    //https://www.youtube.com/watch?v=avl2bSyL9ZA
    public enum E_InputCommand
    {
        a = 1,
        s = 2,
        d = 3
    };
    List<GameObject> pfb_Sushies;
    Queue<E_InputCommand> q;
    Dictionary<E_InputCommand[], E_InputCommand[]> dict;

    // Start is called before the first frame update
    void Start()
    {
        pfb_Sushies = new List<GameObject>();
        q = new Queue<E_InputCommand>();
        dict = new Dictionary<E_InputCommand[], E_InputCommand[]>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) 
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                q.Enqueue(E_InputCommand.a);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                q.Enqueue(E_InputCommand.s);
            }
            else if (Input.GetKeyDown(KeyCode.D)) 
            {
                q.Enqueue(E_InputCommand.d);
            }
        }

    }

}
