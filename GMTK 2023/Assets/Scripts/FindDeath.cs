using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindDeath : MonoBehaviour
{
    void Start()
    {
        int death = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().deathcount;
        if (death == 0)
        {
            this.GetComponent<TextMeshProUGUI>().text = ("wow, you really didn't die");
        }
        else
        this.GetComponent<TextMeshProUGUI>().text = "(except those " + death + " times)";
    }
}
