using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string sceneToLoad; // Name der Szene, die geladen werden soll

    public GameObject eddingImage;
    public GameObject vomitPowderImage;
    public GameObject bkCrownImage;

    private bool playerInRange = false;
    private bool roomSwitched = false; // Variable, um den Raumwechsel zu verfolgen

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered the door trigger zone.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player exited the door trigger zone.");
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !roomSwitched)
        {
            if (eddingImage.activeSelf || vomitPowderImage.activeSelf || bkCrownImage.activeSelf)
            {
                Debug.Log("No scene change because one of the special items is active.");
            }
            else
            {
                roomSwitched = true; // Raumwechsel markieren
                LoadScene();
            }
        }
    }

    private void LoadScene()
    {
        Debug.Log("Loading scene: " + sceneToLoad);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
