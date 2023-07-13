using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int deathcount = 0;
    public bool draining = false;
    public Canvas gameOver;
    public Image hp;
    public int maxHealth = 100;
    public float currentHealth;
    private bool invincible = false;
    public int invincibilityTime;
    public bool fire_heart = false;
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
        hp.fillAmount = (float)currentHealth / (float)maxHealth;

        if(currentHealth <= 0)
        {
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("YESSSS " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("enemy") && !invincible)
        {

            FollowPlayer enemy = collision.gameObject.GetComponent<FollowPlayer>();

            if (!draining)
            {
                if (enemy != null)
                {
                    int damage = enemy.damageToPlayer;
                    currentHealth -= damage;
                    DamageSound();
                    deathcount++;
                }
                else
                {
                    Bucket bucket = collision.gameObject.GetComponent<Bucket>();
                    if (bucket != null)
                    {
                        int damage = bucket.damageToPlayer;
                        currentHealth -= damage;
                        DamageSound();
                        deathcount++;
                    }
                }
                StartCoroutine("GetInv");
            }
            else
            {
                currentHealth += 5;
                if (currentHealth > maxHealth) { currentHealth = maxHealth; }
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fire"))
        {
            if (!fire_heart && !invincible)
            {
                currentHealth -= 5;
                DamageSound();
                if (currentHealth < 0)
                {
                    deathcount++;
                }
                Instantiate(collision.GetComponent<FireParticles>().particles).transform.position = collision.transform.position;

                Destroy(collision.gameObject);
                StartCoroutine("GetInv");
            }
            else if ((fire_heart || draining) && currentHealth < maxHealth)
            {
                currentHealth += 5;
                if (currentHealth > maxHealth) { currentHealth = maxHealth; }
                Instantiate(collision.GetComponent<FireParticles>().particles).transform.position = collision.transform.position;
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("health"))
        {
            if (!fire_heart && currentHealth < maxHealth)
            {
                currentHealth += 5;
                AudioSource.PlayClipAtPoint(collision.GetComponent<AudioSource>().clip, transform.position, 100);
                if (currentHealth > maxHealth) { currentHealth = maxHealth; }
                Destroy(collision.gameObject);
            }
            else if (fire_heart && !invincible)
            {
                currentHealth -= 5;
                DamageSound();
                if (currentHealth < 0)
                {
                    deathcount++;
                }
                //Instantiate(collision.GetComponent<FireParticles>().particles).transform.position = collision.transform.position;

                Destroy(collision.gameObject);
                StartCoroutine("GetInv");
            }
        }
    }

    IEnumerator GetInv()
    {
        c.a = 0.5f;
        rend.material.color = c;
        invincible = true;
        GetComponent<PlayerMovement>().moveSpeed += 2;
        yield return new WaitForSeconds(invincibilityTime);
        GetComponent<PlayerMovement>().moveSpeed -= 2;

        invincible = false;
        c.a = 1f;
        rend.material.color = c;
    }

    public void DamageSound()
    {
        GetComponent<AudioSource>().Play();
    }


}
