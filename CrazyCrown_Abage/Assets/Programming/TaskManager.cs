using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GameObject normalPortrait; // Referenz auf das normale Portrait UI-Element
    public GameObject smearPortrait; // Referenz auf das verschmierte Portrait UI-Element
    public Collider2D triggerPoint; // Referenz auf den Collider des TaskTriggers
    public AudioClip audioClip; // Referenz auf die AudioSource

    private bool portraitsSwapped = false; // Flag, um zu verfolgen, ob die Porträts bereits getauscht wurden

    private void Update()
    {
        // Überprüfe, ob der Spieler sich im Bereich des triggerPoint befindet und die E-Taste gedrückt wird
        if (Input.GetKeyDown(KeyCode.E) && triggerPoint.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            // Überprüfe, ob der Edding aktiv ist
            if (InventoryManager.instance != null && InventoryManager.instance.eddingImage.activeSelf)
            {
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                // Tausche die Porträts
                normalPortrait.SetActive(false);
                smearPortrait.SetActive(true);
                portraitsSwapped = true; // Setze das Flag, um anzuzeigen, dass die Porträts getauscht wurden
            }
        }
    }
}
