using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {           
            Shotgun Shotgun = target.GetComponent<Shotgun>();

            if (Shotgun == null)
            {
                target.gameObject.AddComponent<Shotgun>();
                Debug.Log("Se ha agregado el script Shotgun al jugador.");
            }
           
            if (Shotgun != null)
            {
                Shotgun.enabled = true;
            }
          
        }
    }

    void Start()
    {
        // Inicialización si es necesario
    }

    void Update()
    {
        // Lógica de actualización si es necesario
    }
}
