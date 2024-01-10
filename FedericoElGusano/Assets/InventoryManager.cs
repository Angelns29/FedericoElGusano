using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public int actualArmor;
    public int actualCharge;
    // Start is called before the first frame update
    void Start()
    {
        LoadInventory();
        actualArmor = inventory.armor;
        actualCharge = inventory.charge;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadInventory()
    {
        string fileInventory = "inventory.data";
        try { inventory = Persistence.Load(fileInventory, this.inventory); }
        catch
        {
            this.inventory.coins = 0;
            this.inventory.armor = 0;
            this.inventory.weapon = 0;
            this.inventory.charge = 0;
            Persistence.Save(this.inventory, fileInventory);
        }
    }

    public void SaveCoins()
    {
        Shop shop = new Shop();
        string fileShop = "shop_items.data";
        string fileInventory = "inventory.data";

        shop = Persistence.Load(fileShop, shop);
        shop.coins += this.inventory.coins;
        this.inventory.coins = 0;
        Persistence.Save(shop, fileShop);
        Persistence.Save(this.inventory, fileInventory);
    }
}
