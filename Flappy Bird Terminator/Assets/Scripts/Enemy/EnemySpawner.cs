using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private SpawnArea _area;
    [SerializeField] private int _capacity;
    [SerializeField] private float _delay;

    private Spawner<Enemy> _spawner;
    private Coroutine _spawning;

    private void OnEnable()
    {
        _spawner = new Spawner<Enemy>(_prefab, _capacity);
        _spawning = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawning);

        foreach (var enemy in _spawner.ActiveUnits) 
        {
            enemy.Stored -= Storing;
        }
    }

    private IEnumerator Spawning() 
    {
        bool _isSpawning = true;
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (_isSpawning) 
        {
            Enemy enemy = _spawner.Realese();

            if (enemy != null)
            {
                enemy.Init(_area.GetSpawnPosition());
                enemy.Stored += Storing;
            }

            yield return delay;
        }
    }

    private void Storing(Enemy enemy) 
    {
        enemy.Stored -= Storing;
        _spawner.Storing(enemy);
    }
}
