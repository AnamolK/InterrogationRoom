using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    
    public string itemName = "New Item";

    
    private void OnMouseDown()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.AddItem(itemName);
        }
        else
        {
            Debug.LogError("InventoryManager instance not found!");
        }

        
        Destroy(gameObject);
    }
}
