using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType type;
    public string itemName;
    public string itemDescription;
    public Color color;
}


public enum ItemType
{
    Weapon,
    Armor,
    Helmet
}