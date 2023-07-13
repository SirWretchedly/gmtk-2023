using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOverTime : MonoBehaviour
{
    public int time = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
