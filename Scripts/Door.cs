using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredKey;
    public GameObject targetRoom;
    public bool oneWay = false;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && Inventory.instance.HasItem(requiredKey))
        {
            PlayerController.currentRoom = targetRoom.name;
            other.transform.position = targetRoom.transform.position;
            Inventory.instance.RemoveItem(requiredKey);
            if (oneWay)
                gameObject.SetActive(false);
        }
    }
}