using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void OnBeginInteraction();
    public void OnEndInteraction();

    public GameObject GetGameObject();
}
