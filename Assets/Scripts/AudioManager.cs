using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip coin;
    public AudioClip step;
    public AudioClip hurt; // Renombré "damage" a "hurt" para evitar confusión con el botón
    
    private AudioSource audioSource;
    
    void Awake()
    {
        // Obtener o agregar AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    
    public void PlayCoinSound()
    {
        if (coin != null)
        {
            audioSource.PlayOneShot(coin);
        }
    }
    
    public void PlayStepSound()
    {
        if (step != null)
        {
            audioSource.PlayOneShot(step);
        }
    }
    
    public void PlayDamageSound()
    {
        if (hurt != null)
        {
            audioSource.PlayOneShot(hurt);
        }
    }
}