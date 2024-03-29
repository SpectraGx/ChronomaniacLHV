using UnityEngine;

public class EnemyMomiaYOjo : MonoBehaviour
{
    public float velocidadMovimiento = 3f;
    public float frecuenciaDisparo = 2f;
    public float velocidadBala = 10f;
    public GameObject bulletMomiaPrefab;
    public Transform puntoDisparo;
    public Transform weaponMomia;

    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Disparar", 1f, 1f / frecuenciaDisparo);
    }

    private void Update()
    {
        MoverHaciaJugador();

        if (jugador != null && weaponMomia != null)
        {
            Vector3 direccion = jugador.position - weaponMomia.position;
            direccion.z = 0;
            weaponMomia.up = direccion.normalized;
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
        if (jugador != null && bulletMomiaPrefab != null && puntoDisparo != null)
        {
            GameObject proyectil = Instantiate(bulletMomiaPrefab, puntoDisparo.position, Quaternion.identity);
            Vector2 direccion = (jugador.position - puntoDisparo.position).normalized;
            proyectil.GetComponent<Rigidbody2D>().velocity = direccion * velocidadBala;
        }
    }
}
