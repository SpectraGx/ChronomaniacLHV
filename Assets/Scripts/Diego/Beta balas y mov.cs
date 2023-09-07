using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo; //origen del disparo player
    public float fuerzaDisparo = 10f;
    public float tiempoVidaBala = 2f;
    public float velocidadMovimiento = 5f;

    void Update()
    {
        //movimiento
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movimiento);

        //clic del mouse para disparar
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        //posición del cursor
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //apuntar por el cursor
            Vector3 direccion = (hit.point - puntoDisparo.position).normalized;
            //instancia de la bala y aplicarle una fuerza
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            rb.velocity = direccion * fuerzaDisparo;

            Destroy(bala, tiempoVidaBala);
        }
    }

    //colisiones de la bala
    void OnCollisionEnter(Collision collision)
    {
        //colision con un enemigo
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            //destruir al enemigo y la bala
            Destroy(collision.gameObject); // Destruye al enemigo
            Destroy(gameObject); // Destruye la bala
        }
    }
}