using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFer : MonoBehaviour
{
    public float speedMove = 5f;
    public Transform weapon;
    public int maxHealth = 100; 
    private int currentHealth; 
    private Vector3 initialPosition;

    private void Start()
    {
        currentHealth = maxHealth; 
        initialPosition = transform.position;  
    }

    private void Update()
    {
       
        float moveHori = Input.GetAxis("Horizontal");
        float moveVerti = Input.GetAxis("Vertical");

        
        Vector3 direcMove = new Vector3(moveHori, moveVerti, 0f);

        
        direcMove.Normalize();

        
        transform.Translate(direcMove * speedMove * Time.deltaTime);

        // Rotación del arma
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si la colisión es con un enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            TakeDamage(20);

            if (currentHealth <= 0)
            {
                Respawn();
            }
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    private void Respawn()
    {      
        transform.position = initialPosition;
        currentHealth = maxHealth;
    }
}
