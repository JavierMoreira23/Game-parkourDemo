using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance { get; private set; }
    
    [Header("Game States")]
    public bool isGamePaused = false;
    public bool isGameOver = false;
    
    [Header("Events")]
    public UnityEvent OnGameStart;
    public UnityEvent OnGamePause;
    public UnityEvent OnGameOverEvent;
    
    private void Awake()
    {
        // Implementación Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void StartGame()
    {
        isGamePaused = false;
        isGameOver = false;
        Time.timeScale = 1f;
        
        OnGameStart?.Invoke();
        Debug.Log("Game Started!");
    }
    
    public void PauseGame()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0f : 1f;
        
        OnGamePause?.Invoke();
        Debug.Log("Game Paused: " + isGamePaused);
    }
    
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        
        OnGameOverEvent?.Invoke();
        Debug.Log("Game Over!");
    }
}
