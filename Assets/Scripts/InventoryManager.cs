using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();
    public Transform itemContent;
    public GameObject inventoryItem;
    public Toggle enableRemove;
    public InventoryItemController[] inventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<RawImage>();
            var deleteButton = obj.transform.Find("DeleteItem").GetComponent<Button>();

            if (itemName != null && itemIcon != null)
            {
                itemName.text = item.itemName;
                itemIcon.texture = item.icon.texture;

                if (enableRemove.isOn)
                {
                    deleteButton.gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.LogWarning("ItemName or ItemIcon components not found on the instantiated object.");
            }
        }

        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {
         if (enableRemove.isOn)
        {
            foreach (Transform item in itemContent)
            {
                item.Find("DeleteItem").gameObject.SetActive(true);

            }
        } else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("DeleteItem").gameObject.SetActive(false);

            }
        }
    }

    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i=0; i<items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }
}
