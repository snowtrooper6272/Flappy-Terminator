using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected HealthIndicator HealthIndicator;

    private void OnEnable()
    {
        HealthIndicator.HealthChanged += ChangeHealth;
    }

    private void OnDisable()
    {
        HealthIndicator.HealthChanged -= ChangeHealth;
    }

    virtual protected void ChangeHealth(int newHealth) { }
}
