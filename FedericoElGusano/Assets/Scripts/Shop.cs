using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Shop
{
    public ShopObject[] shopItems;
    public int coins;

    public Shop()
    {
        shopItems = null; coins = 0;
    }
}
