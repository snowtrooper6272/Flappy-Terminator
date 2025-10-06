using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SOBullet", menuName = "Bullet/Create new bullet", order = 51)]
public class BulletConfig : SpawnObjectSO
{
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _attackLayer;

    public int Damage => _damage;
    public LayerMask AttackLayer => _attackLayer;
}
