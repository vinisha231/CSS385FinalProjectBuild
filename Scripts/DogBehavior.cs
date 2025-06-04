using UnityEngine;

public class DogBehavior : MonoBehaviour
{
    public Transform kidnapper;
    public Transform player;
    public float barkDistance = 0.5f;
    public AudioSource barkAudio;
    public AudioClip barkClip;
    public AudioClip petClip;

    public float followSpeed = 3f;
    public float followDistance = 1f; // how close to stay

    private float idleTime = 0f;
    private float checkInterval = 1f;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = player.position;
        InvokeRepeating("CheckForBark", 0f, checkInterval);
    }

    void Update()
    {
        // Player idle check
        if (Vector3.Distance(player.position, lastPlayerPosition) < 0.1f)
        {
            idleTime += Time.deltaTime;
            if (idleTime >= 10f)
            {
                Bark(); // bark if idle
                idleTime = 0f;
            }
        }
        else
        {
            idleTime = 0f;
        }

        lastPlayerPosition = player.position;
    }

    void LateUpdate()
    {
        // FOLLOW PLAYER behavior
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > followDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
        }
    }

    void CheckForBark()
    {
        float dist = Vector3.Distance(transform.position, kidnapper.position);

        if (dist <= barkDistance)
        {
            if (!barkAudio.isPlaying)
            {
                barkAudio.loop = true;
                barkAudio.clip = barkClip;
                barkAudio.Play();
            }
        }
        else
        {
            if (barkAudio.isPlaying)
            {
                barkAudio.Stop();
            }
        }
    }

    void Bark()
    {
        if (barkAudio && barkClip)
        {
            barkAudio.PlayOneShot(barkClip);
        }
    }

    //pet the dog with E key
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (barkAudio && petClip)
                barkAudio.PlayOneShot(petClip);
        }
    }
}