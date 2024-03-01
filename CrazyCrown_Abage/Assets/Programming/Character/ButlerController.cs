using UnityEngine;

public class ButlerController : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float stoppingDistance = 2f;
    public float waitTimeBeforeReturning = 5f;
    public AudioClip welcomeClip;

    private Transform playerTransform;
    private Vector3 initialPosition;
    private bool isMovingTowardsPlayer = false;
    private bool isWaiting = false;
    private bool isReturning = false;
    private float waitTimer = 0f;
    private bool hasTriggered = false; // Neue Variable f�r den Trigger

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        initialPosition = transform.position;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            isMovingTowardsPlayer = true;
        }
        else
        {
            Debug.LogError("Player not found!");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = welcomeClip;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Welcome")) // Nur ausl�sen, wenn noch nicht geschehen
        {
            hasTriggered = true; // Trigger-Flag setzen

            if (welcomeClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(welcomeClip);
            }
        }
    }

    private void Update()
    {
        if (isMovingTowardsPlayer && playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;
            direction.z = 0f;

            if (direction.magnitude > stoppingDistance)
            {
                transform.Translate(direction.normalized * movementSpeed * Time.deltaTime);
                spriteRenderer.flipX = direction.x < 0f;
                animator.SetBool("isWalking", true);
            }
            else
            {
                isMovingTowardsPlayer = false;
                isWaiting = true;
                waitTimer = 0f;
                animator.SetBool("isWalking", false);
            }
        }
        else if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTimeBeforeReturning)
            {
                isWaiting = false;
                isReturning = true;
            }
        }
        else if (isReturning)
        {
            Vector3 directionToInitialPosition = initialPosition - transform.position;
            directionToInitialPosition.z = 0f;

            if (directionToInitialPosition.magnitude > 0.1f)
            {
                transform.Translate(directionToInitialPosition.normalized * movementSpeed * Time.deltaTime);
                spriteRenderer.flipX = directionToInitialPosition.x < 0f;
                animator.SetBool("isWalking", true);
            }
            else
            {
                isReturning = false;
                if (!IsVisibleByCamera())
                {
                    Destroy(gameObject);
                }
                animator.SetBool("isWalking", false);
            }
        }
    }

    private bool IsVisibleByCamera()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1;
    }
}