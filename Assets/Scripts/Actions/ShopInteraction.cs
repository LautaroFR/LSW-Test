using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour, IInteractable
{
    bool isInteracting = false;
    Inventory playerInventory;

    public GameObject GetGameObject() => gameObject;

    void Awake()
    {
        playerInventory = FindObjectOfType<Inventory>(true);
    }

    public void OnEndInteraction()
    {
        isInteracting = false;
        playerInventory.CloseInventory();
        Debug.Log($"End interaction with {name}");
    }

    public void OnBeginInteraction()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            playerInventory.OpenInventory();
            Debug.Log($"Begin interaction with {name}");
        }
    }


}
