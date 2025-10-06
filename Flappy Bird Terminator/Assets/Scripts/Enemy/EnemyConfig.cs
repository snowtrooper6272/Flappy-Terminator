using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SOEnemy", menuName = "Enemy/Create new enemy", order = 51)]
public class EnemyConfig : SpawnObjectSO
{
    [SerializeField] private float _delayShooting;

    public float DelayShooting => _delayShooting;
}
