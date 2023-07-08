using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakEgg : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Instantiate(collision.GetComponent<BulletMovement>().egg).transform.position = transform.position;
            Destroy(collision.gameObject);
        }
    }
}
