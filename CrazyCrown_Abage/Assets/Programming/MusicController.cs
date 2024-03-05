using UnityEngine;

public class MusicController : MonoBehaviour
{
    public Transform player; // Der Transform des Spielers
    public AudioSource music; // Der Audio Source des NPCs
    public float maxVolumeDistance = 5f; // Maximale Entfernung, bei der die Musik hörbar ist

    void Update()
    {
        if (player != null && music != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            float volume = 1f - Mathf.Clamp01(distance / maxVolumeDistance); // Lautstärke basierend auf der Entfernung
            music.volume = volume;
        }
    }
}