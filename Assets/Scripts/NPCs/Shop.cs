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

    [SerializeField] Transform itemsContainer;

    public List<Item> shopContent;

    bool isOpen = false;
    Item selectedItem;
    Inventory inventory;
    ShopCanvas shopCanvas;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>(true);
        shopCanvas = FindObjectOfType<ShopCanvas>(true);
    }

    public void OpenShop()
    {
        isOpen = true;
        shopCanvas.gameObject.SetActive(isOpen);
        
        foreach (var item in shopContent)
        {
            var shopItem = Instantiate(item, itemsContainer);
            shopItem.SetShop(this);
        }

        shopCanvas.SetShop(this);
    }

    public void CloseShop()
    {
        isOpen = false;
        shopCanvas.gameObject.SetActive(isOpen);

        for (int i = 0; i < itemsContainer.childCount; i++)
            Destroy(itemsContainer.GetChild(i).gameObject);
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
        var enoughGold = CheckAvailableGold(selectedItem.Price);
        if (enoughGold)
        {
            inventory.AddItem(selectedItem);
            inventory.RefreshGoldValue();
            Debug.Log("You Bought: " + selectedItem.ItemName);
        }
    }

    private bool CheckAvailableGold(int price)
    {
        if (price <= inventory.Gold)
        {
            inventory.Gold -= price;
            return true;
        }
        else
        {
            Debug.Log("You dont have enough gold to purchase this item");
            return false;
        }
    }
}