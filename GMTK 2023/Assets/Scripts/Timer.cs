using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Canvas canvas;

    public RoleReverseTime reverse;
    public float[] evenTime;

    private Image timeI;
    public float maxTime = 200f;
    public float time;

    private void Start()
    {
        Time.timeScale = 1;
        timeI = GetComponent<Image>();
        time = maxTime;
    }

    void Update()
    {
        foreach (float et in evenTime)
        {
            if (et <= maxTime - time && et >= maxTime - time - 0.3)
            {
                reverse.ActivatePanel();
            }
        }
        time -= Time.deltaTime;
        timeI.fillAmount = time / maxTime;

        if(time <= 0)
        {
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
        }
    }
}
