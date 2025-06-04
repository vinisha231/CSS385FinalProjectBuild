using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject dogNPC;
    public GameObject inventoryText;
    public GameObject objectiveText;

    public static bool isLevel2 = false;

    void Start()
    {
        Time.timeScale = 0f; // pause the game at the beginning
        inventoryText.SetActive(false);
        objectiveText.SetActive(false);
    }

    public void PlayLevel1()
    {
        isLevel2 = false;
        dogNPC.SetActive(true);
        instructionsPanel.SetActive(false);
        inventoryText.SetActive(true);
        objectiveText.SetActive(true);
        Time.timeScale = 1f;
    }

    public void PlayLevel2()
    {
        isLevel2 = true;
        dogNPC.SetActive(false);
        instructionsPanel.SetActive(false);
        inventoryText.SetActive(true);
        objectiveText.SetActive(true);
        Time.timeScale = 1f;
    }
}