using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemy : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        
    }
}
