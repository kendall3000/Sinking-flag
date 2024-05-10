using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public delegate void InventoryChanged();
    public event InventoryChanged onInventoryChanged;

    public Dictionary<string, int> items = new Dictionary<string, int>();

    // Adds an item to the inventory with an optional count.
    public bool AddItem(string itemName, int count = 1)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName] += count;
        }
        else
        {
            items.Add(itemName, count);
        }
        Debug.Log($"Item {itemName} now has {items[itemName]} instances.");

        return true;  // Always return true as items are always added successfully.
    }

    // Uses an item, reducing its count by one if available.
    public bool UseItem(string itemName)
    {
        if (items.ContainsKey(itemName) && items[itemName] > 0)
        {
            items[itemName]--;
            Debug.Log($"Used one {itemName}. Remaining: {items[itemName]}");
            if (items[itemName] == 0) {
                items.Remove(itemName);  // Remove the item if count is zero
            }
            onInventoryChanged?.Invoke();  // Notify of changes
            return true;
        }
        Debug.Log($"Failed to use {itemName}, not enough stock or item not found.");
        return false;
    }

}

