using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GameObject normalPortrait; // Referenz auf das normale Portrait UI-Element
    public GameObject smearPortrait; // Referenz auf das verschmierte Portrait UI-Element
    public Collider2D triggerPoint; // Referenz auf den Collider des TaskTriggers
    public AudioClip audioClip; // Referenz auf die AudioSource
    public GameObject activateQueenReactionTrigger; // Referenz auf das Game Object, das nach dem Abspielen des Audio-Clips eingeblendet werden soll

    private bool portraitsSwapped = false; // Flag, um zu verfolgen, ob die Portr�ts bereits getauscht wurden

    private void Update()
    {
        // �berpr�fe, ob der Spieler sich im Bereich des triggerPoint befindet und die E-Taste gedr�ckt wird
        if (Input.GetKeyDown(KeyCode.E) && triggerPoint.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            // �berpr�fe, ob der Edding aktiv ist
            if (InventoryManager.instance != null && InventoryManager.instance.eddingImage.activeSelf)
            {
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                // Tausche die Portr�ts
                normalPortrait.SetActive(false);
                smearPortrait.SetActive(true);
                portraitsSwapped = true; // Setze das Flag, um anzuzeigen, dass die Portr�ts getauscht wurden

                // Einblenden des Game Objects nach dem Abspielen des Audio-Clips
                if (activateQueenReactionTrigger != null)
                {
                    activateQueenReactionTrigger.SetActive(true);
                }
            }
        }
    }
}
