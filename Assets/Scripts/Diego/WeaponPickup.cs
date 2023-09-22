using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private bool isPickedUp = false;
    private GameObject weapon; //referencia al script del arma

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;

            weapon.GetComponent<Pistol>();
        }
    }

    private void Start()
    {
        weapon = GetComponentInChildren<Pistol>().gameObject;
    }

    private void Update()
    {
        if (isPickedUp && Input.GetKeyDown(KeyCode.G))
        {
            isPickedUp = false;

            weapon.GetComponent<Pistol>(); 

        }
    }
}
