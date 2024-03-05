using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string sceneToLoad; // Name der Szene, die geladen werden soll

    private bool playerInRange = false;

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
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        Debug.Log("Loading scene: " + sceneToLoad);

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
