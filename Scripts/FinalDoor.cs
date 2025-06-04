using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalDoor : MonoBehaviour
{
    public AudioSource winAudio;
    public GameObject winPanel;
    public TMP_Text winText;

    private bool hasWon = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasWon && other.CompareTag("Player"))
        {
            hasWon = true;
            winAudio.Play();
            winPanel.SetActive(true);
            winText.text = "YOU WIN!!!";
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}