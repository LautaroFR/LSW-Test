using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int Price;

    public ItemType Type;

    public string ItemName;
    public string ItemDescription;

    public Color Color;

    public Image Icon;

    public Sprite Sprite;

    Inventory playerInventory;
    Shop shopSeller;
    bool inInventory = false;

    public void SetShop(Shop shop) => shopSeller = shop;

    public void SetInventory(Inventory inventory)
    {
        playerInventory = inventory;
        inInventory = true;
    }

    public void OnSelectItem()
    {
        if (inInventory)
            playerInventory.OnSelectItem(this);
        else
            shopSeller.OnSelectItem(this);
    }
}

public enum ItemType
{
    Weapon,
    Armor,
    Helmet
}