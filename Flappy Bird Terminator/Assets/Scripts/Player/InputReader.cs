using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _shootKey;
    [SerializeField] private KeyCode _jumpKey;
    
    private int _recharge = 1;
    private float _currentRecharge;

    public event Action Shooted;
    public event Action Jumped;

    private void Update()
    {
        _currentRecharge += Time.deltaTime;

        if (Input.GetKeyDown(_shootKey) && _currentRecharge >= _recharge)
        {
            Shooted.Invoke();
            _currentRecharge = 0;
        }

        if (Input.GetKeyDown(_jumpKey))
            Jumped.Invoke();
    }
}
