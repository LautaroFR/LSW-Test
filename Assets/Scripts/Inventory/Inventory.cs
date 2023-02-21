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
    
    public GridLayoutGroup Grid;
    
    public TextMeshProUGUI ItemNameTxt;
    public TextMeshProUGUI ItemDescrTxt;
    public TextMeshProUGUI GoldTxt;

    public Image ArmorImg;
    public Image HelmetImg;
    public Image WeaponImg;

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
        UpdateInventoryView();
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
                if (equippedWeapon != null)
                    ItemsOnInventory.Add(equippedWeapon);

                equippedWeapon = selectedItem;
                playerView.weaponView.color = equippedWeapon.Color;
                WeaponImg.sprite = equippedWeapon.Icon.sprite;
                ItemsOnInventory.Remove(equippedWeapon);
                UpdateInventoryView();
                //remove new equiped item from the list
                break;
            case ItemType.Armor:
                if (equippedArmor != null)
                    ItemsOnInventory.Add(equippedArmor);

                equippedArmor = selectedItem;
                playerView.armorView.color = equippedArmor.Color;
                ArmorImg.sprite = equippedArmor.Icon.sprite;
                ItemsOnInventory.Remove(equippedArmor);
                break;
            case ItemType.Helmet:
                if (equippedHelmet != null)
                    ItemsOnInventory.Add(equippedHelmet);

                equippedHelmet = selectedItem;
                playerView.helmetView.color = equippedHelmet.Color;
                HelmetImg.sprite = equippedHelmet.Icon.sprite;
                ItemsOnInventory.Remove(equippedHelmet);
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
        ClearInventory();
        
        foreach (var item in ItemsOnInventory)
            Instantiate(item, Grid.transform);

        GoldTxt.text = Gold.ToString();
    }

    public void ClearInventory()
    {
        foreach (Transform item in Grid.transform)
            GameObject.Destroy(item.gameObject);
    }
}
