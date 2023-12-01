using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public float pistolSpeed = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        transform.Translate(Vector3.up * pistolSpeed * Time.deltaTime);
    }
}