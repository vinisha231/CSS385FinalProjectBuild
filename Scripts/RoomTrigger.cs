using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public string roomName;
    public GameObject room2Kidnapper;
    public GameObject room3Kidnapper;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.currentRoom = roomName;

            if (roomName == "Room2")
            {
                room2Kidnapper.SetActive(true);
                room3Kidnapper.SetActive(false);
                KidnapperAI.shouldChase = true;
            }
            else if (roomName == "Room3")
            {
                room2Kidnapper.SetActive(false);
                room3Kidnapper.SetActive(true);
                KidnapperAI.shouldChase = true;
            }
            else
            {
                room2Kidnapper.SetActive(false);
                room3Kidnapper.SetActive(false);
            }
        }
    }
}