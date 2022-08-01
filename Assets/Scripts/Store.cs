using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    
    public float averageStar;
    int starCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddStar(float amount) 
    {
        float star = averageStar;
        amount = Mathf.Clamp(amount,0f,5f);
        averageStar = (averageStar * starCount++ + amount) / starCount;

        Debug.Log("star : " + star +" -> "+averageStar);
    }

    public void SpawnCustomer() 
    {

    } 
}
