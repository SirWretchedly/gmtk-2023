using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bucket : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject bucketless;

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
        if (Vector3.Distance(transform.position, player.transform.position) > 0.5)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            //  animator.SetBool("moving", true);
        }
        else
        {
            // animator.SetBool("moving", false);
        }
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
                    Instantiate(bucketless).transform.position = transform.position;
                    Destroy(gameObject);
                }

                Instantiate(collision.GetComponent<BulletMovement>().egg).transform.position = transform.position;
                Destroy(collision.gameObject);
            }
        }
    }
}
