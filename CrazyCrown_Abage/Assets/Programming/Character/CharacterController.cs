// CharacterController.cs
using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sneakSpeed = 2.5f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private bool isWalking = false;
    private bool isSneaking = false;
    private bool isSaluting = false;
    private Rigidbody2D rb;

    private bool blockPlayerInput = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Starte die Coroutine zum Blockieren der Spielerbewegung
        StartCoroutine(BlockPlayerMovementForDuration(75f)); // 75 Sekunden
    }

    void Update()
    {
        if (!blockPlayerInput)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Bewegung nach links und rechts
            Vector2 movement = new Vector2(horizontalInput, 0f);

            // Geschwindigkeit basierend auf Input und Zustand setzen
            float speed = isSneaking ? sneakSpeed : walkSpeed;
            rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

            // Animationen aktualisieren
            UpdateAnimation(horizontalInput, verticalInput);

            // Spiegeln des Charakterbilds
            if (horizontalInput < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (horizontalInput > 0)
            {
                spriteRenderer.flipX = false;
            }

            // Salutieren
            if (Input.GetKeyDown(KeyCode.S))
            {
                isSaluting = true;
                animator.SetBool("isSaluting", true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                isSaluting = false;
                animator.SetBool("isSaluting", false);
            }
        }
    }

    void UpdateAnimation(float horizontalInput, float verticalInput)
    {
        // Bewegungsanimation
        if (horizontalInput != 0f)
        {
            isWalking = true;
            animator.SetBool("isWalking", true);
        }
        else
        {
            isWalking = false;
            animator.SetBool("isWalking", false);
        }

        // Zustand für das Schleichen aktualisieren
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSneaking = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSneaking = false;
        }

        animator.SetBool("isSneaking", isSneaking);
    }

    IEnumerator BlockPlayerMovementForDuration(float duration)
    {
        blockPlayerInput = true; // Blockiere die Spielerbewegung

        yield return new WaitForSeconds(duration); // Wartezeit in Sekunden

        blockPlayerInput = false; // Aktiviere die Spielerbewegung nach Ablauf der Wartezeit
    }
}
