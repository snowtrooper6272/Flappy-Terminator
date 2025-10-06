using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<EnemyConfig>
{
    [SerializeField] private SpawnArea _area;
    [SerializeField] private float _intervalSpawn;

    private Coroutine _spawning;

    private void Start()
    {
        _spawning = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        if(_spawning != null)
            StopCoroutine(_spawning);
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds delay = new WaitForSeconds(_intervalSpawn);
        bool isNeedSpawn = true;

        while (isNeedSpawn)
        {
            SpawnObject<EnemyConfig> spawnedObj = Spawn();

            if(spawnedObj != null)
                spawnedObj.Init(_area.GetSpawnPosition(), spawnedObj.transform.rotation, Vector2.left);

            yield return delay;
        }
    }
}
