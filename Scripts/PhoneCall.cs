using UnityEngine;
public class PhoneCall : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.WinGame();
        }
    }
}