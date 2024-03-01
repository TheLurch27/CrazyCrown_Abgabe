using UnityEngine;

public class SaluteTrigger : MonoBehaviour
{
    public AudioClip saluteSound; // Audio Clip, der abgespielt werden soll
    public float volumeMultiplier = 1.5f; // Multiplikator zur Anpassung der Lautstärke

    private bool hasBeenTriggered = false; // Variable, um sicherzustellen, dass der Sound nur einmal abgespielt wird

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Überprüfen, ob der Player den Trigger betreten hat und ob der Sound noch nicht abgespielt wurde
        if (other.CompareTag("Player") && !hasBeenTriggered)
        {
            // AudioSource-Komponente holen und Sound abspielen
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(saluteSound, volumeMultiplier);

            hasBeenTriggered = true; // Markiere den Trigger als ausgelöst, um zu verhindern, dass der Sound erneut abgespielt wird
        }
    }
}
