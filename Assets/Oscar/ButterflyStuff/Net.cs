using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    
  

    void Start()
    {
        
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Butterfly")) 
        {
            Debug.Log("Butterfly caught!");
       
           
        }
    }
}

