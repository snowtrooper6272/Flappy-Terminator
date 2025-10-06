using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Spawner<BulletConfig>
{
    public void Shoot() 
    {
        SpawnObject<BulletConfig> spawnBullet = Spawn();

        if (spawnBullet != null)
            spawnBullet.Init(transform.position, transform.rotation, transform.right);
    }
}