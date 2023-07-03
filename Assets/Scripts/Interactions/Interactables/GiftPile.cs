using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftPile : Interactable
{
    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
