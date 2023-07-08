using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    public GameObject fire;
    public SpriteRenderer lightning;
    float delay;
    void Start()
    {
        delay = Random.Range(5, 15);
        StartCoroutine(Lightning());
    }

    // Update is called once per frame


    IEnumerator Lightning()
    {
        yield return new WaitForSeconds(delay);
        lightning.enabled = true;
        yield return new WaitForSeconds(0.2f);
        Instantiate(fire).transform.position = transform.position;
       lightning.enabled = false;
        delay = Random.Range(3, 9);
        StartCoroutine(Lightning());
    }
}
