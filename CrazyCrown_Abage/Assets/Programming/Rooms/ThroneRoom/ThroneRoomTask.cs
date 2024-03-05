using UnityEngine;
using UnityEngine.UI;

public class ThroneRoomTask : MonoBehaviour
{
    public GameObject normalPortrait;
    public GameObject smearPortrait;
    public Collider2D triggerPoint;
    public AudioClip audioClip;
    private AudioSource audioSource;
    public GameObject queenReactionTrigger;
    public float volumeMultiplier = 1.0f;
    private bool portraitsSwapped = false;

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
