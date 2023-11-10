using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletEnemy;
    public string playerTag = "Player";
    public float fireRate = 0.7f;
    public float bulletSpeed = 4.0f;

    private Transform player;
    private float nextFireTime = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        if (player == null)
        {
            Debug.LogError("Player no encontrado");
        }
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            ShootAtPlayer();
        }
    }

    private void ShootAtPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

            GameObject bullet = Instantiate(bulletEnemy, transform.position, rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            if (bulletRb != null)
            {
                bulletRb.velocity = direction * bulletSpeed;
            }

            Destroy(bullet, 2f); // Destruye la bala

        }
    }

}
