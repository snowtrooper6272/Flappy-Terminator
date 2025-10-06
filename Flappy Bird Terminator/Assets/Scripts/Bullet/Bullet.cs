using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : SpawnObject<BulletConfig>
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        StartLife();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == _database.AttackLayer)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable iDamageable))
            {
                iDamageable.TakeDamage(_database.Damage);
                LifeEnd();
            }
        }
    }

    public override void Init(Vector3 position, Quaternion quaternion, Vector2 direction)
    {
        base.Init(position, quaternion, direction);

        _rigidbody2D.velocity = direction * _database.Speed;
    }
}
