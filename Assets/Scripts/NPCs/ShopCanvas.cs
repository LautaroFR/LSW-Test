using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCanvas : MonoBehaviour
{
    [SerializeField] Button selectBtn;

    Shop currentShop;
    public void SetShop(Shop shop)
    {
        currentShop = shop;
        selectBtn.onClick.RemoveAllListeners();
        selectBtn.onClick.AddListener(() => currentShop.PurchaseRequest());
    }
}
