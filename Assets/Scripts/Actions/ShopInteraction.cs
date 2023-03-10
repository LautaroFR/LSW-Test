using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour, IInteractable
{
    public GameObject GetGameObject() => gameObject;
   
    bool isInteracting = false;

    Inventory playerInventory;

    Shop shopView;

    void Awake()
    {
        playerInventory = FindObjectOfType<Inventory>(true);
        shopView = GetComponent<Shop>();
    }

    public void OnEndInteraction()
    {
        isInteracting = false;
        playerInventory.CloseInventory();
        shopView.CloseShop();
    }

    public void OnBeginInteraction()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            playerInventory.OpenInventory();
            shopView.OpenShop();
        }
    }
}
