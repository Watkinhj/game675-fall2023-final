using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip collectSound;

    private AudioSource audioSource;

    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject soundManager = new GameObject("SoundManager");
                    instance = soundManager.AddComponent<SoundManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = collectSound;
    }

    public void PlayCollectSound()
    {
        /*
        Debug.Log("PlayCollectSound called"); 

        if (collectSound != null)
        {
            audioSource.PlayOneShot(collectSound);
            Debug.Log("Collect sound played");
        }
        else
        {
            Debug.LogWarning("Collect sound is not assigned!");
        }
        */
    }
}