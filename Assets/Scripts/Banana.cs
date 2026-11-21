using UnityEngine;
using System.Collections;

public class Banana : MonoBehaviour
{
    [Header("Banana Properties")]
    public float bananaSpeed = 10f;
    public int bananaDamage = 10;
    
    private Rigidbody2D rb;
    private bool isFlying = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (isFlying)
        {
            // Обновление поведения банана во время полета
            CheckIfGrounded();
        }
    }
    
    public void Throw(Vector2 direction, float force)
    {
        rb.AddForce(direction * force, ForceMode2D.Impulse);
        isFlying = true;
        
        // Устанавливаем ограничения на скорость
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, bananaSpeed);
    }
    
    void CheckIfGrounded()
    {
        // Проверяем, коснулся ли банан земли или объекта
        if (rb.velocity.magnitude < 0.1f && transform.position.y < 0.5f)
        {
            // Банан приземлился
            Destroy(gameObject, 1f);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Building"))
        {
            // Отскок от здания
            BounceOffBuilding(other);
        }
        else if (other.CompareTag("Monkey"))
        {
            // Попадание в обезьяну
            HitMonkey(other);
        }
        else if (other.CompareTag("Goal"))
        {
            // Доставка банана в цель
            ReachedGoal();
        }
    }
    
    void BounceOffBuilding(Collider2D building)
    {
        // Логика отскока банана от здания
        Vector2 normal = (transform.position - building.transform.position).normalized;
        Vector2 reflected = Vector2.Reflect(rb.velocity, normal);
        
        rb.velocity = reflected * 0.8f; // Небольшая потеря энергии
        
        Debug.Log("Banana bounced off building");
    }
    
    void HitMonkey(Collider2D monkey)
    {
        // Банан попал в обезьяну
        Monkey monkeyScript = monkey.GetComponent<Monkey>();
        if (monkeyScript != null)
        {
            // Можно добавить логику получения урона
            Debug.Log("Banana hit monkey!");
            
            // Уничтожаем банан после попадания
            Destroy(gameObject);
        }
    }
    
    void ReachedGoal()
    {
        // Банан достиг цели
        Debug.Log("Banana reached the goal!");
        
        // Добавляем очки или переход к следующему уровню
        Destroy(gameObject);
    }
}