using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public int Gold;

    public GridLayoutGroup Grid;

    public TextMeshProUGUI ItemNameTxt;
    public TextMeshProUGUI ItemDescrTxt;
    public TextMeshProUGUI GoldTxt;

    [SerializeField] List<ItemSlot> equipmentSlots;

    Item selectedItem;
    List<Item> equippedItems = new();
    List<Item> itemsOnInventory = new();
    bool isOpen = false;

    public void OpenInventory()
    {
        isOpen = true;
        RefreshGoldValue();
        gameObject.SetActive(isOpen);
    }

    public void CloseInventory()
    {
        isOpen = false;
        gameObject.SetActive(isOpen);
        ItemNameTxt.text = "";
        ItemDescrTxt.text = "";
        GoldTxt.text = "";
    }

    public void OnSelectItem(Item item)
    {
        selectedItem = item;
        UpdateDescription(item);
    }

    public void EquipSelectedItem()
    {
        if (selectedItem == null)
            return;

        var currentlyEquippedSlot = equippedItems.Where(x => x.Type == selectedItem.Type);
        if (currentlyEquippedSlot.Any())
            itemsOnInventory.Add(currentlyEquippedSlot.First());

        equippedItems.Add(selectedItem);
        var itemSlot = equipmentSlots.Where(x => x.slotType == selectedItem.Type).First();
        itemSlot.playerViewSprite.color = selectedItem.Color;//cambiar esto, en lugar de cambiar el color, cambiar el sprite por la imagen del item.

        //en lugar de destruir y cambiar el color, cambiar el parent por "itemSlot.inventorySlotImage" y ponerlo en la posicon "0". 
        Destroy(selectedItem.gameObject);
        itemSlot.inventorySlotImage.color = selectedItem.Color;
        //

        itemsOnInventory.Remove(selectedItem);
    }

    void UpdateDescription(Item item)
    {
        ItemNameTxt.text = item.ItemName;
        ItemDescrTxt.text = item.ItemDescription;
    }

    public void AddItem(Item item)
    {
        var newItem = Instantiate(item, Grid.transform);
        itemsOnInventory.Add(newItem);
        newItem.SetInventory(this);
    }

    public void RefreshGoldValue() => GoldTxt.text = Gold.ToString();
}