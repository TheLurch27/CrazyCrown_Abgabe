using UnityEngine;

public class QueenController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform leftWall;
    public Transform rightWall;
    public Collider2D triggerCollider; // Variable für den Trigger-Collider

    private bool movingRight = true;
    private SpriteRenderer spriteRenderer;

    private void Update()
    {

        // NPC von Wand zu Wand bewegen
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            if (transform.position.x >= rightWall.position.x)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= leftWall.position.x)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    // Funktion zum Flippen der NPC-Richtung
    private void Flip()
    {
        // Die Richtung des NPCs umkehren
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
