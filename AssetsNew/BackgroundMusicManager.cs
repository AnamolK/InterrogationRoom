using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    // Assign your MP3 file to this variable in the Inspector.
    public AudioClip backgroundMusic;
    
    // The AudioSource component that will play the music.
    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure that only one instance of MusicManager exists.
        if (FindObjectsOfType<BackgroundMusicManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        // Prevent this object from being destroyed when switching scenes.
        DontDestroyOnLoad(gameObject);

        // Add an AudioSource component if one isn't already attached.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set up the AudioSource properties.
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f; // Adjust volume as needed.
    }

    private void Start()
    {
        // Start playing the background music.
        audioSource.Play();
    }
}
