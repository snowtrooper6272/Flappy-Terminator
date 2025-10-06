using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObject<T> : MonoBehaviour where T : SpawnObjectSO
{
    [SerializeField] protected T _database;

    protected Coroutine DecreaseTimeOfBackPool;

    public event Action<SpawnObject<T>> Stored;

    private void OnDisable()
    {
        if(DecreaseTimeOfBackPool != null)
            StopCoroutine(DecreaseTimeOfBackPool);
    }

    virtual public void Init(Vector3 position, Quaternion quaternion, Vector2 moveDirection)
    {
        transform.position = position;
        transform.rotation = quaternion;
        _database.SetMoveDirection(moveDirection);
    }

    protected void StartLife()
    {
        DecreaseTimeOfBackPool = StartCoroutine(DecreasingTimeOfBackPool());
    }

    virtual protected IEnumerator DecreasingTimeOfBackPool()
    {
        float currentLifeDuration = 0;

        while (currentLifeDuration < _database.LifeDuration)
        {
            currentLifeDuration += Time.deltaTime;

            LifeUpdate(currentLifeDuration);

            yield return null;
        }

        LifeEnd();
    }

    virtual protected void LifeUpdate(float currentTime) { }

    virtual protected void LifeEnd()
    {
        Stored.Invoke(this);
    }
}
