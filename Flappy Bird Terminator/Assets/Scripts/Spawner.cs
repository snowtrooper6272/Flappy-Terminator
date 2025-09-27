using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<Creature> : MonoBehaviour where Creature : MonoBehaviour 
{
    [SerializeField] private int _maxCountPrefabs = 10;
    [SerializeField] private Creature _prefab;

    public List<Creature> Pool { get; private set; } = new List<Creature>();
    public List<Creature> ActiveUnits { get; private set; } = new List<Creature>();

    public Spawner(Creature prefab, int maxCountPrefabs = 10) 
    {
        _prefab = prefab;
        _maxCountPrefabs = maxCountPrefabs;

        for (int i = 0; i < _maxCountPrefabs; i++)
        {
            Creature creature = Instantiate(_prefab);
            creature.gameObject.SetActive(false);
            Pool.Add(creature);
        }
    }

    public Creature Realese() 
    {
        if (Pool.Count == 0)
            return null;

        Creature realesedCreature = Pool[Pool.Count - 1];
        Pool.Remove(realesedCreature);
        ActiveUnits.Add(realesedCreature);

        realesedCreature.gameObject.SetActive(true);
        return realesedCreature;
    }

    public void Storing(Creature storingCreature)
    {
        storingCreature.gameObject.SetActive(false);
        Pool.Add(storingCreature);
        ActiveUnits.Remove(storingCreature);
    }
}
