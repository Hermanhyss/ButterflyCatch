using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        SetRandomDirection();
    }

    void Update()
    {
        
        if (rb.linearVelocity.magnitude < 0.1f) 
        {
            SetRandomDirection();
        }
    }

    void SetRandomDirection()
    {
        
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

       
        rb.AddForce(randomDirection * 5f, ForceMode.VelocityChange);
    }

   
}


