using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;

    private Spawner<Bullet> _spawner;

    private void Awake()
    {
        _spawner = new Spawner<Bullet>(_prefab, 5);
    }

    private void OnDisable()
    {
        foreach (var bullet in _spawner.Pool) 
        {
            bullet.Collided -= Charge;
        }
    }
    public void Charge(Bullet bullet) 
    {
        bullet.Collided -= Charge;
        bullet.Storing();
        _spawner.Storing(bullet);
    }

    public void Shoot()
    {
        Bullet bullet = _spawner.Realese();

        if (bullet != null)
        {
            bullet.Collided += Charge;
            bullet.Release(transform.right, Quaternion.LookRotation(transform.forward, transform.up), transform.position);
        }
    }
}
