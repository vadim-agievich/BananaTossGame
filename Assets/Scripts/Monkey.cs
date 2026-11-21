using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour
{
    [Header("Monkey Properties")]
    public float throwForce = 20f;
    public float monkeySpeed = 5f;
    public int maxBananas = 5;
    
    [Header("References")]
    public GameController gameController;
    public Transform targetTransform;
    
    private Rigidbody2D rb;
    private Vector2 direction;
    private bool isReadyToThrow = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameController.Instance;
    }
    
    void Update()
    {
        if (gameController.isGameActive && isReadyToThrow)
        {
            HandleInput();
        }
    }
    
    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowBanana();
        }
    }
    
    void ThrowBanana()
    {
        // Создаем банан
        GameObject bananaObject = Instantiate(
            GameController.Instance.bananaPrefab,
            transform.position,
            Quaternion.identity
        );
        
        Banana banana = bananaObject.GetComponent<Banana>();
        if (banana != null)
        {
            banana.Throw(direction, gameController.bananaSpeed);
        }
        
        isReadyToThrow = false;
        StartCoroutine(ResetThrow());
    }
    
    IEnumerator ResetThrow()
    {
        yield return new WaitForSeconds(0.5f);
        isReadyToThrow = true;
    }
    
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Building"))
        {
            // Логика столкновения с зданием
            Debug.Log("Monkey hit building");
        }
    }
}