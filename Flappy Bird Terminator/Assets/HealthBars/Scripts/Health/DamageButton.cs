using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : ButtonHealth
{
    [SerializeField] private int _damage;

    protected override void ChangeHealth()
    {
        PlayerHealth.TakeDamage(_damage);
    }
}
