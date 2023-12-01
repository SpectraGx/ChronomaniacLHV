using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float speedEnemy;
    [SerializeField] private Transform player;
    [SerializeField] private float minDistance;
    //private bool isFacingRight = true;

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

        if (Vector2.Distance(transform.position, player.position) > minDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;

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
        if (Vector2.Distance(transform.position, player.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speedEnemy * Time.deltaTime);
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
