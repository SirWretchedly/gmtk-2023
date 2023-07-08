using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevHealthTime : MonoBehaviour
{
    private PlayerHealth player;
    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        timer = GameObject.FindWithTag("time").GetComponent<Timer>();
    }

    public void PerformReversal()
    {
        float auxT = timer.time;
        float auxH = player.currentHealth;
        timer.time = (auxH / player.maxHealth) * timer.maxTime;
        player.currentHealth = (int)(auxT / timer.maxTime * (float)player.maxHealth);
    }
}
