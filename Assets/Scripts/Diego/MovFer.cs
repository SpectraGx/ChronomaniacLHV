using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFer : MonoBehaviour
{
    public float speedMove = 5f;
    public Transform weapon;

    public Transform PointShot;
    public GameObject projectilePistol;

    // Cadencia de la pistola
    public float timeBetweenShots;
    float nextShotTime;

    private void Update()
    {
        // Obtener controles horizontales y verticales
        float moveHori = Input.GetAxis("Horizontal");
        float moveVerti = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector3 direcMove = new Vector3(moveHori, moveVerti, 0f);

        // Normalizar movimiento
        direcMove.Normalize();

        // Mover al jugador en la dirección calculada
        transform.Translate(direcMove * speedMove * Time.deltaTime);

        // Rotacion del arma
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle);

        // Disparo
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + timeBetweenShots;
                GameObject projectile = Instantiate(projectilePistol, PointShot.position, PointShot.rotation);

                // Destruir el objeto "projectilePistol" después de 2 segundos
                Destroy(projectile, 1.5f);
            }
        }

    }
}
