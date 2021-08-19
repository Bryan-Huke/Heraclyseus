using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float maxHealth = 50;
    private float currentHealth;

    [SerializeField]
    private float attackDamage = 3;
    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private float attackCooldown = 1;

    public GameObject player1;
    public GameObject player2;
    private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //player1 = 



        //change this later
        target = player1;
    }



    void FixedUpdate()
    {
        Move();

    }


    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    


    public bool TakeDamage(DamageInstance di)
    {
        Debug.Log("got hit");

        //knockback first

        currentHealth -= di.damage;
        if (currentHealth <= 0)
        {
            Kill();
            return true;
        }
        return false;
    }

    private void Kill()
    {
        //death stuffs

        Destroy(gameObject);
    }

}
