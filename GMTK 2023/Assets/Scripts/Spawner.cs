using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] gameObjects;
    public float[] chance;
    public float cooldown;
    public float spawnChance;

    private void Start()
    {
        cooldown = Random.Range(5, 15);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(cooldown);
        spawnChance = Random.Range(0, 100);
        for (int i = 0; i <= 3; i++)
        {
            if (spawnChance < chance[i])
            {
                GameObject zombie = Instantiate(gameObjects[i]);
                zombie.transform.position = transform.position;
                zombie.GetComponent<AIDestinationSetter>().target = player.transform;
            }

        }
        cooldown = Random.Range(5, 15);
        StartCoroutine(Spawn());
    }
}