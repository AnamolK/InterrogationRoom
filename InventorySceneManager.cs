using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventorySceneManager : MonoBehaviour
{
    [Header("UI References")]
    public Text itemText;            // Text component to display the current inventory item.
    public Button nextButton;        // Button to go to the next item.
    public Button previousButton;    // Button to go to the previous item.
    public Button backButton;        // Button to return to the main game scene.

    private int currentIndex = 0;

    void Start()
    {
        // Set up button listeners.
        nextButton.onClick.AddListener(ShowNextItem);
        previousButton.onClick.AddListener(ShowPreviousItem);
        backButton.onClick.AddListener(GoBack);

        // Initialize the inventory display.
        currentIndex = 0;
        UpdateItemDisplay();
    }

    /// <summary>
    /// Advances to the next inventory item.
    /// </summary>
    void ShowNextItem()
    {
        string[] items = InventoryManager.Instance.Items;
        if (items.Length == 0)
        {
            itemText.text = "No items in inventory.";
            return;
        }

        currentIndex = (currentIndex + 1) % items.Length;
        UpdateItemDisplay();
    }

    /// <summary>
    /// Moves to the previous inventory item.
    /// </summary>
    void ShowPreviousItem()
    {
        string[] items = InventoryManager.Instance.Items;
        if (items.Length == 0)
        {
            itemText.text = "No items in inventory.";
            return;
        }

        currentIndex = (currentIndex - 1 + items.Length) % items.Length;
        UpdateItemDisplay();
    }

    /// <summary>
    /// Updates the displayed text to show the current inventory item.
    /// </summary>
    void UpdateItemDisplay()
    {
        string[] items = InventoryManager.Instance.Items;
        if (items.Length == 0)
        {
            itemText.text = "No items in inventory.";
        }
        else
        {
            itemText.text = items[currentIndex];
        }
    }

    /// <summary>
    /// Loads the main game scene.
    /// </summary>
    void GoBack()
    {
        // Replace "MainGameScene" with the actual name of your main game scene.
        SceneManager.LoadScene("MainGameScene");
    }
}
