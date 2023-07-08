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
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
    }

    void UpdateUITextPrice() {
        foreach(Transform tr in gameObject.transform){
            if(tr.tag == "shopPrice"){
                counterText = (TextMeshProUGUI)tr.gameObject.GetComponent<TextMeshProUGUI>();
                counterText.text = itemPrice.ToString();
           }
        }
    }

    public void moreHealth() {
        player.GetComponent<PlayerHealth>().maxHealth += 10;
        player.GetComponent<PlayerMoney>().SpendMoney(itemPrice);
    }

    public void moreSpeed() {
        player.GetComponent<PlayerMovement>().moveSpeed += 1;
        player.GetComponent<PlayerMoney>().SpendMoney(itemPrice);
    }

    public void moreDamage() {
        player.GetComponent<PlayerMoney>().SpendMoney(itemPrice);
    }
    
}
