using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Referencias a Sistemas")]
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private ScoreSystem scoreSystem;

    [Header("UI Panels")]
    public GameObject initialPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;

    [Header("Game UI - Textos")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;

    [Header("Buttons")]
    public Button startButton;
    public Button restartButton;

    private float health;
    private int score;

    private void Awake()
    {
        ShowInitialUI();
    }

    private void Start()
    {
        if (healthSystem != null)
        {
            healthSystem.OnHealthChanged.AddListener(UpdateHealth);

            // 🔥 FORZAR actualización inicial
            UpdateHealth(healthSystem.GetHealthPercentage());
        }

        if (scoreSystem != null)
        {
            scoreSystem.OnScoreChanged.AddListener(UpdateScore);

            // 🔥 FORZAR actualización inicial
            UpdateScore(scoreSystem.GetCurrentScore());
        }

        if (startButton != null)
            startButton.onClick.AddListener(OnStartButtonClicked);

        if (restartButton != null)
            restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    public void ShowInitialUI()
    {
        initialPanel?.SetActive(true);
        gamePanel?.SetActive(false);
        gameOverPanel?.SetActive(false);
    }

    public void ShowGameUI()
    {
        initialPanel?.SetActive(false);
        gamePanel?.SetActive(true);
        gameOverPanel?.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        initialPanel?.SetActive(false);
        gamePanel?.SetActive(false);
        gameOverPanel?.SetActive(true);

        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + score.ToString();
    }

    private void UpdateHealth(float healthPercentage)
    {
        health = healthPercentage * 100f;

        if (healthText != null)
            healthText.text = "Health: " + health.ToString("F0") + "%";
    }

    private void UpdateScore(int newScore)
    {
        score = newScore;

        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    private void OnStartButtonClicked()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.StartGame();
    }

    private void OnRestartButtonClicked()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}