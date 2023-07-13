using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMoney : MonoBehaviour
{

    public int currentMoney;
    public TextMeshProUGUI counterText;
    public GameObject shopCanvas;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(shopCanvas);
        print("poo");
        counterText.text = currentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = currentMoney.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("money"))
        {
            AudioSource.PlayClipAtPoint(collision.GetComponent<AudioSource>().clip, transform.position, 100);
            currentMoney += 1;
            Destroy(collision.gameObject);
            counterText.text = currentMoney.ToString();
        }
        else if (collision.gameObject.CompareTag("shop"))
        {
            ToggleTimeFreeze();
            shopCanvas.SetActive(true);
        }
    }

    public void SpendMoney(int price)
    {
        if (currentMoney >= price)
        {
            currentMoney = currentMoney - price;
            counterText.text = currentMoney.ToString();
        }
    }

    public void ToggleTimeFreeze()
    {
        if (Time.timeScale == 0f)
        {
            // Unfreeze time
            Time.timeScale = 1f;
            Debug.Log("Time unfrozen.");
        }
        else
        {
            // Freeze time
            Time.timeScale = 0f;
            Debug.Log("Time frozen.");
        }
    }

    public void Reload()
    {
        counterText = GameObject.FindWithTag("Finish").GetComponent<TextMeshProUGUI>();
        counterText.text = currentMoney.ToString();
    }
}
