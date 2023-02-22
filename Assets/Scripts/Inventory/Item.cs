using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public bool IsEquipped;
    public bool InInventory = false;

    public Color Color;

    public int Price;

    public Image Icon;

    public ItemType Type;
    
    public Sprite Sprite;

    public string ItemName;
    public string ItemDescription;

    Inventory playerInventory;

    RectTransform rectTransform;

    Shop shopSeller;

    void Awake() => rectTransform = GetComponent<RectTransform>();

    public void SetShop(Shop shop) => shopSeller = shop;

    public void SetInventory(Inventory inventory)
    {
        playerInventory = inventory;
        InInventory = true;
    }

    public void OnSelectItem()
    {
        if (InInventory)
        {
            playerInventory.OnSelectItem(this);
            if (IsEquipped)
                playerInventory.EquipBtnTxt.text = "Unequip";

            else
                playerInventory.EquipBtnTxt.text = "Equip";
        }
        else
            shopSeller.OnSelectItem(this);
    }

    public void SetMiddleAnchor()
    {
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot     = new Vector2(0.5f, 0.5f);
        transform.localPosition = Vector3.zero;
    }
}

public enum ItemType
{
    Weapon,
    Armor,
    Helmet
}