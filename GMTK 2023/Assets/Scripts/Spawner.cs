using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] gameObjects;
    public float[] chance;
    public float min, max;
    public float cooldown;
    public float spawnChance;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        cooldown = Random.Range(min, max);
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
                GetComponent<AudioSource>().Play();
                GameObject zombie = Instantiate(gameObjects[i]);
                zombie.transform.position = transform.position;
                zombie.GetComponent<AIDestinationSetter>().target = player.transform;
                break;
            }

        }
        cooldown = Random.Range(min, max);
        StartCoroutine(Spawn());
    }
}
