using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Vector3 initialPosition;
    public float knockbackForce = 10f;
    private Rigidbody2D rb;
    private bool isKnockedBack = false;

    public Slider barraVid;

    private void Start()
    {
        currentHealth = maxHealth;
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!isKnockedBack)
            {
                TakeHitAndKnockback(other.ClosestPoint(transform.position));
                TakeDamage(20);
                isKnockedBack = true;
                Invoke("ResetKnockback", 0.5f);
            }
        }
        else if (other.CompareTag("BalaEnemy"))
        {
            if (!isKnockedBack)
            {
                TakeHitAndKnockback(other.ClosestPoint(transform.position));
                TakeDamage(20);
                isKnockedBack = true;
                Invoke("ResetKnockback", 0.5f);
            }
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        barraVid.value = (float)currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Debug.Log("Murio");
        }
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

    private void ResetKnockback()
    {
        isKnockedBack = false;
        rb.velocity = Vector2.zero;
    }
}
