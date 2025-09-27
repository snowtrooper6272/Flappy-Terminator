using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SOEnemy", menuName = "Enemy/Create new enemy", order = 51)]
public class EnemySO : ScriptableObject
{
    [SerializeField] private int _lifeTime;
    [SerializeField] private int _delayShooting;
    [SerializeField] private HealthIndicator _healthIndicator;

    public int DelayShooting => _delayShooting;
    public int LifeTime => _lifeTime;

    public void TakeDamage(int damage) 
    {
        _healthIndicator.TakeDamage(damage);
    }
}
