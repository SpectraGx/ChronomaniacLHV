using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float speedEnemy;
    [SerializeField] private float minDistance;

    [Header("Animations")]
    private string currentState;
    const string Enemy_Up = "enemy_up";
    const string Enemy_Down = "enemy_down";
    const string Enemy_Run = "enemy_run";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Follow();

        GameObject player = GameObject.FindGameObjectWithTag("PJ");

        if (player != null && Vector2.Distance(transform.position, player.transform.position) > minDistance)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;

            if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
            {
                if (direction.y > 0)
                {
                    ChangeAnimationState(Enemy_Up);
                }
                else
                {
                    ChangeAnimationState(Enemy_Down);
                }
            }
            else
            {
                if (direction.x > 0)
                {
                    transform.localScale = new Vector2(-1, 1);
                }
                else
                {
                    transform.localScale = new Vector2(1, 1);
                }
                ChangeAnimationState(Enemy_Run);
            }
        }
    }

    private void Follow()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PJ");

        if (player != null && Vector2.Distance(transform.position, player.transform.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speedEnemy * Time.deltaTime);
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
