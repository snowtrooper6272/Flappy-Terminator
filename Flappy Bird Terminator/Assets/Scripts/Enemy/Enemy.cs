using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO _database;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private HealthIndicator _healthIndicator;

    private float _currentLifeTime;
    private Coroutine _shooting;

    public event Action<Enemy> Stored;

    private void OnEnable()
    {
        _healthIndicator.Died += Die;
    }

    private void OnDisable()
    {
        if(_shooting != null)
            StopCoroutine(_shooting);

        _healthIndicator.Died -= Die;
    }

    private void Update()
    {
        if (_currentLifeTime >= _database.LifeTime) 
        {
            Stored.Invoke(this);
        }

        _currentLifeTime += Time.deltaTime;
    }

    public void Init(Vector3 position) 
    {
        transform.position = position;
        _currentLifeTime = 0;
        _healthIndicator.Init();
        _shooting = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting() 
    {
        bool isShooting = true;
        WaitForSeconds delay = new WaitForSeconds(_database.DelayShooting);

        while (isShooting) 
        {
            _shooter.Shoot();

            yield return delay;
        }
    }

    public void Die() 
    {
        Stored.Invoke(this);
    }
}
