using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletOS _database;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private float _currentTime;

    public event Action<Bullet> Collided;

    private void OnEnable()
    {
        _currentTime = 0;
    }

    private void Update()
    {
        if (_currentTime >= _database.LifeTime) 
        {
            Collided?.Invoke(this);
        }

        _currentTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == _database.AttackLayer)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable iDamageable))
            {
                iDamageable.TakeDamage(_database.Damage);
                Collided.Invoke(this);
            }
        }
    }

    public void Storing() 
    {
        gameObject.SetActive(false);
    }

    public void Release(Vector3 direction, Quaternion rotation, Vector3 startPosition) 
    {
        gameObject.SetActive(true);
        transform.rotation = rotation;
        transform.position = startPosition;
        _rigidbody2D.velocity = direction * _database.Speed;
    }
}
