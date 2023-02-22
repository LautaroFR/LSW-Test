using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCanvas : MonoBehaviour
{
    public Button SellBtn;

    [SerializeField] Button purchaseBtn;

    Shop currentShop;
    public void SetShop(Shop shop)
    {
        currentShop = shop;
        purchaseBtn.onClick.RemoveAllListeners();
        purchaseBtn.onClick.AddListener(() => currentShop.PurchaseRequest());
    }
}
