using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool invincible = false;
    public int invincibilityTime;
    Renderer rend;
    Color c;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("YESSSS " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("enemy") && !invincible)
        {

            FollowPlayer enemy = collision.gameObject.GetComponent<FollowPlayer>();

            if (enemy != null)
            {
                int damage = enemy.damageToPlayer;
                currentHealth -= damage;

                if (currentHealth <= 0)
                {
                    Destroy(gameObject);
                }
            }
            StartCoroutine("GetInv");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fire") && !invincible)
        {
            currentHealth -= 10;
            Destroy(collision.gameObject);
            StartCoroutine("GetInv");
        }
        else if (collision.gameObject.CompareTag("health") && currentHealth < maxHealth)
        {
            currentHealth += 10;
            if(currentHealth > maxHealth) { currentHealth = maxHealth; }
            Destroy(collision.gameObject);
        }
    }

    IEnumerator GetInv() {
        c.a = 0.5f;
        rend.material.color = c;
        invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
        c.a = 1f;
        rend.material.color = c;
    }
}
