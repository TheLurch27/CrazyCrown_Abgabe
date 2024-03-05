using UnityEngine;
using UnityEngine.UI;

public class QueenReactionController : MonoBehaviour
{
    public Slider slider; // Referenz auf den Slider im UI
    private bool queenReactionTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.CompareTag("QueenReaction") && !queenReactionTriggered)
        {
            // Die Queen-Reaktion wurde ausgelöst
            queenReactionTriggered = true;

            // Schrumpfe den Slider um 33.33%
            float currentValue = slider.value;
            float newValue = currentValue - (slider.maxValue * 0.3333f);
            slider.value = Mathf.Clamp(newValue, slider.minValue, slider.maxValue);
        }
    }
}
