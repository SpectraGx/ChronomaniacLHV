using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D playerRB;
    private Vector2 moveInput;

    [Header("Sprint")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedBase;

    [SerializeField] private float speedExtra;
    [SerializeField] private float timeSprint;
    [SerializeField] private float timeBetSprint;

    private float currentTime;
    private float nextSprint;
    private bool canRun = true;
    private bool isRun = false;

    [Header("Dash")]
    [SerializeField] private float speedDash;
    [SerializeField] private float timeDash;
    private float gravityStart;
    private bool canDash = true;
    private bool canMove = true;

    [Header("Animations")]
    private string currentState;
    const string Player_Idle = "player_idle";
    const string Player_Up = "player_up";
    const string Player_Down = "player_down";
    const string Player_Run = "player_run";

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        currentTime = timeSprint;
        gravityStart = playerRB.gravityScale;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        //          CORRER          //

        if (Input.GetKeyDown(KeyCode.B) && canRun)
        {
            speed = speedExtra;
            isRun = true;
            Debug.Log("Sprint activado");
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            speed = speedBase;
            isRun = false;
            currentTime = timeSprint;
            Debug.Log("Sprint desactivado");
        }

        if (Mathf.Abs(playerRB.velocity.x) >= 0.1f && isRun)
        {
            if (isRun && currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else if (isRun)
            {
                speed = speedBase;
                isRun = false;
                canRun = false;
                nextSprint = Time.time + timeBetSprint;
            }
        }

        if (!isRun && currentTime <= timeSprint && Time.time >= nextSprint)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timeSprint)
            {
                canRun = true;
            }
        }

        //          DASH            //
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        //          CAMBIO DE ESTADO            //      

        if (moveInput.magnitude > 0)
        {
            if (moveInput.y > 0)
            {
                ChangeAnimationState(Player_Up);
            }
            else if (moveInput.y < 0)
            {
                ChangeAnimationState(Player_Down);
            }
            else if (moveInput.x<0)
            {
                transform.localScale = new Vector2(1,1);
                ChangeAnimationState(Player_Run);
            }
            else {
                transform.localScale = new Vector2(-1,1);
                ChangeAnimationState(Player_Run);
            }
        }
        else
        {
            ChangeAnimationState(Player_Idle);
        }

        /*
        if (moveInput.x<0){
            transform.localScale = new Vector2(-1,1);
            ChangeAnimationState(Player_Run);
        }
        else if (moveInput.x>0){
            transform.localScale = new Vector2(1,1);
            ChangeAnimationState(Player_Run);
        }
        else {
            ChangeAnimationState(Player_Idle);
        }

        if (moveInput.y>0){
            ChangeAnimationState(Player_Up);
        }
        else if (moveInput.y<0){
            ChangeAnimationState(Player_Down);
        }
        else {
            ChangeAnimationState(Player_Idle);
        }*/
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 moveDirection = moveInput.normalized;
            playerRB.MovePosition(playerRB.position + moveDirection * speed * Time.fixedDeltaTime);
        }


    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    private IEnumerator Dash()
    {
        canMove = false;
        canDash = false;
        playerRB.gravityScale = 0;
        Vector2 dashDirection = moveInput.normalized;
        playerRB.velocity = dashDirection * speedDash;
        yield return new WaitForSeconds(timeDash);
        canMove = true;
        canDash = true;
        playerRB.gravityScale = gravityStart;
        playerRB.velocity = Vector2.zero;
    }
}
