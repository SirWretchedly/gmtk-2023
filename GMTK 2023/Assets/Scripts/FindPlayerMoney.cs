using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindPlayerMoney : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMoney>().counterText = this.GetComponent<TextMeshProUGUI>();
    }
}
