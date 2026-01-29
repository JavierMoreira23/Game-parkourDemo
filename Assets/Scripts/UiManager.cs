using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class UiManager : MonoBehaviour
{
    public float health ;
    public float speed;
    public float score; 
    public float sprint;
    
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI sprintText;
    
    public Button damage;
    public Button healing;
    public Button spacePressed;
    
    private AudioManager audioManager;

    void Start()
    {
        // Obtener referencia al AudioManager
        audioManager = FindObjectOfType<AudioManager>();
        
        // Actualizar UI inicial
        UpdateUI();
    }
    
    void Update()
    {
        // Detectar botón izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseButtonPressed();
        }
        
        // Detectar botón derecho del mouse
        if (Input.GetMouseButtonDown(1))
        {
            RightMouseButtonPressed();
        }
        
        // Detectar tecla espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceKeyPressed();
        }
    }
    
    // Botón izquierdo del mouse
    public void LeftMouseButtonPressed()
    {
        health -= 5;
        score -= 100;
        
        // Cambiar color del botón Damage a rojo
        ColorBlock colors = damage.colors;
        colors.normalColor = Color.red;
        damage.colors = colors;
        
        // Reproducir sonido de hurt/damage
        if (audioManager != null)
        {
            audioManager.PlayDamageSound();
        }
        
        UpdateUI();
    }
    
    // Botón derecho del mouse
    public void RightMouseButtonPressed()
    {
        health += 5;
        score += 100;
        
        // Cambiar color del botón Healing a verde
        ColorBlock colors = healing.colors;
        colors.normalColor = Color.green;
        healing.colors = colors;
        
        // Reproducir sonido de coin
        if (audioManager != null)
        {
            audioManager.PlayCoinSound();
        }
        
        UpdateUI();
    }
    
    // Tecla espacio
    public void SpaceKeyPressed()
    {
        speed += 1;
        
        // Si speed es múltiplo de 5, asignar a sprint
        if (speed % 5 == 0)
        {
            sprint = speed;
        }
        
        // Cambiar color del botón Space Pressed a azul
        ColorBlock colors = spacePressed.colors;
        colors.normalColor = Color.blue;
        spacePressed.colors = colors;
        
        // Reproducir sonido de step
        if (audioManager != null)
        {
            audioManager.PlayStepSound();
        }
        
        UpdateUI();
    }
    
    // Actualizar todos los textos de la UI
    void UpdateUI()
    {
        healthText.text = "Health: " + health.ToString();
        speedText.text = "Speed: " + speed.ToString();
        scoreText.text = "Score: " + score.ToString();
        sprintText.text = "Sprint: " + sprint.ToString();
    }
}
