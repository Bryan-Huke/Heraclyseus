using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInstance
{

    public float damage { get; set; }
    public float knockback { get; set; }

    public DamageInstance(float d, float k)
    {
        damage = d;
        knockback = k;
    }

    public DamageInstance(float d) : this(d, 0) { }




}
