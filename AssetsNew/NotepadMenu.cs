using UnityEngine;
using UnityEngine.UI;

public class NotepadMenu : MonoBehaviour
{
    // A static variable to hold all the player's notes.
    // Being static means it persists between different instances of this script.
    public static string myNotes = "";

    // A reference to the entire notepad menu panel.
    // This is the parent GameObject for all the notepad UI elements.
    public GameObject notepadPanel;

    // A reference to the Input Field used for entering new notes.
    public InputField noteInputField;

    // A reference to the Text component that displays the accumulated notes.
    public Text notesDisplay;

    private void Start()
    {
        // When the game starts, ensure the notepad menu is hidden.
        // This is done by deactivating the notepad panel.
        if (notepadPanel != null)
            notepadPanel.SetActive(false);
    }

    // This method toggles the notepad menu on and off.
    public void ToggleNotepad()
    {
        if (notepadPanel != null)
        {
            // Check if the panel is currently active.
            bool isActive = notepadPanel.activeSelf;
            // Toggle the active state (if it's active, hide it; if it's hidden, show it).
            notepadPanel.SetActive(!isActive);

            // If we are showing the panel, update the text display to show all the saved notes.
            if (!isActive)
            {
                notesDisplay.text = myNotes;
            }
        }
    }

    // This method is called when the "Add Note" button is clicked.
    public void AddNote()
    {
        if (noteInputField != null && notesDisplay != null)
        {
            // Get the text that the player entered into the Input Field.
            string newNote = noteInputField.text;
            if (!string.IsNullOrEmpty(newNote))
            {
                // If there are already notes saved, append a newline before adding the new note.
                myNotes += (string.IsNullOrEmpty(myNotes) ? "" : "\n") + newNote;

                // Update the Text component to display the new list of notes.
                notesDisplay.text = myNotes;

                // Clear the Input Field so the player can enter a new note.
                noteInputField.text = "";
            }
        }
    }
}
