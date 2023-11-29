using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform PointShot;
    public GameObject bulletPrefab;
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
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);
            Vector3 direction = rotation * PointShot.up;

            Instantiate(bulletPrefab, PointShot.position, Quaternion.LookRotation(Vector3.forward, direction));
        }
    }
}
