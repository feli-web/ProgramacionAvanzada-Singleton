using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioClip shootSound;
    public AudioClip explosionSound;

    private AudioSource audioSource;

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

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "shoot":
                audioSource.PlayOneShot(shootSound);
                break;
            case "explosion":
                audioSource.PlayOneShot(explosionSound);
                break;
            default:
                Debug.LogWarning("No hay un sonido asociado con: " + soundName);
                break;
        }
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}
