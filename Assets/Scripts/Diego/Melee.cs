using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float damageRadius = 2f;
    public LayerMask enemyLayer;
    public float attackCooldown = 0.5f;

    private float lastAttackTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime >= attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, damageRadius, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Aquí puedes agregar la lógica para dañar al enemigo, por ejemplo:
            // enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}



