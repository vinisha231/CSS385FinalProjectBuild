using UnityEngine;

public class KidnapperAIroom3 : MonoBehaviour
{
    // room boundaries (will need to change for a seperate kidnapper depending on room)
    public float minX = 0f;
    public float maxX = 0f;
    public float minY = 0f;
    public float maxY = 0f;
    public float speed = 0f;
    public float wanderRadius = 3f;
    public Transform player;

    private Vector2 wanderTarget;
    private bool isWandering = false;
    public static bool shouldChase;
    
    void Update()
    {
        if (PlayerController.currentRoom == "Room3")
        {
            if (HidingSpot.isPlayerInside)
            {
                WanderRandomly();
            }
            else
            {
                ChasePlayer();
            }
        }
    }

    void ChasePlayer()
    {
        isWandering = false;
        Vector2 targetPosition = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);
    
        transform.position = targetPosition;
    }

    void WanderRandomly()
    {
        if (!isWandering || Vector2.Distance(transform.position, wanderTarget) < 0.2f)
        {
            wanderTarget = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)
            );
            isWandering = true;
        }

        Vector2 targetPosition = Vector2.MoveTowards(transform.position, wanderTarget, speed * Time.deltaTime);
    
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);
    
        transform.position = targetPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !HidingSpot.isPlayerInside)
        {
            GameManager.instance.ShowGameOver();
        }
    }
}