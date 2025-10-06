using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SpawnObject<EnemyConfig>
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Mover _mover;
    [SerializeField] private HealthIndicator _healthIndicator;

    private float _lastShootTime = 0;

    private void OnEnable()
    {
        _healthIndicator.Died += LifeEnd;
    }

    private void OnDisable()
    {
        _healthIndicator.Died -= LifeEnd;
    }

    private void Start()
    {
        StartLife();
    }

    protected override void LifeUpdate(float currentTime)
    {
        if (currentTime - _lastShootTime >= _database.DelayShooting) 
        {
            _shooter.Shoot();
            _lastShootTime = currentTime;
        }
    }

    public override void Init(Vector3 position, Quaternion quaternion, Vector2 direction)
    {
        base.Init(position, quaternion, direction);

        _mover.SetMovement(_database.Speed, direction);
        _healthIndicator.Init();
    }
}
