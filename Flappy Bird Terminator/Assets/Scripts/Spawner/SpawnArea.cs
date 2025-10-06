using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public Vector3 GetSpawnPosition() 
    {
        return new Vector2(Random.Range(transform.position.x - transform.localScale.x/2, transform.position.x + transform.localScale.x / 2),
                           Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2));
    }
}
