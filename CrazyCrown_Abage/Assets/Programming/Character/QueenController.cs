using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    // Liste der Waypoints
    public List<Transform> waypoints;

    // Aktueller Index des Waypoints
    private int currentWaypointIndex = 0;

    // Bewegungsgeschwindigkeit
    public float moveSpeed = 2f;

    // Abstand zum Waypoint, ab dem der nächste angesteuert wird
    public float waypointReachedDistance = 0.1f;

    void Start()
    {
        // Sicherstellen, dass mindestens zwei Waypoints vorhanden sind
        if (waypoints.Count < 2)
        {
            Debug.LogError("Es müssen mindestens zwei Waypoints für den NPC definiert sein!");
            return;
        }
    }

    void Update()
    {
        // Richtung zum aktuellen Waypoint berechnen
        Vector3 directionToWaypoint = waypoints[currentWaypointIndex].position - transform.position;

        // Sich zum Waypoint bewegen
        transform.Translate(directionToWaypoint.normalized * moveSpeed * Time.deltaTime);

        // Abstand zum Waypoint berechnen
        float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);

        // Wenn der Waypoint erreicht wurde, zum nächsten wechseln
        if (distanceToWaypoint < waypointReachedDistance)
        {
            currentWaypointIndex++;

            // Wenn der letzte Waypoint erreicht wurde, am Anfang wieder beginnen
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}
