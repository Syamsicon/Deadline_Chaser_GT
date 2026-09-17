using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip typeCorrectSound;
    [SerializeField] private AudioClip typeWrongSound;
    [SerializeField] private AudioClip heartLossSound;

    void Awake()
    {
        Instance = this;
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void PlayTypeSound()
    {
        if (typeCorrectSound != null)
            audioSource.PlayOneShot(typeCorrectSound);
    }

    public void PlayWrongSound()
    {
        if (typeWrongSound != null)
            audioSource.PlayOneShot(typeWrongSound);
    }

    public void PlayHeartLossSound()
    {
        if (heartLossSound != null)
            audioSource.PlayOneShot(heartLossSound);
    }
}