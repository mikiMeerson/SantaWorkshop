using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : Interactable
{
    protected override void Interact()
    {
        ThrowBomb.instance.Throw();
    }
}