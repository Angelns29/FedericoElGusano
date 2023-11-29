using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ShopObject
{
    public int id;
    public int price;
    public bool bought;
    public bool locked;

    public ShopObject(int id, int price, bool bought, bool locked)
    {
        this.id = id;
        this.price = price;
        this.bought = false;
        this.locked = locked;
    }
    public ShopObject(int id, int price, bool locked)
    {
        this.id = id;
        this.price = price;
        this.bought = false;
        this.locked = locked;
    }
}
