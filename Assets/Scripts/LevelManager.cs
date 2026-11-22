using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    [Header("Level Settings")]
    public int currentLevel = 1;
    public int totalLevels = 10;
    
    [Header("Level Elements")]
    public List<Transform> monkeySpawnPoints;
    public List<Transform> buildingPositions;
    public Transform goalPosition;
    
    [Header("Prefabs")]
    public GameObject monkeyPrefab;
    public GameObject buildingPrefab;
    
    [Header("Game Objects")]
    public List<Monkey> monkeys;
    public List<Building> buildings;
    
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
        LoadLevel(currentLevel);
    }
    
    public void LoadLevel(int levelNumber)
    {
        currentLevel = levelNumber;
        
        // Очистка старых объектов
        ClearLevel();
        
        // Создание новых объектов
        SpawnMonkeys();
        SpawnBuildings();
        SpawnGoal();
        
        Debug.Log("Loaded level " + levelNumber);
    }
    
    void ClearLevel()
    {
        // Удаление существующих обезьян
        foreach (Monkey monkey in monkeys)
        {
            if (monkey != null)
                Destroy(monkey.gameObject);
        }
        monkeys.Clear();
        
        // Удаление существующих зданий
        foreach (Building building in buildings)
        {
            if (building != null)
                Destroy(building.gameObject);
        }
        buildings.Clear();
    }
    
    void SpawnMonkeys()
    {
        foreach (Transform spawnPoint in monkeySpawnPoints)
        {
            GameObject monkeyObject = Instantiate(monkeyPrefab, spawnPoint.position, spawnPoint.rotation);
            Monkey monkey = monkeyObject.GetComponent<Monkey>();
            
            if (monkey != null)
            {
                monkeys.Add(monkey);
            }
        }
    }
    
    void SpawnBuildings()
    {
        foreach (Transform position in buildingPositions)
        {
            GameObject buildingObject = Instantiate(buildingPrefab, position.position, position.rotation);
            Building building = buildingObject.GetComponent<Building>();
            
            if (building != null)
            {
                buildings.Add(building);
            }
        }
    }
    
    void SpawnGoal()
    {
        // Логика создания цели (например, флаг или корзина)
        Debug.Log("Spawning goal at " + goalPosition.position);
    }
    
    public void NextLevel()
    {
        if (currentLevel < totalLevels)
        {
            LoadLevel(currentLevel + 1);
        }
        else
        {
            // Конец игры
            Debug.Log("Game completed!");
        }
    }
    
    public void RestartLevel()
    {
        LoadLevel(currentLevel);
    }
}