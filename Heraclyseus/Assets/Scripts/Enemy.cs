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


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }



    // Update is called once per frame
    void Update()
    {
        
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
