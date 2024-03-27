using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    // Variablen
    public List<GameObject> items; // Liste der aufgenommenen Gegenstände
    public AudioClip[] itemPickupSounds; // Array von Audio-Clips
    public KeyCode pickupKey = KeyCode.C;

    private Dictionary<string, AudioClip> itemSoundLookup = new Dictionary<string, AudioClip>();

    private void Start()
    {
        items = new List<GameObject>();

        // Audio-Clips dem Dictionary zuordnen
        itemSoundLookup.Add("Edding", itemPickupSounds[0]);
        itemSoundLookup.Add("BK_Crown", itemPickupSounds[1]);
        itemSoundLookup.Add("VomitPowder", itemPickupSounds[2]);
    }

    void Update()
    {
        // Taste "C" abfragen
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Den ersten Gegenstand in der Szene aufnehmen
            if (items.Count > 0)
            {
                PickUpItem(items[0]);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Überprüfen, ob es sich um einen sammelbaren Gegenstand handelt
        if (itemSoundLookup.ContainsKey(other.gameObject.tag))
        {
            // Gegenstand aufnehmen
            PickUpItem(other.gameObject);
        }
    }

    public void PickUpItem(GameObject item)
    {
        // Den Gegenstand aus der Szene entfernen
        item.SetActive(false);

        // Den Gegenstand zur Liste hinzufügen
        items.Add(item);

        // Audio-Clip abspielen
        if (itemSoundLookup.TryGetValue(item.tag, out AudioClip sound))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }

        Destroy(item);
    }
}
