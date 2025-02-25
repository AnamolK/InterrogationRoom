using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenInventoryKey : MonoBehaviour
{
    void Update()
    {
        // Press 'I' to open the inventory scene.
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Ensure that your InventoryScene is added to your Build Settings.
            SceneManager.LoadScene("Inventory");
        }
    }
}
