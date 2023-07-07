using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftInteract : Interactable
{
    public GameObject bomb;

    protected override void Interact()
    {
        ThrowObject.instance.objectToThrow = bomb;
        ThrowObject.instance.throwForce = 50f;
        ThrowObject.instance.throwUpwardForce = 10f;
        ThrowObject.instance.Throw();
    }
}
