using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevUpDown : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PerformReversal()
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z * -1);
        player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y + 180, player.transform.rotation.eulerAngles.z + 180);
    }
}
