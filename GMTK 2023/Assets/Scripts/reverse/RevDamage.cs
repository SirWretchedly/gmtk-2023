using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevDamage : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PerformReversal()
    {
        player.GetComponent<PlayerHealth>().draining = true;
    }
}
