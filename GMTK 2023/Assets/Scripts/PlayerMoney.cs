using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMoney : MonoBehaviour
{

    public int currentMoney = 0;
    public TextMeshProUGUI counterText;
    public GameObject shopCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = currentMoney.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("money")) {
            currentMoney += 1;
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("shop")) {
            shopCanvas.SetActive(true);
        }
    }

    public void SpendMoney(int price) {
        if (currentMoney >= price) {
            currentMoney -= price;
        }
    }
}
