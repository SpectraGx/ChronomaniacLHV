using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform PointShot;
    public GameObject projectilePistol;
    public int pelletsCount = 8;
    public float spreadAngle = 20f;
    public float fireRate = 1f;

    private float nextFireTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Fire();            
        }
    }

    private void Fire()
    {
        for (int i = 0; i < pelletsCount; i++)
        {
            // Calculate a random angle within the spread angle
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion rotation = PointShot.rotation * Quaternion.Euler(0, 0, randomAngle);
            Instantiate(projectilePistol, PointShot.position, rotation);
        }
    }
}
