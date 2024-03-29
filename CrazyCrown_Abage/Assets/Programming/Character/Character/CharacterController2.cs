using UnityEngine;
using System.Collections;

public class CharacterController2 : MonoBehaviour
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
    }

    void Update()
    {
        if (!blockPlayerInput)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Wenn der Spieler nicht salutiert, kann er sich bewegen
            if (!isSaluting)
            {
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
            }

            // Salutieren
            if (Input.GetKeyDown(KeyCode.S))
            {
                isSaluting = true;
                animator.SetBool("isSaluting", true);
                animator.SetBool("isWalking", false);
                // Blockiere die Bewegung, wenn der Spieler salutiert
                rb.velocity = Vector2.zero;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                isSaluting = false;
                animator.SetBool("isSaluting", false);
                animator.SetBool("isWalking", true);
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

        // Zustand f�r das Schleichen aktualisieren
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
}