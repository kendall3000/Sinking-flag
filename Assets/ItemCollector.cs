using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))  // Make sure your items have the "Item" tag
        {
            string itemName = other.gameObject.name;  // Assuming the item's name is a key in your inventory
            inventoryManager.AddItem(itemName, 1);  // Add 1 item to the inventory
            Destroy(other.gameObject);  // Destroy the item GameObject
        }
    }
}
