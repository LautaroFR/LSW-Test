using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour, IInteractable
{
    bool isInteracting = false;
    public GameObject GetGameObject() => gameObject;

    public void OnEndInteraction()
    {
        isInteracting = false;
        Debug.Log($"End interaction with {name}");
    }

    public void OnBeginInteraction()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            Debug.Log($"Begin interaction with {name}");
        }
    }


}
