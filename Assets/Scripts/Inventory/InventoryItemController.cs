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
                if (PlayerVitals.instance.GetHealthAmount() <= 90)
                {
                    PlayerVitals.instance.IncreaseHealth(10);
                    RemoveItem();
                }
                break;
            case Item.ItemType.WarmthPotion:
                if (PlayerVitals.instance.GetWarmthAmount() <= 90)
                {
                    PlayerVitals.instance.IncreaseWarmth(10);
                    RemoveItem();
                }
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

    }
}
