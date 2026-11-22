using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI bananasText;
    public Button restartButton;
    public Button nextLevelButton;
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    
    [Header("Game State")]
    public int currentScore = 0;
    public int currentBananas = 3;
    public int currentLevel = 1;
    
    void Start()
    {
        UpdateUI();
        
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartLevel);
            
        if (nextLevelButton != null)
            nextLevelButton.onClick.AddListener(NextLevel);
    }
    
    public void UpdateScore(int points)
    {
        currentScore += points;
        UpdateUI();
    }
    
    public void UpdateBananas(int count)
    {
        currentBananas = count;
        UpdateUI();
    }
    
    public void UpdateLevel(int level)
    {
        currentLevel = level;
        UpdateUI();
    }
    
    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore.ToString();
            
        if (levelText != null)
            levelText.text = "Level: " + currentLevel.ToString();
            
        if (bananasText != null)
            bananasText.text = "Bananas: " + currentBananas.ToString();
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
    
    void RestartLevel()
    {
        LevelManager.Instance.RestartLevel();
        HideGameOver();
    }
    
    void NextLevel()
    {
        LevelManager.Instance.NextLevel();
        HideLevelComplete();
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