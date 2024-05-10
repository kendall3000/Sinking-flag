using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(string itemName)
    {
        InventoryItem foundItem = items.Find(item => item.itemName == itemName);
        if (foundItem != null)
        {
            foundItem.quantity++;
        }
        else
        {
            items.Add(new InventoryItem { itemName = itemName, quantity = 1 });
        }
    }

    public void UseItem(string itemName)
    {
        InventoryItem foundItem = items.Find(item => item.itemName == itemName);
        if (foundItem != null && foundItem.quantity > 0)
        {
            // Apply the effect based on the item
            ApplyItemEffect(itemName);
            foundItem.quantity--;
        }
    }

    void ApplyItemEffect(string itemName)
    {
        // Placeholder: Add effect logic here
        Debug.Log($"Used {itemName}, apply its effect here.");
    }
}