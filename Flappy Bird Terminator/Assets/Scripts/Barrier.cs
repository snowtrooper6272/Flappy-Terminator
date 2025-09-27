using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private PlayerHealth _intruder;
    private float _currentTime;

    private void Start()
    {
        _currentTime = _delay;
    }

    private void Update()
    {
        if (_intruder == null)
            return;

        if (_currentTime >= _delay) 
        {
            _currentTime = 0;
            _intruder.TakeDamage(_damage);
        }

        _currentTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            _intruder = playerHealth;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            _intruder = null;
        }
    }
}
