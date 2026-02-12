using UnityEngine;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour
{
    [Header("Score")]
    private int currentScore = 0;
    
    [Header("Events")]
    public UnityEvent<int> OnScoreChanged; // Pasa el score actual
    
    private void Start()
    {
        OnScoreChanged?.Invoke(currentScore);
    }
    
    public void AddScore(int points)
    {
        currentScore += points;
        OnScoreChanged?.Invoke(currentScore);
        Debug.Log("Score: " + currentScore);
    }
    
    public int GetCurrentScore()
    {
        return currentScore;
    }
}