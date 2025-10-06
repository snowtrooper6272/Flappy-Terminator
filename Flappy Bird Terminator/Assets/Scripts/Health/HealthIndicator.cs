using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour, IDamageable
{
    [SerializeField] private int _startHealth;
    
    private int _minHealth = 0;

    public event Action Died;
    public event Action<int> HealthChanged;
    public int MaxHealth { get; private set; }
    public int Health { get; private set; }

    private void Awake()
    {
        Health = _startHealth;
        MaxHealth = _startHealth;
    }

    public void Init() 
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        Health = Mathf.Clamp(Health, _minHealth, MaxHealth);

        HealthChanged?.Invoke(Health);

        if (Health == _minHealth)
            Died.Invoke();
    }
}
