using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindPlayerHP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().hp = this.GetComponent<Image>();
    }

}
