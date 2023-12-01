using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hurtEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Vector3 initialPosition;
    private Rigidbody2D rb;
    private bool isKnockedBack = false;

    private void Start()
    {
        currentHealth = maxHealth;
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("balaPistola"))
        {
            if (!isKnockedBack)
            {
                TakeDamage(20);
                isKnockedBack = true;
            }
        } else if (other.CompareTag("balaEscopeta"))
        {
            if (!isKnockedBack)
            {
                TakeDamage(35);
                isKnockedBack = true;
            }
        } 
        else if (other.CompareTag("balaAR"))
        {
            if (!isKnockedBack)
            {
                TakeDamage(18);
                isKnockedBack = true;
            }
        }
        else if (other.CompareTag("balaLaser"))
        {
            if (!isKnockedBack)
            {
                TakeDamage(80);
                isKnockedBack = true;
            }
        }
        else if (other.CompareTag("hitMelee"))
        {
            if (!isKnockedBack)
            {
                TakeDamage(100);
                isKnockedBack = true;
            }
        }
    }

    private void Update()
    {
        if (isKnockedBack)
        {
            StartCoroutine(ResetKnockback());
        }
    }

    private IEnumerator ResetKnockback()
    {
        yield return new WaitForSeconds(1f);
        isKnockedBack = false;
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
