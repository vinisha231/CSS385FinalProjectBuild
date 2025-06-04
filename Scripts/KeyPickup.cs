using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyName;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Inventory.instance.AddItem(keyName)   ;
            Destroy(gameObject);
        }
    }
}