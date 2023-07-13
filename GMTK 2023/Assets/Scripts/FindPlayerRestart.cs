using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerRestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().gameOver = this.GetComponentInChildren<Canvas>(true);
    }

}
