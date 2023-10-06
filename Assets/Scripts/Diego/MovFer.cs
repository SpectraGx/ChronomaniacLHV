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
    public float knockbackForce = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        currentHealth = maxHealth; 
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
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
            TakeHitAndKnockback(collision.contacts[0].point);
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

    private void TakeHitAndKnockback(Vector2 hitPoint)
    {
        ApplyKnockback(hitPoint);
    }

    private void ApplyKnockback(Vector2 hitPoint)
    {
        Vector2 knockbackDirection = ((Vector2)transform.position - hitPoint).normalized;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }
}
