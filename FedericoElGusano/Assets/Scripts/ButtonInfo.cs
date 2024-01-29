using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int itemID;
    public TMP_Text  priceTxt;
    public TMP_Text boughtTxt;
    public GameObject shopManager;

    void Update()
    {
        priceTxt.text = "Price: $" + shopManager.GetComponent<ShopManagerScript>().shop.shopItems[itemID].price.ToString();
        if (!shopManager.GetComponent<ShopManagerScript>().shop.shopItems[itemID].bought)
        {
            boughtTxt.text = "BUY";
        }
        else boughtTxt.text = "SOLD";
    }
}
