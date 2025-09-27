using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SOBullet", menuName = "Bullet/Create new bullet", order = 51)]
public class BulletOS : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _attackLayer;

    public float Speed => _speed;
    public float LifeTime => _lifeTime;
    public int Damage => _damage;
    public LayerMask AttackLayer => _attackLayer;
}
