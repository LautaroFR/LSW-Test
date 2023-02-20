using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    PlayerView playerView;
    bool isOpen = false;
    Item selectedItem;
    Item equipedArmor;
    Item equipedWeapon;
    Item equipedHelmet;

    //list items on inventory

    private void Awake()
    {
        playerView = FindObjectOfType<PlayerView>();
    }

    public void OpenInventory()
    {
        isOpen = true;
        gameObject.SetActive(isOpen);
    }

    public void CloseInventory()
    {
        isOpen = false;
        gameObject.SetActive(isOpen);
    }

    //testing equipment
    public Item redArmor;
    public void TestEquipment()
    {
        // select item on UI calling OnSelect with the item as parameter
        OnSelectItem(redArmor);
        //equip button on UI calls EquipSelectedItem
        EquipSelectedItem();
    }
    //

    public void OnSelectItem(Item item)
    {
        selectedItem = item;
    }

    public void EquipSelectedItem()
    {
        switch (selectedItem.type)
        {
            case ItemType.Weapon:
                //if equiped is not null, return it to the list
                equipedWeapon = selectedItem;
                playerView.weaponView.color = equipedWeapon.color;
                //remove new equiped item from the list
                break;
            case ItemType.Armor:
                equipedArmor = selectedItem;
                playerView.armorView.color = equipedArmor.color;
                break;
            case ItemType.Helmet:
                equipedHelmet = selectedItem;
                playerView.helmetView.color = equipedHelmet.color;
                break;
            default:
                break;
        }
    }
}
