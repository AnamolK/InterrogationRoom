using UnityEngine;
using UnityEngine.UI;

public class TextSwitcher : MonoBehaviour
{
    public string[] texts; // Array to store different texts
    private int currentIndex = 0;
    public Text displayText;

    void Start()
    {
        if (texts.Length > 0 && displayText != null)
        {
            displayText.text = texts[currentIndex];
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchText(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchText(-1);
        }
    }

    void SwitchText(int direction)
    {
        if (texts.Length == 0 || displayText == null) return;

        currentIndex += direction;
        if (currentIndex >= texts.Length) currentIndex = 0;
        if (currentIndex < 0) currentIndex = texts.Length - 1;

        displayText.text = texts[currentIndex];
    }
}
