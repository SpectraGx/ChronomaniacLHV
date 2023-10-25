using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Transform PointShot;
    public GameObject projectilePistol;
    // Cadencia de la pistola
    public float timeBetweenShots;
    float nextShotTime;

    // Update is called once per frame
    private void Update()
    {
        // Disparo
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + timeBetweenShots;
                GameObject projectile = Instantiate(projectilePistol, PointShot.position, PointShot.rotation);

                // Destruir el objeto "projectilePistol" despu�s de 2 segundos
                Destroy(projectile, 1.5f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colision� tiene el tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destruye al enemigo
            Destroy(collision.gameObject);
        }

        // Destruye la bala
        Destroy(gameObject);
    }
}