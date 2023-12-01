using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speedBullet;
    [SerializeField] private float timeBullet;
    private Action<EnemyBullet> desactivateAction;

    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
        rb = GetComponent<Rigidbody2D>();
        if (player != null)
        {
            ShootBullet();
        }
        else
        {
            Debug.LogError("El jugador no esta");
        }
    }

    private void ShootBullet()
    {
        if (player != null)
        {
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            rb.velocity = directionToPlayer * speedBullet;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(DesactivateTime());
        ShootBullet();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PJ"))
        {
            desactivateAction(this);
        }
    }

    private IEnumerator DesactivateTime()
    {
        yield return new WaitForSeconds(timeBullet);
        desactivateAction(this);
    }

    public void DesactivateBala(Action<EnemyBullet> desactivateActionParameter)
    {
        desactivateAction = desactivateActionParameter;
    }
}
