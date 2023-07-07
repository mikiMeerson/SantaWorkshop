using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftInteract : Interactable
{
    protected override void Interact()
    {
        ThrowBomb.instance.Throw();
    }
}
