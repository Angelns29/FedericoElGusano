using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField]
    internal Shop shop = new Shop();
    internal Inventory inventory = new Inventory();
    private string fileShop = "shop_items.data";
    private string fileinventory = "inventory.data";
    public Text coinsTxt;

    public void Start()
    {
        try { inventory = Persistence.Load(fileinventory, inventory); }
        catch
        {
            inventory.coins = 0;
            inventory.armor = 0;
            inventory.weapon = 0;
            inventory.charge = 0;
            Persistence.Save(inventory, fileinventory);
        }

        try { shop = Persistence.Load(fileShop, shop); }
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
            Persistence.Save(shop,fileShop);
        }
        coinsTxt.text = shop.coins.ToString();

        

    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        ButtonInfo item = ButtonRef.GetComponent<ButtonInfo>();

        if (shop.coins >= shop.shopItems[item.itemID].price && !shop.shopItems[item.itemID].bought && !shop.shopItems[item.itemID].locked)
        {
            Unlock(item);
            SetItem(item.itemID, inventory);
            shop.coins -= shop.shopItems[item.itemID].price;
            shop.shopItems[item.itemID].bought = true;

            coinsTxt.text = "COINS: " + shop.coins.ToString();
            item.boughtTxt.text = "SOLD";
            Persistence.Save(inventory, fileinventory);
            Persistence.Save(shop, fileShop);
        }
    }

    public void Unlock(ButtonInfo item)
    {
        if(item.itemID < shop.shopItems.Length)shop.shopItems[item.itemID+1].locked = false;
    }

    public void SetItem(int id, Inventory inventory)
    {
        switch (id)
        {
            case 0:
            case 1:
            case 2: inventory.armor++;
                break;
            case 3:
            case 4:
            case 5: inventory.weapon++;
                break;
            case 6:
            case 7:
            case 8: inventory.charge++;
                break;
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(1);
    }

}
