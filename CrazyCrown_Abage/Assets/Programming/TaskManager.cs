using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public string playerTag = "Player";
    public string taskTriggerTag = "TaskTrigger";
    public string eddingUITag = "Edding_UI";
    public string portraitNormalTag = "Portrait_Normal";
    public string portraitSmearTag = "Portrait_Smear";

    public float interactionDuration = 5f;

    private bool isInteracting = false;
    private float interactionTimer = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            GameObject eddingUI = GameObject.FindGameObjectWithTag(eddingUITag);
            if (eddingUI != null)
            {
                // Der Spieler hat das Edding-UI im Inventar
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartInteraction();
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isInteracting)
        {
            if (other.CompareTag(playerTag) && Input.GetKey(KeyCode.E))
            {
                interactionTimer += Time.deltaTime;
                Debug.Log("Interacting: " + interactionTimer.ToString("F1") + "s");

                if (interactionTimer >= interactionDuration)
                {
                    // Interaktion abgeschlossen
                    SwitchPortraitTags();
                    ResetInteraction();
                }
            }
            else
            {
                Debug.Log("Interaction reset.");
                ResetInteraction();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Interaction reset.");
            ResetInteraction();
        }
    }

    private void StartInteraction()
    {
        isInteracting = true;
        interactionTimer = 0f;
        Debug.Log("Interaction started.");
    }

    private void ResetInteraction()
    {
        isInteracting = false;
        interactionTimer = 0f;
    }

    private void SwitchPortraitTags()
    {
        GameObject portraitNormal = GameObject.FindGameObjectWithTag(portraitNormalTag);
        GameObject portraitSmear = GameObject.FindGameObjectWithTag(portraitSmearTag);

        if (portraitNormal != null && portraitSmear != null)
        {
            portraitNormal.SetActive(false);
            portraitSmear.SetActive(true);
        }
    }
}
