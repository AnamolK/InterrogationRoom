using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    [Header("Transition Settings")]
    [Tooltip("Name of the scene to load when entering this door.")]
    public string sceneToLoad;

    [Tooltip("Optional delay before transitioning (in seconds).")]
    public float transitionDelay = 0f;

    // This method is called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object is the player by tag
        if (other.CompareTag("Player"))
        {
            // Optionally use a delay before loading the scene
            if (transitionDelay > 0f)
            {
                Invoke("LoadScene", transitionDelay);
            }
            else
            {
                LoadScene();
            }
        }
    }

    // This method loads the new scene
    private void LoadScene()
    {
        // Make sure the scene name you enter is added in the Build Settings
        SceneManager.LoadScene(sceneToLoad);
    }
}
