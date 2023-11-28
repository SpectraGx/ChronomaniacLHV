using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletEnemy;
    public string playerTag = "Player";
    public float fireRate = 0.7f;
    public float bulletSpeed = 4.0f;
    public float spawnOffset = 0.5f;

    private Transform player;
    private float nextFireTime = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag)?.transform;

        if (player == null)
        {
            Debug.LogError("Player not found");
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
            Vector2 spawnPosition = (Vector2)transform.position + direction * spawnOffset;

            GameObject bullet = Instantiate(bulletEnemy, spawnPosition, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            if (bulletRb != null)
            {
                bulletRb.velocity = direction * bulletSpeed;
            }

            Destroy(bullet, 2f);
        }
    }
}
