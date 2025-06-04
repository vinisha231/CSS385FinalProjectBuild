using UnityEngine;
using TMPro;

public class ObjectiveUI : MonoBehaviour
{
    public static ObjectiveUI instance;
    public TextMeshProUGUI objectiveText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateObjective("Find the key to Room 2");
    }

    public void UpdateObjective(string obj)
    {
        objectiveText.text = "Objective: " + obj;
    }
}