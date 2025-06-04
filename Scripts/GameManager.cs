using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameManager instance;
    public GameObject winScreen;

    void Awake() => instance = this;

    public void WinGame()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}