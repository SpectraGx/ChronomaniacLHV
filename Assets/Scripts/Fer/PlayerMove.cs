using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speedMove = 5f;

    private void Update()
    {
        // Obtener controles horizontales y verticales
        float moveHori = Input.GetAxis("Horizontal");
        float moveVerti = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector3 direcMove = new Vector3(moveHori, moveVerti, 0f);

        // Normalizar movimiento
        direcMove.Normalize();

        transform.Translate(direcMove * speedMove * Time.deltaTime);
    }
}
