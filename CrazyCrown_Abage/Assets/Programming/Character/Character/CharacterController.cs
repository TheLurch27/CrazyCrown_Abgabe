using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float crouchSpeed = 2f;
    
    private float walkSpeed = 5f;

    private bool isWalking;
    private bool isSneaking;
    private bool isInteracting;
    private bool isSaluting;

    private Animator animator;

    void Start()
    {
<<<<<<< Updated upstream:CrazyCrown_Abage/Assets/Programming/Character/Character/CharacterController.cs
        rb = GetComponent<Rigidbody2D>();

        // StartCoroutine(BlockPlayerMovementForDuration(75f)); // 75 Sekunden
=======
        animator = GetComponent<Animator>();
>>>>>>> Stashed changes:CrazyCrown_Abage/Assets/Programming/Character/CharacterController.cs
    }

    void Update()
    {
<<<<<<< Updated upstream:CrazyCrown_Abage/Assets/Programming/Character/Character/CharacterController.cs
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
=======
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift) && !isSaluting && !isInteracting)
        {
            moveSpeed = crouchSpeed;
            isSneaking = true;
        }
        else
        {
            moveSpeed = walkSpeed;
            isSneaking = false;
        }

        // **Änderung:** Bewegung wird beim Salutieren oder Interagieren unterbunden
        if (isSaluting || isInteracting)
        {
            moveInput = 0f;
>>>>>>> Stashed changes:CrazyCrown_Abage/Assets/Programming/Character/CharacterController.cs
        }

        if (moveInput != 0)
        {
            isWalking = true;
            transform.Translate(new Vector3(moveInput * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        else
        {
            isWalking = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            isSaluting = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            isSaluting = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            isInteracting = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isInteracting = false;
        }

<<<<<<< Updated upstream:CrazyCrown_Abage/Assets/Programming/Character/Character/CharacterController.cs
    // IEnumerator BlockPlayerMovementForDuration(float duration)
    // {
    //     blockPlayerInput = true; // Blockiere die Spielerbewegung
    // 
    //     yield return new WaitForSeconds(duration); // Wartezeit in Sekunden
    // 
    //     blockPlayerInput = false; // Aktiviere die Spielerbewegung nach Ablauf der Wartezeit
    // }
}
=======
        // **Änderung:** Animator-Parameter werden beim Salutieren oder Interagieren aktualisiert
        animator.SetBool("isWalking", isWalking && !isSaluting && !isInteracting);
        animator.SetBool("isSneaking", isSneaking && !isSaluting && !isInteracting);
        animator.SetBool("isInteracting", isInteracting);
        animator.SetBool("isSaluting", isSaluting);
    }
}
>>>>>>> Stashed changes:CrazyCrown_Abage/Assets/Programming/Character/CharacterController.cs
