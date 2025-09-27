using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter), typeof(PlayerHealth))]
public class Bird : MonoBehaviour
{
    [SerializeField] private KeyCode _shootKey;
    [SerializeField] private float _shootDelay;

    private Shooter _shooter;
    private PlayerHealth _healthIndicator;
    private float _currentShootTime;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
        _healthIndicator = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _healthIndicator.Died += Die;
    }

    private void OnDisable()
    {
        _healthIndicator.Died -= Die;
    }

    private void Update()
    {
        if (_currentShootTime >= _shootDelay) 
        {
            if (Input.GetKeyDown(_shootKey))
            {
                _currentShootTime = 0;

                _shooter.Shoot();
            }
        }

        _currentShootTime += Time.deltaTime;
    }

    private void Die() 
    {
        gameObject.SetActive(false);
    }
}
