using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInstance
{

    public float damage { get; set; }
    public float knockback { get; set; }

    public Vector2 knockbackDir;

    public GameObject attacker;

    public DamageInstance(float d, float k, Vector2 kd, GameObject a)
    {
        damage = d;
        knockback = k;
        knockbackDir = kd;
        attacker = a;
    }

    public DamageInstance(float d) : this(d, 0, new Vector2(0, 0), null) { }




}
