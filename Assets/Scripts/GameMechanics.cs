using UnityEngine;
using System.Collections;

public class GameMechanics : MonoBehaviour
{
    [Header("Physics Settings")]
    public float gravityScale = 1f;
    
    [Header("Game Objects")]
    public GameObject[] monkeys;
    public GameObject[] buildings;
    public GameObject bananaPrefab;
    
    [Header("Game Mechanics")]
    public bool enablePhysics = true;
    
    void Start()
    {
        // Настраиваем физику для всей игры
        Physics2D.gravity = new Vector2(0, -9.81f * gravityScale);
        
        // Инициализируем все обезьяны
        InitializeMonkeys();
    }
    
    void InitializeMonkeys()
    {
        foreach (GameObject monkey in monkeys)
        {
            if (monkey != null)
            {
                Monkey monkeyScript = monkey.GetComponent<Monkey>();
                if (monkeyScript != null)
                {
                    // Здесь можно установить начальные параметры обезьяны
                    Debug.Log("Initialized monkey at " + monkey.transform.position);
                }
            }
        }
    }
    
    void Update()
    {
        // Основной игровой цикл
        if (enablePhysics)
        {
            HandleInput();
        }
    }
    
    void HandleInput()
    {
        // Перехватываем клики для броска бананов
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем позицию мыши в мире
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            
            // Бросаем банан из ближайшей обезьяны
            ThrowBananaFromNearestMonkey(mousePosition);
        }
    }
    
    void ThrowBananaFromNearestMonkey(Vector3 targetPosition)
    {
        if (monkeys.Length > 0)
        {
            // Находим ближайшую обезьяну
            GameObject nearestMonkey = GetNearestMonkey(targetPosition);
            
            if (nearestMonkey != null)
            {
                // Вычисляем направление до цели
                Vector2 direction = (targetPosition - nearestMonkey.transform.position).normalized;
                
                // Получаем скрипт обезьяны и бросаем банан
                Monkey monkeyScript = nearestMonkey.GetComponent<Monkey>();
                if (monkeyScript != null)
                {
                    // Устанавливаем направление и бросаем
                    monkeyScript.SetDirection(direction);
                    
                    // Проверяем, готова ли обезьяна к броску
                    if (monkeyScript.isReadyToThrow)
                    {
                        monkeyScript.ThrowBanana();
                    }
                }
            }
        }
    }
    
    GameObject GetNearestMonkey(Vector3 targetPosition)
    {
        GameObject nearestMonkey = null;
        float shortestDistance = Mathf.Infinity;
        
        foreach (GameObject monkey in monkeys)
        {
            if (monkey != null)
            {
                float distance = Vector3.Distance(targetPosition, monkey.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestMonkey = monkey;
                }
            }
        }
        
        return nearestMonkey;
    }
    
    public void BananaHitBuilding(GameObject banana, GameObject building)
    {
        // Логика при попадании банана в здание
        Debug.Log("Banana hit building: " + building.name);
    }
    
    public void BananaHitMonkey(GameObject banana, GameObject monkey)
    {
        // Логика при попадании банана в обезьяну
        Debug.Log("Banana hit monkey: " + monkey.name);
    }
    
    public void BananaReachedGoal(GameObject banana)
    {
        // Логика достижения цели
        Debug.Log("Banana reached goal!");
        // Здесь можно увеличивать счет или переходить к следующему уровню
    }
}