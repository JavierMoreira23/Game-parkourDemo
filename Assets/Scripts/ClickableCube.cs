using UnityEngine;

public class ClickableCube : MonoBehaviour
{
    public enum CubeType { Green, Red, Blue }
    
    [Header("Cube Settings")]
    public CubeType cubeType;
    
    [Header("References")]
    private HealthSystem healthSystem;
    private ScoreSystem scoreSystem;
    private AudioManager audioManager;
    
    private void Start()
    {
        // Buscar referencias en el player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            healthSystem = player.GetComponent<HealthSystem>();
            scoreSystem = player.GetComponent<ScoreSystem>();
        }
        
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    private void OnMouseDown()
    {
        // Solo funciona si el juego NO está pausado o game over
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.isGamePaused || GameManager.Instance.isGameOver)
                return;
        }
        
        switch (cubeType)
        {
            case CubeType.Green:
                // +20 health
                if (healthSystem != null)
                {
                    healthSystem.Heal(20f);
                    Debug.Log("Cubo Verde: +20 Health");
                    
                    if (audioManager != null)
                        audioManager.PlayCoinSound();
                }
                break;
                
            case CubeType.Red:
                // -15 health
                if (healthSystem != null)
                {
                    healthSystem.TakeDamage(15f);
                    Debug.Log("Cubo Rojo: -15 Health");
                    
                    if (audioManager != null)
                        audioManager.PlayDamageSound();
                }
                break;
                
            case CubeType.Blue:
                // +10 score
                if (scoreSystem != null)
                {
                    scoreSystem.AddScore(10);
                    Debug.Log("Cubo Azul: +10 Score");
                    
                    if (audioManager != null)
                        audioManager.PlayStepSound();
                }
                break;
        }
    }
}
