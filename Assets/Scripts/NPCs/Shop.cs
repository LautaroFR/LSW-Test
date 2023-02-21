using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using TMPro;
public class Shop : MonoBehaviour
{
    public TextMeshProUGUI ItemNameTxt;
    public TextMeshProUGUI ItemDescrTxt;
    public TextMeshProUGUI ItemPriceTxt;

    bool enoughGold;
    bool isOpen = false;
    Item selectedItem;
    Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    public void OpenShop()
    {
        isOpen = true;
        gameObject.SetActive(isOpen);
    }

    public void CloseShop()
    {
        isOpen = false;
        gameObject.SetActive(isOpen);
    }
    public void OnSelectItem(Item item)
    {
        selectedItem = item;
        UpdateDescription(item);
    }

    void UpdateDescription(Item item)
    {
        ItemNameTxt.text = item.ItemName;
        ItemDescrTxt.text = item.ItemDescription;
        ItemPriceTxt.text = item.Price.ToString();
    }

    public void PurchaseRequest()
    {
        CheckAvailableGold(selectedItem.Price);
        if(enoughGold)
        {
            inventory.ItemsOnInventory.Add(selectedItem);
            inventory.UpdateInventoryView();
            Debug.Log("You Bought: " + selectedItem.ItemName);
        }
    }

    private void CheckAvailableGold(int price)
    {
        if(price > inventory.Gold)
        {
            enoughGold = false;
            Debug.Log("You dont have enough gold to purchase this item");
        }

        if(price <= inventory.Gold)
        {
            enoughGold = true;
            inventory.Gold -= price;
        }
    }
}
