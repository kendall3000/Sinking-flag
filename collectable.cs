using UnityEngine;

public class collectable : MonoBehaviour
{
    public string itemName;  // Ensure this is set in the inspector or somewhere in your code before use.

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);  // Confirm the collision
        if (other.CompareTag("Player"))
        {
            Debug.Log("Attempting to add item to inventory: " + this.gameObject.name);
            bool itemAdded = other.GetComponent<InventoryManager>().AddItem(this.gameObject.name);
            Debug.Log("Item added: " + itemAdded);
            if (itemAdded)
            {
                Destroy(this.gameObject);  // Only destroy the object if it was successfully added.
            }
        }
    }
}
