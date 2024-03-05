using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class QueenController : MonoBehaviour
{
    private WaypointManager waypointManager; // Referenz auf den WaypointManager
    private List<Transform> waypoints; // Liste der Wegpunkte f�r die aktuelle Szene
    private int currentWaypointIndex = 0; // Index des aktuellen Wegpunkts

    private NavMeshAgent agent; // NavMeshAgent des NPCs

    void Start()
    {
        waypointManager = WaypointManager.instance; // WaypointManager-Instanz erhalten

        agent = GetComponent<NavMeshAgent>(); // Den NavMeshAgent des NPCs erhalten

        // Wegpunkte f�r die aktuelle Szene laden
        waypoints = waypointManager.LoadSceneWaypoints(SceneManager.GetActiveScene().name);

        // Sicherstellen, dass es mindestens einen Wegpunkt gibt
        if (waypoints.Count > 0)
        {
            SetDestination(waypoints[currentWaypointIndex]); // Den ersten Wegpunkt als Ziel setzen
        }
        else
        {
            Debug.LogError("Keine Wegpunkte gefunden!");
        }
    }

    void Update()
    {
        // �berpr�fen, ob der NPC den aktuellen Wegpunkt erreicht hat
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            // Zum n�chsten Wegpunkt wechseln
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                // Wenn alle Wegpunkte erreicht sind, zur n�chsten Szene wechseln
                LoadNextScene();
            }
            else
            {
                SetDestination(waypoints[currentWaypointIndex]); // N�chsten Wegpunkt als Ziel setzen
            }
        }
    }

    void SetDestination(Transform destination)
    {
        agent.SetDestination(destination.position); // Ziel des NavMeshAgents setzen
    }

    void LoadNextScene()
    {
        // �berpr�fen, ob eine T�r (Tag: Door) in der aktuellen Szene vorhanden ist
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        if (door != null)
        {
            // Szene laden und dabei die aktuelle Szene in den Build-Einstellungen �berspringen
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogError("Keine T�r gefunden, um zur n�chsten Szene zu wechseln!");
        }
    }
}
