using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerControls playerControls;

    private float moveSpeed = 10f;
    private float dashSpeed = 50f;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        HandleMovement();
        HandleAttacks();

    }

    private void HandleMovement()
    { 
        Vector2 movement = playerControls.Combat.Move.ReadValue<Vector2>();
        Vector3 currentPosition = transform.position;

        float dashMultiplier = 1;

        if (playerControls.Combat.Dash.triggered)
        {
            Debug.Log("Dash");
            dashMultiplier = dashSpeed;
        }

        currentPosition.x += movement.x * moveSpeed * dashMultiplier * Time.deltaTime;
        currentPosition.y += movement.y * moveSpeed * dashMultiplier * Time.deltaTime;

        transform.position = currentPosition;
    }

    private void HandleAttacks()
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

    private void Attack()
    {
        Debug.Log("attack");
    }

    private void Special()
    {
        Debug.Log("special");
    }

    private void Push()
    {
        Debug.Log("push");
    }


}
