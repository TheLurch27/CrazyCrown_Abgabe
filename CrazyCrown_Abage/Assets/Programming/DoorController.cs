using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public string destinationSceneName; // Name der Zielszene
    public string previousSceneName; // Name der vorherigen Szene
    public bool preserveSceneState = true; // Soll der Zustand der vorherigen Szene erhalten bleiben?

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone.");
            TryLoadScene();
        }
    }

    private void TryLoadScene()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed.");
            if (preserveSceneState)
            {
                // Speichere den Namen der aktuellen Szene
                previousSceneName = SceneManager.GetActiveScene().name;
                Debug.Log("Previous scene name: " + previousSceneName);
            }

            // Lade die Zielszene
            SceneManager.LoadScene(destinationSceneName);
        }
    }

    public void LoadPreviousScene()
    {
        // Lade die vorherige Szene
        SceneManager.LoadScene(previousSceneName);
    }
}
