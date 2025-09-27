using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _startHealth;

    private int _minHealth = 0;

    public event Action Died;
    public event Action<int> TakedDamage;
    public event Action<int> Recovered;

    public int MaxHealth { get; private set; }
    public int Health { get; private set; }

    private void Start()
    {
        MaxHealth = _startHealth;
        Health = _startHealth;
    }

    public void TakeDamage(int damage) 
    {
        if (damage > 0)
        {
            Health -= damage;

            Health = Mathf.Clamp(Health, _minHealth, MaxHealth);
            TakedDamage.Invoke(Health);

            if (Health <= 0)
                Died.Invoke();
        }
    }

    public void Recovery(int recoverableHealth)
    {
        if (recoverableHealth > 0)
        {
            Health += recoverableHealth;

            Health = Mathf.Clamp(Health, _minHealth, MaxHealth);
            Recovered.Invoke(Health);
        }
    }
}
