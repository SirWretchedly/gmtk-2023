using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonShop : MonoBehaviour
{
    // Start is called before the first frame update


    public int itemPrice;
    private GameObject player;
    public TextMeshProUGUI counterText;

    void Start()
    {
        UpdateUITextPrice();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUITextPrice()
    {
        foreach (Transform tr in gameObject.transform)
        {
            if (tr.tag == "shopPrice")
            {
                counterText = (TextMeshProUGUI)tr.gameObject.GetComponent<TextMeshProUGUI>();
                counterText.text = itemPrice.ToString();
            }
        }
    }

    public void moreHealth()
    {
        print(player.GetComponent<PlayerMoney>().currentMoney);
        if (itemPrice <= player.GetComponent<PlayerMoney>().currentMoney)
        {
            player.GetComponent<PlayerHealth>().maxHealth += 5;
            player.GetComponent<PlayerMoney>().SpendMoney(itemPrice);
            itemPrice *= 2;
            counterText.text = itemPrice.ToString();
        }
    }

    public void moreSpeed()
    {
        if (itemPrice <= player.GetComponent<PlayerMoney>().currentMoney)
        {
            player.GetComponent<PlayerMovement>().moveSpeed += 1;
            player.GetComponent<PlayerMoney>().SpendMoney(itemPrice);
            itemPrice *= 2;
            counterText.text = itemPrice.ToString();
        }
    }

    public void moreFireRate()
    {
        if (itemPrice <= player.GetComponent<PlayerMoney>().currentMoney)
        {
            if (player.GetComponent<PlayerMovement>().fireRate > 0.1f)
            {
                player.GetComponent<PlayerMovement>().fireRate /= 1.5f;
                player.GetComponent<PlayerMoney>().SpendMoney(itemPrice);
                itemPrice *= 2;
                counterText.text = itemPrice.ToString();
            }
        }
    }
}
