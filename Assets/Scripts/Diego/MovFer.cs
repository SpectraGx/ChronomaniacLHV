using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFer : MonoBehaviour
{
    public float speedMove = 5f;

    private void Update()
    {
        // Obtener controles horizontales y verticales
        float moveHori = Input.GetAxis("Horizontal");
        float moveVerti = Input.GetAxis("Vertical");

        // Calcular la direcci�n del movimiento
        Vector3 direcMove = new Vector3(moveHori, moveVerti, 0f);

        // Normalizar movimiento
        direcMove.Normalize();

        // Mover al jugador en la direcci�n calculada
        transform.Translate(direcMove * speedMove * Time.deltaTime);
    }
}