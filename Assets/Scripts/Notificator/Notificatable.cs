using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Notificatable : MonoBehaviour
{
    public string promptMessage;

    public void BaseNotify()
    {
        Notify();
    }

    protected virtual void Notify() { }
}
