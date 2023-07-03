using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private bool doorOpen;

    protected override void Interact()
    {
        doorOpen = !doorOpen;
        GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
