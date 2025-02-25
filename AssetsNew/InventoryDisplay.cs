using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Text inventoryText; 

    private void Update()
    {
        if (InventoryManager.Instance != null)
        {
            inventoryText.text = "Inventory:\n";
           
            foreach (string item in InventoryManager.Instance.Items)
            {
                inventoryText.text += item + "\n";
            }
        }
    }
}
