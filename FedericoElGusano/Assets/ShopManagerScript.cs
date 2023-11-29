using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField]
    internal Shop shop = new Shop();
    private string file = "shop_items.data";
    public Text coinsTxt;

    public void Start()
    {
        try { shop = Persistence.Load(file, shop); }
        catch
        {
            shop.shopItems = new ShopObject[10];
            shop.shopItems[0] = new ShopObject(1, 25, false);
            shop.shopItems[1] = new ShopObject(2, 100, true);
            shop.shopItems[2] = new ShopObject(3, 300, true);
            shop.shopItems[3] = new ShopObject(4, 50, false);
            shop.shopItems[4] = new ShopObject(5, 325, true);
            shop.shopItems[5] = new ShopObject(6, 600, true);
            shop.shopItems[6] = new ShopObject(7, 100, false);
            shop.shopItems[7] = new ShopObject(8, 350, true);
            shop.shopItems[8] = new ShopObject(9, 800, true);
            shop.coins = 1000;
            Persistence.Save(shop,file);
        }
        coinsTxt.text = "COINS:" + shop.coins.ToString();

        

    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        ButtonInfo item = ButtonRef.GetComponent<ButtonInfo>();

        if (shop.coins >= shop.shopItems[item.itemID].price && !shop.shopItems[item.itemID].bought && !shop.shopItems[item.itemID].locked)
        {
            Unlock(item);
            shop.coins -= shop.shopItems[item.itemID].price;

            shop.shopItems[item.itemID].bought = true;

            coinsTxt.text = "COINS: " + shop.coins.ToString();
            item.boughtTxt.text = "SOLD";
            Persistence.Save(shop, file);
        }
    }

    public void Unlock(ButtonInfo item)
    {
        if(item.itemID < shop.shopItems.Length)shop.shopItems[item.itemID+1].locked = false;
    }
   
}
