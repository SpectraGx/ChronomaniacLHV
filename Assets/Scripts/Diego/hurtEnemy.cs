using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;

    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("balaPlayer"))
        {
            TomarDanio(20);
            Destroy(other.gameObject);
        }
    }

    void TomarDanio(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            vidaActual = 0;
            DestruirEnemigo();
        }
    }

    void DestruirEnemigo()
    {
        Destroy(gameObject);
    }
}
