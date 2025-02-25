using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventorySceneManager : MonoBehaviour
{
    [System.Serializable]
    public class ItemAssetMapping
    {
        public string itemName;         // The item identifier (e.g. "Apple", "Banana")
        public GameObject assetPrefab;  // The corresponding prefab to display.
    }

    [Header("UI References")]
    public Text itemText;            // Displays the current inventory item text.
    public Button nextButton;        // Button to go to the next item.
    public Button previousButton;    // Button to go to the previous item.
    public Button backButton;        // Button to return to the main scene.

    [Header("Mapping & Asset Display")]
    public ItemAssetMapping[] itemMappings; // Array mapping item names to asset prefabs.
    public Transform assetDisplayParent;    // Parent for instantiating the asset.

    private int currentIndex = 0;
    private GameObject currentAsset;

    void Start()
    {
        // Set up button listeners.
        nextButton.onClick.AddListener(ShowNextItem);
        previousButton.onClick.AddListener(ShowPreviousItem);
        backButton.onClick.AddListener(GoBack);

        currentIndex = 0;
        UpdateItemDisplay();
    }

    void Update()
    {
        // Optional arrow key navigation.
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ShowNextItem();
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            ShowPreviousItem();
    }

    void ShowNextItem()
    {
        string[] items = InventoryManager.Instance.Items;
        if (items == null || items.Length == 0)
        {
            itemText.text = "No items in inventory.";
            ClearAsset();
            return;
        }

        currentIndex = (currentIndex + 1) % items.Length;
        Debug.Log("Switching to index: " + currentIndex);
        UpdateItemDisplay();
    }

    void ShowPreviousItem()
    {
        string[] items = InventoryManager.Instance.Items;
        if (items == null || items.Length == 0)
        {
            itemText.text = "No items in inventory.";
            ClearAsset();
            return;
        }

        currentIndex = (currentIndex - 1 + items.Length) % items.Length;
        Debug.Log("Switching to index: " + currentIndex);
        UpdateItemDisplay();
    }

    void UpdateItemDisplay()
    {
        string[] items = InventoryManager.Instance.Items;
        if (items == null || items.Length == 0)
        {
            itemText.text = "No items in inventory.";
            ClearAsset();
            return;
        }
        else
        {
            string currentItem = items[currentIndex];
            itemText.text = currentItem;
            Debug.Log("Displaying item: " + currentItem);

            // Look up the corresponding asset prefab.
            GameObject prefab = GetAssetPrefabForItem(currentItem);
            if (prefab != null)
            {
                Debug.Log("Instantiating prefab: " + prefab.name + " for item: " + currentItem);
                ClearAsset(); // Clear the previous asset.

                Transform parent = assetDisplayParent != null ? assetDisplayParent : transform;
                currentAsset = Instantiate(prefab, new Vector3(-3, 0, 11), Quaternion.identity, parent);


                Debug.Log("Instantiated object: " + currentAsset.name + " (ID: " + currentAsset.GetInstanceID() + ")");
            }
            else
            {
                Debug.LogWarning("No prefab mapping found for item: " + currentItem);
                ClearAsset();
            }
        }
    }

    GameObject GetAssetPrefabForItem(string itemName)
    {
        if (itemMappings != null)
        {
            foreach (ItemAssetMapping mapping in itemMappings)
            {
                if (mapping.itemName.Equals(itemName))
                {
                    Debug.Log("Found mapping for: " + itemName);
                    return mapping.assetPrefab;
                }
            }
        }
        Debug.Log("No mapping found for: " + itemName);
        return null;
    }

    void ClearAsset()
    {
        if (currentAsset != null)
        {
            // For testing purposes, you can use DestroyImmediate to ensure the asset is removed immediately.
#if UNITY_EDITOR
            DestroyImmediate(currentAsset);
#else
            Destroy(currentAsset);
#endif
            currentAsset = null;
            Debug.Log("Cleared previous asset.");
        }
    }

    void GoBack()
    {
        SceneManager.LoadScene("livingroom2");
    }
}
