using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaLaser : MonoBehaviour
{
    public float laserSpeed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);
    }
}