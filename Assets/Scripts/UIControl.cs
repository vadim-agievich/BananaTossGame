using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour
{
    [Header("UI Elements")]
    public Button throwButton;
    public Button restartButton;
    public Button nextLevelButton;
    public TextMeshProUGUI statusText;
    
    [Header("Game References")]
    public GameObject[] monkeys;
    public GameObject bananaPrefab;
    
    private int selectedMonkeyIndex = 0;
    private bool isThrowing = false;
    
    void Start()
    {
        InitializeUI();
    }
    
    void InitializeUI()
    {
        // Привязываем события кнопок
        if (throwButton != null)
            throwButton.onClick.AddListener(ThrowBanana);
            
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartLevel);
            
        if (nextLevelButton != null)
            nextLevelButton.onClick.AddListener(NextLevel);
            
        // Изначально скрываем статус
        if (statusText != null)
            statusText.text = "";
    }
    
    void ThrowBanana()
    {
        if (isThrowing || monkeys.Length == 0)
            return;
            
        // Проверяем наличие активных обезьян
        if (selectedMonkeyIndex >= monkeys.Length || monkeys[selectedMonkeyIndex] == null)
            return;
            
        // Получаем компонент обезьяны
        Monkey monkey = monkeys[selectedMonkeyIndex].GetComponent<Monkey>();
        if (monkey != null)
        {
            // Имитируем бросок
            if (monkey.IsReadyToThrow())
            {
                // Установка направления (вправо)
                Vector2 direction = Vector2.right;
                monkey.SetDirection(direction);
                monkey.ThrowBanana();
                
                isThrowing = true;
                
                // Сбрасываем флаг через некоторое время
                Invoke("ResetThrowing", 0.5f);
            }
        }
    }
    
    void ResetThrowing()
    {
        isThrowing = false;
    }
    
    void RestartLevel()
    {
        // Логика перезапуска уровня
        Debug.Log("Restarting level...");
        if (statusText != null)
            statusText.text = "Level restarted";
            
        // Здесь можно вызвать метод перезапуска уровня из LevelManager
    }
    
    void NextLevel()
    {
        // Переход к следующему уровню
        Debug.Log("Next level...");
        if (statusText != null)
            statusText.text = "Next level";
            
        // Здесь можно вызвать метод перехода к следующему уровню из LevelManager
    }
    
    public void SelectMonkey(int index)
    {
        if (index >= 0 && index < monkeys.Length)
        {
            selectedMonkeyIndex = index;
            if (statusText != null)
                statusText.text = "Selected monkey " + (index + 1);
        }
    }
}