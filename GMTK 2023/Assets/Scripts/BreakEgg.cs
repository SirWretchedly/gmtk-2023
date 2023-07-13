using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakEgg : MonoBehaviour
{
    public bool enable = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enable && collision.tag == "bullet")
        {
            Instantiate(collision.GetComponent<BulletMovement>().egg).transform.position = collision.transform.position;
            Destroy(collision.gameObject);
        }
    }
}
