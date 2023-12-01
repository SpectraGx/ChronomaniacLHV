using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedMove = 3f;
    public float candence = 2f;
    public float speedBullet = 10f;
    public int NumBullets = 5; // balas en cada disparo
    public float dispersionAngle = 15f; // dispersi�n de las balas
    public GameObject bullet;
    public Transform shootingPoint;
    public Transform weapon;

    private Transform player;

    [SerializeField] private int type;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PJ").transform;
        switch (type){
            case 0:
            InvokeRepeating("Disparar", 1f, 1f / candence);
            break;

            case 1:
            InvokeRepeating("DispararMultiple", 1f, 1f / candence);
            break;

        }
    }

    private void Update()
    {
        MoverHaciaplayer();

        if (player != null && weapon != null)
        {
            Vector3 direccion = player.position - weapon.position;
            direccion.z = 0;
            weapon.up = direccion.normalized;
        }
    }

    private void MoverHaciaplayer()
    {
        if (player != null)
        {
            Vector3 direccion = player.position - transform.position;
            direccion.Normalize();
            transform.Translate(direccion * speedMove * Time.deltaTime);
        }
    }

    private void DispararMultiple()
    {
        if (player != null && bullet != null && shootingPoint != null)
        {
            for (int i = 0; i < NumBullets; i++)
            {
                float anguloActual = Random.Range(-dispersionAngle, dispersionAngle);
                Quaternion rotacionDisparo = Quaternion.AngleAxis(anguloActual, Vector3.forward);
                Vector2 direccionDisparo = rotacionDisparo * shootingPoint.up;

                GameObject proyectil = Instantiate(bullet, shootingPoint.position, rotacionDisparo);
                proyectil.GetComponent<Rigidbody2D>().velocity = direccionDisparo * speedBullet;
            }
        }
    }

    private void Disparar()
    {
        if (player != null && bullet != null && shootingPoint != null)
        {
            GameObject proyectil = Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            Vector2 direccion = (player.position - shootingPoint.position).normalized;
            proyectil.GetComponent<Rigidbody2D>().velocity = direccion * speedBullet;
            
        }
    }
}
