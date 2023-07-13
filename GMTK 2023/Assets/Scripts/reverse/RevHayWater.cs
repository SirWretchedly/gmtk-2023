using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevHayWater : MonoBehaviour
{
    private GameObject hay;
    private GameObject w;
    // Start is called before the first frame update
    void Start()
    {
        hay = GameObject.FindWithTag("hay");
        w = GameObject.FindWithTag("water");
    }

    // Update is called once per frame
    public void PerformReversal()
    {
        if(w.GetComponent<BreakEgg>().enable == false)
        w.GetComponent<BreakEgg>().enable = true;
        else
            w.GetComponent<BreakEgg>().enable = false;

        if (hay.GetComponent<BreakEgg>().enable == false)
            hay.GetComponent<BreakEgg>().enable = true;
        else
            hay.GetComponent<BreakEgg>().enable = false;
    }
}
