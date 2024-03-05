using UnityEngine;
using UnityEngine.UI;

public class MoodBar : MonoBehaviour
{
    public Slider slider;
    private int aufgabenAnzahl = 3;
    private int aufgabenErledigt = 0;
    private float prozentProAufgabe;

    void Start()
    {
        prozentProAufgabe = 100f / aufgabenAnzahl;
    }

    public void AufgabeErledigt()
    {
        aufgabenErledigt++;
        float prozentAbzug = prozentProAufgabe * aufgabenErledigt;
        slider.value -= prozentAbzug;

        if (aufgabenErledigt == aufgabenAnzahl)
        {
            Debug.Log("Herzlichen Glückwunsch! Alle Aufgaben erledigt!");
            // Hier kannst du weitere Aktionen ausführen, wenn alle Aufgaben erledigt sind.
        }
    }
}

