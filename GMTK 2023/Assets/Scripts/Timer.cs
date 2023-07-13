using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Canvas canvas;

    public RoleReverseTime[] reverse;
    public float[] evenTime;

    public int index = -1;
    private Image timeI;
    public float maxTime = 200f;
    public float time;
    public bool a = false;

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
                print(index);
                if(index >= 0 && index <= reverse.Length)
                    reverse[index].ActivatePanel();
                if(!a)
                {
                    a = true;
                    index++;
                    GetComponent<AudioSource>().Play();
                    StartCoroutine(Index());
                }
            }
        }
        time -= Time.deltaTime;
        timeI.fillAmount = time / maxTime;

        if (time <= 0)
        {
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
        }
    }

    IEnumerator Index()
    {
        yield return new WaitForSeconds(0.4f);
        a = false;
    }
}
