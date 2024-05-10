// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// using UnityEngine;

// public class InventoryDisplay : MonoBehaviour
// {
//     public GameObject inventoryPanel;

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.I))  // Press 'I' to toggle inventory display
//         {
//             inventoryPanel.SetActive(!inventoryPanel.activeSelf);
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

// public class InventoryDisplay : MonoBehaviour
// {
//     public GameObject inventoryPanel;
//     public GameObject inventoryItemPrefab; // Prefab for displaying individual inventory items

//     void Update()
//     {
        
//         if (Input.GetKeyDown(KeyCode.I))  // Press 'I' to toggle inventory display
//         {
//             inventoryPanel.SetActive(!inventoryPanel.activeSelf);
//             Debug.Log("Inventory visibility: " + inventoryPanel.activeSelf);
//             Debug.Log("Inventory position: " + inventoryPanel.transform.position);
//         }
        


//     }
    

//     private InventoryManager inventoryManager;

//     private void Start()
//     {
//         inventoryManager = FindObjectOfType<InventoryManager>();
//         UpdateInventoryDisplay();
//     }

//     public void UpdateInventoryDisplay()
//     {
//         // Clear existing items
//         foreach (Transform child in inventoryPanel.transform)
//         {
//             Destroy(child.gameObject);
//         }

//         // Add new items
//         foreach (var item in inventoryManager.items)
//         {
//             GameObject itemDisplay = Instantiate(inventoryItemPrefab, inventoryPanel.transform);
//             itemDisplay.GetComponentInChildren<Text>().text = $"{item.Key}: {item.Value}";
//         }
//     }
// }



public class InventoryDisplay : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject inventoryItemPrefab; // Ensure this is assigned in Unity

    private InventoryManager inventoryManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))  // Toggle inventory display
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            Debug.Log($"Inventory visibility: {inventoryPanel.activeSelf}");
        }
    }

    public void UpdateInventoryDisplay()
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);  // Clear the current display
        }

        foreach (var item in inventoryManager.items)
        {
            GameObject itemDisplay = Instantiate(inventoryItemPrefab, inventoryPanel.transform);
            itemDisplay.GetComponentInChildren<Text>().text = $"{item.Key}: {item.Value}";
        }
    }
    private void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        // Subscribe to the inventory changed event
        inventoryManager.onInventoryChanged += UpdateInventoryDisplay;
        UpdateInventoryDisplay();  // Initial update to display items at start
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        inventoryManager.onInventoryChanged -= UpdateInventoryDisplay;
    }

}

