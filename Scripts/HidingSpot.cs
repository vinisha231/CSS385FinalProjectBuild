using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public static bool isPlayerInside = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            PlayerController.instance.isHiding = true;
            PlayerController.instance.ShowHidingMessage("You are now hidden");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            PlayerController.instance.isHiding = false;
            PlayerController.instance.ShowHidingMessage("You have left hiding spot");
        }
    }
}