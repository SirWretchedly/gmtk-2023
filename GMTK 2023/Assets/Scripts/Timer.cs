using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public RoleReverseTime reverse;
    public float[] evenTime;

    private Image timeI;
    public float maxTime = 200f;
    public float time;

    private void Start()
    {
        timeI = GetComponent<Image>();
        time = maxTime;
    }

    void Update()
    {
        foreach (float et in evenTime)
        {
            if(et <= maxTime - time && et >= maxTime - time - 0.3)
            {
                reverse.ActivatePanel();
            }
        }
        time -= Time.deltaTime;
        timeI.fillAmount = time/maxTime;
    }
}
