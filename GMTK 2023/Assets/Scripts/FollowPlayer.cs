using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float movementSpeed = 3;
    public int trapped = 0;
    public int damageToPlayer = 5;

    private GameObject player;
    private Animator animator, status;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        // animator = gameObject.GetComponent<Animator>();
        // status = gameObject.transform.Find("Status").gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("YESSSS " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("bullet"))
        {

            BulletControl bulletController = collision.gameObject.GetComponent<BulletControl>();

            if (bulletController != null)
            {
                int damage = bulletController.damage;
                currentHealth -= damage;

                if (currentHealth <= 0)
                {
                    Destroy(gameObject);
                }

                Instantiate(collision.GetComponent<BulletMovement>().egg).transform.position = transform.position;
                Destroy(collision.gameObject);
            }
        }
        if(collision.gameObject.CompareTag("fire"))
        {
            currentHealth -= 10;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            collision.GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject);
        }
    }
}
