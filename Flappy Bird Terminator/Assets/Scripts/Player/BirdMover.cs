using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Cursor _cursor;
    [SerializeField] private int _jumpForce;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        LookAt();
    }

    private void LookAt() 
    {
        Vector2 direction = _cursor.transform.position - transform.position;
        transform.right = direction;
    }

    public void Jump() 
    {
        _rigidbody2D.velocity = new Vector2(0, _jumpForce);
        _cursor.Jump(_jumpForce);
    }
}
