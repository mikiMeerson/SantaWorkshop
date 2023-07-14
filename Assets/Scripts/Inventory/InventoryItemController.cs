using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public static InventoryItemController instance;

    Item item;
    public Button removeButton;

    void Awake()
    {
        instance = this;
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void AddItem(Item newItem) 
    {
        item = newItem;    
    }

    public void UseItem()
    {
        switch(item.itemType)
        {
            case Item.ItemType.EnergyPotion:
                if (GameData.healthAmount < 100)
                {
                    PlayerVitals.instance.IncreaseHealth(10);
                    RemoveItem();
                }
                break;
            case Item.ItemType.WarmthPotion:
                if (GameData.warmthAmount < 100)
                {
                    PlayerVitals.instance.IncreaseWarmth(10);
                    RemoveItem();
                }
                break;
            default:
                break;
        }

    }

    public void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.FreezePotion:
                GameData.freezePotions--;
                RemoveItem();
                break;
            default:
                break;
        }

    }
}
