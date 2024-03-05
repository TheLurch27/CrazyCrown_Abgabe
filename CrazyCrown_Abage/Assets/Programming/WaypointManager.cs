using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    // Dictionary zur Speicherung von Wegpunkten f�r jede Szene
    private Dictionary<string, List<Transform>> sceneWaypoints = new Dictionary<string, List<Transform>>();

    // Statische Instanz, um sicherzustellen, dass der WaypointManager zwischen den Szenen beibehalten wird
    public static WaypointManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Das GameObject nicht zerst�ren, wenn eine neue Szene geladen wird
        }
        else
        {
            Destroy(gameObject); // Falls bereits eine Instanz vorhanden ist, diese zerst�ren
        }
    }

    // Methode zum Speichern der Wegpunkte f�r eine bestimmte Szene
    public void SaveSceneWaypoints(string sceneName, List<Transform> waypoints)
    {
        if (!sceneWaypoints.ContainsKey(sceneName))
        {
            sceneWaypoints.Add(sceneName, waypoints);
        }
        else
        {
            sceneWaypoints[sceneName] = waypoints;
        }
    }

    // Methode zum Laden der Wegpunkte f�r eine bestimmte Szene
    public List<Transform> LoadSceneWaypoints(string sceneName)
    {
        if (sceneWaypoints.ContainsKey(sceneName))
        {
            return sceneWaypoints[sceneName];
        }
        else
        {
            Debug.LogError("Wegpunkte f�r Szene '" + sceneName + "' nicht gefunden!");
            return new List<Transform>(); // Eine leere Liste zur�ckgeben, falls die Wegpunkte nicht gefunden werden
        }
    }
}
