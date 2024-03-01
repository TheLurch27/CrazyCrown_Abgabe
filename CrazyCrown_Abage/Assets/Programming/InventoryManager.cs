using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public GameObject eddingImage; // UI-Bild für den Edding
    public GameObject vomitPowderImage; // UI-Bild für das VomitPowder
    public GameObject bkCrownImage; // UI-Bild für die BK_Crown

    private void Start()
    {
        // Deaktiviere alle UI-Bilder zu Beginn
        eddingImage.SetActive(false);
        vomitPowderImage.SetActive(false);
        bkCrownImage.SetActive(false);
    }

    public void UpdateInventory(string itemName)
    {
        // Deaktiviere alle UI-Bilder
        eddingImage.SetActive(false);
        vomitPowderImage.SetActive(false);
        bkCrownImage.SetActive(false);

        // Aktiviere das entsprechende UI-Bild für den aufgenommenen Gegenstand
        switch (itemName)
        {
            case "Edding":
                eddingImage.SetActive(true);
                break;
            case "VomitPowder":
                vomitPowderImage.SetActive(true);
                break;
            case "BK_Crown":
                bkCrownImage.SetActive(true);
                break;
            default:
                Debug.LogError("Unbekannter Gegenstand: " + itemName);
                break;
        }
    }
}
