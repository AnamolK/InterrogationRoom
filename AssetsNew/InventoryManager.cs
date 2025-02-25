using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private List<string> itemList = new List<string>();


    public string[] Items
    {
        get { return itemList.ToArray(); }
    }

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddItem(string itemName)
    {
        itemList.Add(itemName);
        Debug.Log("Item added: " + itemName);
    }
}
