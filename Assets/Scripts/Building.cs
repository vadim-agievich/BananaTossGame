using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
    [Header("Building Properties")]
    public int health = 100;
    public int scoreValue = 50;
    
    [Header("Visual Effects")]
    public Sprite damagedSprite;
    public Color damagedColor = Color.red;
    
    private SpriteRenderer spriteRenderer;
    private bool isDestroyed = false;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Banana") && !isDestroyed)
        {
            TakeDamage(10); // Предполагаем, что банан наносит урон зданию
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            DestroyBuilding();
        }
        else
        {
            ApplyDamageEffect();
        }
    }
    
    void ApplyDamageEffect()
    {
        // Применяем визуальные эффекты при получении урона
        if (damagedSprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = damagedSprite;
        }
        
        if (spriteRenderer != null)
        {
            spriteRenderer.color = damagedColor;
        }
        
        // Возвращаем нормальный цвет через некоторое время
        Invoke("ResetDamageEffect", 0.5f);
    }
    
    void ResetDamageEffect()
    {
        if (spriteRenderer != null && damagedSprite != null)
        {
            spriteRenderer.sprite = null; // Возвращаем исходный спрайт
            spriteRenderer.color = Color.white;
        }
    }
    
    void DestroyBuilding()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            Debug.Log("Building destroyed! Score: " + scoreValue);
            
            // Здесь можно добавить эффекты разрушения
            
            // Удаление здания
            Destroy(gameObject);
        }
    }
}