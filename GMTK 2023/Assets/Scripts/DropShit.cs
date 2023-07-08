using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShit : MonoBehaviour
{
    // Start is called before the first frame update

    public float probabilityWatermelon = 0.3f;
    public float probabilityHearth = 0.3f;
    private int result;

    public GameObject watermelon;
    public GameObject heart;

    private void Start()
    {
        result = GenerateNumber(probabilityWatermelon, probabilityHearth);
    }

    private int GenerateNumber(float probability1, float probability2)
    {
        float randomValue = Random.value;

        if (randomValue < probability1)
        {
            return 1;
        }
        else if (randomValue < probability1 + probability2)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }

    void Update()
    {
        
    }

    public void DropThing() {
        if (result == 1) {
            GameObject effect = Instantiate(watermelon, transform.position, Quaternion.identity);
        } else if (result == 2) {
            GameObject effect = Instantiate(heart, transform.position, Quaternion.identity);
        }
    }
}
