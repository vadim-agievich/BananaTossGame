using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    [Header("Game Settings")]
    public float bananaSpeed = 10f;
    public int initialBananas = 3;
    
    [Header("Objects")]
    public GameObject monkeyPrefab;
    public GameObject bananaPrefab;
    public GameObject buildingPrefab;
    
    [Header("Game State")]
    public bool isGameActive = false;
    public int currentLevel = 1;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        InitializeGame();
    }
    
    void InitializeGame()
    {
        // Инициализация игровых параметров
        isGameActive = true;
    }
    
    public void StartLevel(int levelNumber)
    {
        // Запуск уровня
        currentLevel = levelNumber;
        Debug.Log("Starting level " + levelNumber);
    }
    
    public void EndGame()
    {
        isGameActive = false;
        Debug.Log("Game ended");
    }
}