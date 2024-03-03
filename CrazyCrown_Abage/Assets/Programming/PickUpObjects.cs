using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public float pickupRadius = 1f; // Radius, innerhalb dessen der Gegenstand aufgenommen werden kann
    public AudioClip pickupSound; // Der Audioclip, der beim Aufnehmen des Gegenstands abgespielt wird
    public float volumeMultiplier = 1.5f; // Multiplikator zur Anpassung der Lautstärke
    public InventoryManager inventoryManager; // Referenz auf das InventoryManager-Skript

    private AudioSource playerAudioSource;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerAudioSource = player.GetComponent<AudioSource>();
            if (playerAudioSource == null)
            {
                playerAudioSource = player.AddComponent<AudioSource>();
            }
        }
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= pickupRadius && Input.GetKeyDown(KeyCode.C))
            {
                string objectName = gameObject.tag;

                switch (objectName)
                {
                    case "Edding":
                    case "BKCrown":
                    case "VomitPowder":
                        // Gegenstand aufnehmen
                        Destroy(gameObject);
                        Debug.Log(objectName + " aufgenommen und aus der Szene entfernt!");

                        // Audioclip abspielen mit Lautstärkeanpassung
                        if (playerAudioSource != null && pickupSound != null)
                        {
                            playerAudioSource.PlayOneShot(pickupSound, volumeMultiplier);
                        }
                        else
                        {
                            Debug.LogError("Player Audio Source oder Pickup Sound ist nicht zugewiesen!");
                        }

                        // Update des Inventars
                        if (inventoryManager != null)
                        {
                            inventoryManager.UpdateInventory(objectName);
                        }
                        else
                        {
                            Debug.LogError("Inventory Manager ist nicht zugewiesen!");
                        }
                        break;
                    default:
                        Debug.Log("Dieser Gegenstand kann nicht aufgenommen werden.");
                        break;
                }
            }
        }
    }
}
