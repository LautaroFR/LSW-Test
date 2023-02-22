using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public int Gold;

    public GridLayoutGroup Grid;

    public TextMeshProUGUI ItemNameTxt;
    public TextMeshProUGUI ItemDescrTxt;
    public TextMeshProUGUI GoldTxt;
    public TextMeshProUGUI EquipBtnTxt;

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

    public void Unequip(Item item, ItemSlot slot)
    {
        if (!item.IsEquipped)
            return;

        item.IsEquipped = false;
        item.transform.SetParent(Grid.transform, false);
        itemsOnInventory.Add(item);
        equippedItems.Remove(item);
        slot.playerViewSprite.sprite = null;
    }

    public void EquipBtn()
    {
        if (selectedItem == null)
            return;

        var itemSlot = equipmentSlots.Where(x => x.slotType == selectedItem.Type).First();
        var currentlyEquippedSlot = equippedItems.Where(x => x.Type == selectedItem.Type);

        if (selectedItem.IsEquipped)
        {
            Unequip(selectedItem, itemSlot);
            return;
        }
        else
            EquipSelectedItem(currentlyEquippedSlot, itemSlot);
    }

    public void EquipSelectedItem(IEnumerable<Item> currentlyEquippedSlot, ItemSlot itemSlot)
    {
        if (currentlyEquippedSlot.Any())
            Unequip(currentlyEquippedSlot.First(), itemSlot);
            
        equippedItems.Add(selectedItem);
        selectedItem.IsEquipped = true;
        itemSlot.playerViewSprite.sprite = selectedItem.Sprite;
        selectedItem.transform.SetParent(itemSlot.inventorySlotImage.transform, false);
        selectedItem.SetMiddleAnchor();
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