using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public int Gold;
    
    public TextMeshProUGUI ItemNameTxt;
    public TextMeshProUGUI ItemDescrTxt;
    public TextMeshProUGUI GoldTxt;

    public GridLayoutGroup Grid;

    bool isOpen = false;
    
    Item selectedItem;
    Item equippedArmor;
    Item equippedWeapon;
    Item equippedHelmet;
    
    PlayerView playerView;

    public List<Item> ItemsOnInventory = new();

    private void Awake()
    {
        playerView = FindObjectOfType<PlayerView>();
    }

    private void Start()
    {
        UpdateInventoryView();
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

    public void OnSelectItem(Item item)
    {
        selectedItem = item;
        UpdateDescription(item);
    }

    public void EquipSelectedItem()
    {
        switch (selectedItem.Type)
        {
            case ItemType.Weapon:
                //if equiped is not null, return it to the list
                equippedWeapon = selectedItem;
                playerView.weaponView.color = equippedWeapon.Color;
                //remove new equiped item from the list
                break;
            case ItemType.Armor:
                equippedArmor = selectedItem;
                playerView.armorView.color = equippedArmor.Color;
                break;
            case ItemType.Helmet:
                equippedHelmet = selectedItem;
                playerView.helmetView.color = equippedHelmet.Color;
                break;
            default:
                break;
        }
    }

    void UpdateDescription(Item item)
    {
        ItemNameTxt.text = item.ItemName;
        ItemDescrTxt.text = item.ItemDescription;
    }

    public void UpdateInventoryView()
    {
        foreach (var item in ItemsOnInventory)
            Instantiate(item, Grid.transform);

        GoldTxt.text = Gold.ToString();
    }
}
