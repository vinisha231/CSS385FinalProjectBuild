using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public Volume deathVolume;
    private Vignette vignette;

    public TMP_Text gameOverText;  

    public static string currentRoom;
    public static PlayerController instance;
    public bool isHiding = false;
    public TMP_Text hidingMessageText;   

    public void ShowHidingMessage(string message)
    {
        StopAllCoroutines();   
        StartCoroutine(ShowHidingMessageRoutine(message));
    }

    IEnumerator ShowHidingMessageRoutine(string message)
    {
        hidingMessageText.text = message;
        hidingMessageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        hidingMessageText.gameObject.SetActive(false);
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deathVolume.profile.TryGet(out vignette);
        vignette.intensity.value = 0f;  // start with vignette off
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    public void TriggerDeath()
    {
        StartCoroutine(DeathVignette());
        StartCoroutine(GlitchText());
    }

    IEnumerator DeathVignette()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            vignette.intensity.value = Mathf.Lerp(0f, 0.5f, t);
            yield return null;
        }
    }

    IEnumerator GlitchText()
    {
        string baseText = "GAME OVER";
        TMP_Text txt = gameOverText;

        for (int i = 0; i < 10; i++)
        {
            txt.text = Glitchify(baseText);
            yield return new WaitForSeconds(0.05f);
        }

        txt.text = baseText;
    }

    string Glitchify(string text)
    {
        string chars = "!@#$%^&*";
        char[] glitched = text.ToCharArray();
        for (int i = 0; i < glitched.Length; i++)
        {
            if (Random.value < 0.3f)
                glitched[i] = chars[Random.Range(0, chars.Length)];
        }
        return new string(glitched);
    }
}