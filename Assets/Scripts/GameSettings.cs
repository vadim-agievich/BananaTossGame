using UnityEngine;

[System.Serializable]
public class GameSettings : ScriptableObject
{
    [Header("Gameplay Settings")]
    public float bananaSpeed = 10f;
    public float throwForce = 20f;
    public int initialBananas = 3;
    public int maxBananasPerMonkey = 5;
    
    [Header("Difficulty Settings")]
    public float difficultyMultiplier = 1.0f;
    public int pointsPerBanana = 10;
    public int pointsPerBuilding = 50;
    
    [Header("Level Settings")]
    public int totalLevels = 20;
    public int buildingsPerLevel = 5;
    public int monkeysPerLevel = 2;
    
    [Header("Visual Settings")]
    public bool enableParticles = true;
    public bool enableSound = true;
    public bool enableVibration = true;
    
    [Header("Controls")]
    public bool touchControls = true;
    public float swipeSensitivity = 1.0f;
    
    // Метод для сброса настроек к значениям по умолчанию
    public void ResetToDefaults()
    {
        bananaSpeed = 10f;
        throwForce = 20f;
        initialBananas = 3;
        maxBananasPerMonkey = 5;
        difficultyMultiplier = 1.0f;
        pointsPerBanana = 10;
        pointsPerBuilding = 50;
        totalLevels = 20;
        buildingsPerLevel = 5;
        monkeysPerLevel = 2;
        enableParticles = true;
        enableSound = true;
        enableVibration = true;
        touchControls = true;
        swipeSensitivity = 1.0f;
    }
    
    // Метод для увеличения сложности
    public void IncreaseDifficulty()
    {
        difficultyMultiplier += 0.1f;
        bananaSpeed *= 1.1f;
        throwForce *= 1.1f;
    }
}