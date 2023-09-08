using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuntarAlMouse : MonoBehaviour
{
    private void Update()
    {
        // Obtener la posición del puntero del mouse en el mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Asegúrate de que la Z sea 0 para 2D.

        // Calcular la dirección desde el jugador hacia el puntero del mouse
        Vector3 direccion = mousePos - transform.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Rotar el sprite del jugador para que apunte hacia el puntero del mouse
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo));
    }
}
