using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevFireHeart : MonoBehaviour
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
        if (player.GetComponent<PlayerHealth>().fire_heart == false)
        {
            player.GetComponent<PlayerHealth>().fire_heart = true;
        }
        else
            player.GetComponent<PlayerHealth>().fire_heart = false;

    }
}
