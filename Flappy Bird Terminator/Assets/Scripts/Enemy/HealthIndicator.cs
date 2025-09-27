using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    private int _maxHealth;
    private int _minHealth;

    public event Action Died;

    private void Awake()
    {
        _maxHealth = _health;
    }

    public void Init() 
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        Mathf.Clamp(_health, _minHealth, _maxHealth);

        if (_health == _minHealth)
            Died.Invoke();
    }
}
