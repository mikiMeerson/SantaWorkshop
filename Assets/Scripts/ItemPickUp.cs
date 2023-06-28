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

    private void OnMouseDown() // TODO canghe to collision with player
    {
        Pickup();
    }
}
