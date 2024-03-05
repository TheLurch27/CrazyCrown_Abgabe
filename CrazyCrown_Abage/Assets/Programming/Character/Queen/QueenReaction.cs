using UnityEngine;

public class QueenReaction : MonoBehaviour
{
    public AudioClip queenReaction; // Audio Clip, der abgespielt werden soll
    public float volumeMultiplier = 1.5f; // Multiplikator zur Anpassung der Lautstärke

    private bool hasBeenTriggered = false; // Variable, um sicherzustellen, dass der Sound nur einmal abgespielt wird

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.CompareTag("QueenReaction") && !hasBeenTriggered && GameObject.FindGameObjectWithTag("Portrait_Smear").activeSelf)
        {
            // AudioSource-Komponente holen und Sound abspielen
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(queenReaction, volumeMultiplier);

            hasBeenTriggered = true; // Markiere den Trigger als ausgelöst, um zu verhindern, dass der Sound erneut abgespielt wird
        }
    }
}
