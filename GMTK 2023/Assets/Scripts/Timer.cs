using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Image timeI;
    public int eventNo;
    public float[] evenTime;

    private float maxTime = 200;
    private float time;

    private void Start()
    {
        timeI = GetComponent<Image>();
        time = maxTime;
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeI.fillAmount = time/maxTime;
    }
}
