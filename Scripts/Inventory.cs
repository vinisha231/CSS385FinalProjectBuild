using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro; 

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public TMP_Text inventoryText;

    private List<string> items = new List<string>();

    void Awake() => instance = this;

    public void AddItem(string item)
    {
        items.Add(item);
        UpdateUI();
    }

    public bool HasItem(string item) => items.Contains(item);

    public void RemoveItem(string item)
    {
        items.Remove(item);
        UpdateUI();
    }

    void UpdateUI()
    {
        inventoryText.text = "Inventory: " + string.Join(", ", items);
    }
}