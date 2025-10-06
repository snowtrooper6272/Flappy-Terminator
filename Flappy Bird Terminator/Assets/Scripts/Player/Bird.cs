using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(HealthIndicator))]
public class Bird : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private BirdMover _mover;

    private InputReader _inputReader;
    private HealthIndicator _healthIndicator;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _healthIndicator = GetComponent<HealthIndicator>();
    }

    private void OnEnable()
    {
        _healthIndicator.Died += Die;
        _inputReader.Shooted += _shooter.Shoot;
        _inputReader.Jumped += _mover.Jump;
    }

    private void OnDisable()
    {
        _healthIndicator.Died -= Die;
        _inputReader.Shooted -= _shooter.Shoot;
        _inputReader.Jumped -= _mover.Jump;
    }

    private void Die() 
    {
        gameObject.SetActive(false);
    }
}
