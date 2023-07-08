using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public RoleReverseTime reverse;
    public float[] evenTime;

    private Image timeI;
    private int index = 0;
    public float maxTime = 200;
    private float time;

    private void Start()
    {
        timeI = GetComponent<Image>();
        time = maxTime;
    }

    void Update()
    {
        if(index < evenTime.Length)
        {
            evenTime[index] -= Time.deltaTime;
            if (evenTime[index] <= 0)
            {
                reverse.ActivatePanel();
                index++;
            }
        }
        time -= Time.deltaTime;
        timeI.fillAmount = time/maxTime;
    }
}
