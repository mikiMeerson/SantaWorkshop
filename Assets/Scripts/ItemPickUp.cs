using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public GameObject inventory;

    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        inventory.SetActive(false);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Pickup();
        }
    }
}
