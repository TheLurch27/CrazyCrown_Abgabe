using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public GameObject normalPortrait; // Referenz auf das normale Portrait UI-Element
    public GameObject smearPortrait; // Referenz auf das verschmierte Portrait UI-Element
    public Collider2D triggerPoint; // Referenz auf den Collider des TaskTriggers

    public AudioClip audioClip; // Referenz auf die AudioClip-Datei im Inspector ziehen
    private AudioSource audioSource; // Referenz auf die AudioSource

    public GameObject queenReactionTrigger;

    public float volumeMultiplier = 1.0f; // Multiplikator für die Lautstärke

    private bool portraitsSwapped = false; // Flag, um zu verfolgen, ob die Porträts bereits getauscht wurden

    private bool queenReactionTriggered = false;

    private void Start()
    {
        // Holen Sie sich die AudioSource-Komponente von diesem GameObject oder fügen Sie sie hinzu, wenn sie nicht vorhanden ist.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        // Check if the smear portrait is active
        bool smearPortraitActive = smearPortrait.activeSelf;

        // Check if the eddingImage is active
        bool eddingImageActive = InventoryManager.instance.eddingImage.activeSelf;

        // Check if the smear portrait is active and eddingImage is active
        if (smearPortraitActive && eddingImageActive)
        {
            // Deactivate the eddingImage
            InventoryManager.instance.eddingImage.SetActive(false);
        }

        // Check if the player is in the trigger area and presses the E key
        if (Input.GetKeyDown(KeyCode.E) && triggerPoint.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            // Check if the edding is active
            if (eddingImageActive)
            {
                // Play the audio clip with volume adjusted by volumeMultiplier
                audioSource.PlayOneShot(audioClip, volumeMultiplier);

                // Swap the portraits
                normalPortrait.SetActive(false);
                smearPortrait.SetActive(true);
                portraitsSwapped = true;

                if (queenReactionTrigger != null)
                {
                    queenReactionTrigger.SetActive(true);
                }
            }
        }
    }
}
