using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : SpawnObjectSO
{
    [SerializeField] protected SpawnObject<T> SpawnPrefab;
    [SerializeField] private int _capacity;

    private Pool<SpawnObject<T>> _pool;

    private void OnEnable()
    {
        _pool = new Pool<SpawnObject<T>>();

        _pool.Init(_capacity, SpawnPrefab);
    }

    private void OnDisable()
    {
        foreach (var content in _pool.GetReleasedStorage()) 
        {
            content.Stored -= Storing;
        }
    }

    protected SpawnObject<T> Spawn() 
    {
        SpawnObject<T> spawnObject = _pool.Release();

        if(spawnObject != null)
            spawnObject.Stored += Storing;

        return spawnObject;
    }

    private void Storing(SpawnObject<T> storedObj) 
    {
        storedObj.Stored -= Storing;
        _pool.Storing(storedObj);
    }
}
