using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invis : MonoBehaviour
{
    // Start is called before the first frame update
    public void aaa()
    {
        if (GetComponent<Image>().enabled)
        {
            GetComponent<Image>().enabled = false;
        }
        else
        {
            GetComponent<Image>().enabled = true;
        }
    }
}
