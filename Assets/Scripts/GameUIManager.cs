using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI bananasText;
    
    [Header("Buttons")]
    public Button restartButton;
    public Button nextLevelButton;
    public Button pauseButton;
    
    [Header("Panels")]
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject pausePanel;
    
    [Header("Game State")]
    public int currentScore = 0;
    public int currentLevel = 1;
    public int availableBananas = 3;
    
    void Start()
    {
        UpdateUI();
        
        // Привязываем кнопки
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartLevel);
            
        if (nextLevelButton != null)
            nextLevelButton.onClick.AddListener(NextLevel);
            
        if (pauseButton != null)
            pauseButton.onClick.AddListener(TogglePause);
            
        // Скрываем панели по умолчанию
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (levelCompletePanel != null) levelCompletePanel.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);
    }
    
    public void UpdateScore(int points)
    {
        currentScore += points;
        UpdateUI();
    }
    
    public void UpdateLevel(int level)
    {
        currentLevel = level;
        UpdateUI();
    }
    
    public void UpdateBananas(int count)
    {
        availableBananas = count;
        UpdateUI();
    }
    
    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore.ToString();
            
        if (levelText != null)
            levelText.text = "Level: " + currentLevel.ToString();
            
        if (bananasText != null)
            bananasText.text = "Bananas: " + availableBananas.ToString();
    }
    
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }
    
    public void ShowLevelComplete()
    {
        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(true);
    }
    
    public void TogglePause()
    {
        if (pausePanel != null)
        {
            bool isActive = !pausePanel.activeSelf;
            pausePanel.SetActive(isActive);
            Time.timeScale = isActive ? 0f : 1f;
        }
    }
    
    void RestartLevel()
    {
        // Логика перезапуска уровня
        LoadLevel(currentLevel);
        HideGameOver();
    }
    
    void NextLevel()
    {
        // Переход к следующему уровню
        LoadLevel(currentLevel + 1);
        HideLevelComplete();
    }
    
    void LoadLevel(int levelNumber)
    {
        // Метод загрузки уровня
        Debug.Log("Loading level " + levelNumber);
        // Здесь будет логика загрузки конкретного уровня
    }
    
    void HideGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
    
    void HideLevelComplete()
    {
        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(false);
    }
}