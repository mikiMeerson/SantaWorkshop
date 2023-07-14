using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : Interactable
{
    public GameObject freezePotion;

    protected override void Interact()
    {
        if (GameData.freezePotions > 0)
        {
            promptMessage = "Freeze [E]";
            ThrowObject.instance.objectToThrow = freezePotion;
            ThrowObject.instance.throwForce = 25f;
            ThrowObject.instance.throwUpwardForce = 5f;

            GameData.freezePotions--;
            ThrowObject.instance.Throw();
        } else  promptMessage = "You do not have any freeze potions!";
    }
}