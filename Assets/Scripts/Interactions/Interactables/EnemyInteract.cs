using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : Interactable
{
    public GameObject freezePotion;

    protected override void Interact()
    {
        ThrowObject.instance.objectToThrow = freezePotion;
        ThrowObject.instance.throwForce = 25f;
        ThrowObject.instance.throwUpwardForce = 5f;

        ThrowObject.instance.Throw();
    }
}