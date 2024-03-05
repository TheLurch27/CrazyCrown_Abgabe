using UnityEngine;

public class LinnetController : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask playerLayer;
    public Animator animator;

    private bool isAwake = false;

    private void Update()
    {
        CheckForPlayer();
        UpdateAnimation();
    }

    private void CheckForPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Rigidbody2D playerRB = collider.GetComponent<Rigidbody2D>();
                if (playerRB != null)
                {
                    if (playerRB.velocity.magnitude > 2.5f)
                    {
                        isAwake = true;
                    }
                    else
                    {
                        isAwake = false;
                    }
                    return;
                }
            }
        }

        // Wenn kein Spieler in Reichweite ist, bleibt Linnet schlafend
        isAwake = false;
    }

    private void UpdateAnimation()
    {
        animator.SetBool("isAwake", isAwake);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
