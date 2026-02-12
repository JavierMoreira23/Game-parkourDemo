using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Settings")]
    public int scoreValue = 10;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener ScoreSystem del player
            ScoreSystem scoreSystem = other.GetComponent<ScoreSystem>();
            
            if (scoreSystem != null)
            {
                scoreSystem.AddScore(scoreValue);
            }
            
            // Reproducir sonido
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null)
            {
                audioManager.PlayCoinSound();
            }
            
            // Destruir objeto
            Destroy(gameObject);
        }
    }
}
