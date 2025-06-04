using UnityEngine;
public class Interactable : MonoBehaviour
{
    public string itemName;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.instance.AddItem(itemName);
            gameObject.SetActive(false);
        }
    }
}