using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomTarget : MonoBehaviour
{
    public Transform dad;

    private Vector2 limit = new Vector2(12.5f, 6.5f);

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, dad.position) < 2)
            transform.position = new Vector2(Random.Range(-1 * limit.x, limit.x), Random.Range(-1 * limit.y, limit.y));
    }
}
