using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkMelee : MonoBehaviour
{
    public Transform PointShot;
    public GameObject bulletPrefab;
    public float fireRate = 0.6f;
    public float bulletLifetime = 0.2f; 

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
        GameObject bullet = Instantiate(bulletPrefab, PointShot.position, PointShot.rotation);
        Destroy(bullet, bulletLifetime);
    }
}
