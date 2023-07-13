using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneName;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void Load()
    {
        
        player.transform.position = Vector3.zero;
        player.GetComponent<PlayerHealth>().currentHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().maxHealth;
        player.GetComponent<PlayerHealth>().fire_heart = false;
        player.GetComponent<PlayerMovement>().reverseStangaDreaptaM = 1;
        player.GetComponent<PlayerMovement>().reverseSusJosM = 1;
        player.GetComponent<PlayerMovement>().reverseStangaDreaptaF = 1;
        player.GetComponent<PlayerMovement>().reverseSusJosF = 1;
        player.GetComponent<PlayerMovement>().downM = KeyCode.S;
        player.GetComponent<PlayerMovement>().downF = KeyCode.DownArrow;
        player.GetComponent<PlayerMovement>().upM = KeyCode.W;
        player.GetComponent<PlayerMovement>().upF = KeyCode.UpArrow;
        player.GetComponent<PlayerMovement>().leftM = KeyCode.A;
        player.GetComponent<PlayerMovement>().leftF = KeyCode.LeftArrow;
        player.GetComponent<PlayerMovement>().rightM = KeyCode.D;
        player.GetComponent<PlayerMovement>().rightF = KeyCode.RightArrow;
        if (SceneName == "Level 4")
        {
            Destroy(player);
        }
        SceneManager.LoadScene(SceneName);
    }
}
