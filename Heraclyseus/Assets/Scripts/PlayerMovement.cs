using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerControls playerControls;

    public Transform attackPos;

    //player stats
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float dashSpeed = 50f;
    [SerializeField]
    private float attackAOE = 20f;

    //timer to prevent multiple actions from happening at once
    private float actionTimer = 0f;
    [SerializeField]
    private float attackDuration = 0.3f;
    [SerializeField]
    private float specialDuration = 0.7f;
    [SerializeField]
    private float pushDuration = 0.3f;
    [SerializeField]
    private float dashDuration = 0.2f;

    //cooldowns for moves that cannot be spammed
    [SerializeField]
    private float specialCooldownLength = 2f;
    [SerializeField]
    private float dashCooldownLength = 1f;
    private float specialCooldownTimer = 0f;
    private float dashCooldownTimer = 0f;

    //damage and knockback stats
    [SerializeField]
    private float attackDamage = 5;
    [SerializeField]
    private float attackKnockback = 5;
    [SerializeField]
    private float specialDamage = 20;
    [SerializeField]
    private float specialKnockback = 2;
    [SerializeField]
    private float pushDamage = 1;
    [SerializeField]
    private float pushKnockback = 20;



    //other variables
    private bool canMove = true;


    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        HandleMovement();
        HandleAttacks();
        HandleTimers();


    }


    /// <summary>
    /// Takes care of player movement including dashing
    /// </summary>
    private void HandleMovement()
    {
        if (canMove)
        {
            Vector2 movement = playerControls.Combat.Move.ReadValue<Vector2>();
            Vector3 currentPosition = transform.position;

            //I am currently treating the dash as a teleport forward. I believe this will work fine
            //but will need some work to look good and it also needs a few Iframes to avoid jankyness.
            float dashMultiplier = 1;

            if (playerControls.Combat.Dash.triggered && actionTimer <= 0 && dashCooldownTimer <= 0)
            {
                Debug.Log("Dash");
                dashMultiplier = dashSpeed;

                actionTimer = dashDuration;
                dashCooldownTimer = dashCooldownLength;
            }


            currentPosition.x += movement.x * moveSpeed * dashMultiplier * Time.deltaTime;
            currentPosition.y += movement.y * moveSpeed * dashMultiplier * Time.deltaTime;

            transform.position = currentPosition;

        }
    }

    /// <summary>
    /// Takes care of reading attack inputs and calling the correct method
    /// </summary>
    private void HandleAttacks()
    {
        if(actionTimer <= 0)
        {
            if (playerControls.Combat.Special.triggered)
            {
                Special();
            }
            else if (playerControls.Combat.Attack.triggered)
            {
                Attack();
            }
            else if (playerControls.Combat.Push.triggered)
            {
                Push();
            }

        }

    }

    /// <summary>
    /// Takes care of decrementing any of the active cooldown timers
    /// </summary>
    private void HandleTimers()
    {
        if(actionTimer > 0)
        {
            actionTimer -= Time.deltaTime;
        }

        if(dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        if(specialCooldownTimer > 0)
        {
            specialCooldownTimer -= Time.deltaTime;
        }

    }


    /// <summary>
    /// 
    /// </summary>
    private void Attack()
    {

        Debug.Log("attack");

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackAOE);
        //loop and damage enemies in the array
        foreach(Collider2D enemyCollider in enemiesToDamage)
        {
            if (enemyCollider.Equals(gameObject.GetComponentInChildren<BoxCollider2D>()))
            {
                continue;
            }

            Debug.Log("Damaging");
            enemyCollider.gameObject.GetComponent<Enemy>().TakeDamage(new DamageInstance(attackDamage, attackKnockback, new Vector2(0, 0), gameObject));
        }


        actionTimer = attackDuration;


    }

    /// <summary>
    /// 
    /// </summary>
    private void Special()
    {
        if(specialCooldownTimer <= 0)
        {
            Debug.Log("special");

            //special attack here


            actionTimer = specialDuration;
            specialCooldownTimer = specialCooldownLength;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Push()
    {
        Debug.Log("push");

        //push attack here


        actionTimer = pushDuration;
    }

    //drawing hitboxes to help visualize them during development
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackAOE);
    }

}
