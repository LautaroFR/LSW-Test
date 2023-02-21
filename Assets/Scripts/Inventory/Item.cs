using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int Price;

    public ItemType Type;

    public string ItemName;
    public string ItemDescription;

    public Color Color;


    Inventory inventory;
    Shop shop;
    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        shop = FindObjectOfType<Shop>();
    }
        
    public void OnSelectItem()
    {
        var shopItem = GetComponentInParent<Shop>();

        if (shopItem != null)
            shop.OnSelectItem(this);

        else
            inventory.OnSelectItem(this);
    }
}

public enum ItemType
{
    Weapon,
    Armor,
    Helmet
}