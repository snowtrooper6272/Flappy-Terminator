using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObjectSO : ScriptableObject
{
    [SerializeField] private int _lifeDuration;
    [SerializeField] private int _speed;

    public Vector2 MoveDirection { get; private set; }
    public int LifeDuration => _lifeDuration;
    public int Speed => _speed;

    public void SetMoveDirection(Vector2 moveDirection) 
    {
        MoveDirection = moveDirection;
    }
}