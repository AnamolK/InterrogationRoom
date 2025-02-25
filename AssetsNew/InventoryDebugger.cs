using UnityEngine;

public class InventoryDebugger : MonoBehaviour
{
    void Start()
    {
        Debug.Log("InventoryDebugger is active");
    }

    void Update()
    {
        // Press 'I' to print the current inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryManager.Instance != null)
            {
                string[] currentInventory = InventoryManager.Instance.Items;
                // Use string.Join to concatenate all items separated by commas.
                string inventoryContents = "Current Inventory: " + string.Join(", ", currentInventory);
                Debug.Log(inventoryContents);
            }
            else
            {
                Debug.Log("InventoryManager instance not found!");
            }
        }
    }
}
