using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _hunted;
    [SerializeField] private float _rotationRatio;

    private float _barrierUp = 3f;
    private float _barrierDown = -1.7f;
    private float _smoothing = 0.2f;

    private float _maxYPosition => _hunted.position.y + _barrierUp;
    private float _minYPosition => _hunted.position.y + _barrierDown;

    private void Start()
    {
        _rigidbody.gravityScale = _rotationRatio;
    }

    private void Update()
    {
        if (transform.position.y > _maxYPosition)
        {
            transform.position = new Vector2(transform.position.x, _maxYPosition);
            _rigidbody.velocity = new Vector2(0,_smoothing);
        }
        else if (transform.position.y < _minYPosition)
        {
            transform.position = new Vector2(transform.position.x, _minYPosition);
        }
    }

    public void Jump(int jumpForce) 
    {
        _rigidbody.velocity = new Vector2(0,0);
        transform.position = new Vector3(transform.position.x, _maxYPosition);
    }
}
