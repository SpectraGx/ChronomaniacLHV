using UnityEngine;

public class EnemyAnubis : MonoBehaviour
{
    public float velocidadMovimiento = 3f;
    public float frecuenciaDisparo = 2f;
    public float velocidadBala = 10f;
    public int numBalasPorDisparo = 5; // balas en cada disparo
    public float anguloDispersión = 15f; // dispersión de las balas
    public GameObject bulletAnubis;
    public Transform puntoDisparo;
    public Transform weaponAnubis;

    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Disparar", 1f, 1f / frecuenciaDisparo);
    }

    private void Update()
    {
        MoverHaciaJugador();

        if (jugador != null && weaponAnubis != null)
        {
            Vector3 direccion = jugador.position - weaponAnubis.position;
            direccion.z = 0;
            weaponAnubis.up = direccion.normalized;
        }
    }

    private void MoverHaciaJugador()
    {
        if (jugador != null)
        {
            Vector3 direccion = jugador.position - transform.position;
            direccion.Normalize();
            transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);
        }
    }

    private void Disparar()
    {
        if (jugador != null && bulletAnubis != null && puntoDisparo != null)
        {
            for (int i = 0; i < numBalasPorDisparo; i++)
            {               
                float anguloActual = Random.Range(-anguloDispersión, anguloDispersión);
                Quaternion rotacionDisparo = Quaternion.AngleAxis(anguloActual, Vector3.forward);
                Vector2 direccionDisparo = rotacionDisparo * puntoDisparo.up;
                
                GameObject proyectil = Instantiate(bulletAnubis, puntoDisparo.position, rotacionDisparo);
                proyectil.GetComponent<Rigidbody2D>().velocity = direccionDisparo * velocidadBala;
            }
        }
    }
}
