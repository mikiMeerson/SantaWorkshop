using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;
    public Button removeButton;

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
                Debug.Log("Here!");
                Player.instance.IncreaseHealth(10);
                break;
            case Item.ItemType.WarmthPotion:
                Player.instance.IncreaseWarmth(10);
                break;
            case Item.ItemType.FreezePotion:
                break;
            case Item.ItemType.CandyCane:
                break;
            case Item.ItemType.GingerBread:
                break;
            case Item.ItemType.Lolipop:
                break;
            default:
                break;
        }

        RemoveItem();
    }
}
