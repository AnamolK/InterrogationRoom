using UnityEngine;

public class InventoryFlipThrough : MonoBehaviour
{
    public GameObject[] assets; // Array to store different assets
    private int currentIndex = 0;
    private GameObject currentAsset;

    void Start()
    {
        if (assets.Length > 0)
        {
            currentAsset = Instantiate(assets[currentIndex], transform.position, transform.rotation);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchAsset(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchAsset(-1);
        }
    }

    void SwitchAsset(int direction)
    {
        if (assets.Length == 0) return;

        currentIndex += direction;
        if (currentIndex >= assets.Length) currentIndex = 0;
        if (currentIndex < 0) currentIndex = assets.Length - 1;

        if (currentAsset != null)
        {
            Destroy(currentAsset);
        }

        currentAsset = Instantiate(assets[currentIndex], transform.position, transform.rotation);
    }
}
