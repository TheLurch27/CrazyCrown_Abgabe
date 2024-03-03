using Unity.VisualScripting;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [Header("Task")]
    public GameObject player;
    public GameObject eddingUI;
    public GameObject taskTrigger;
    public GameObject normalPortrait;
    public GameObject smearPortrait;
    public AudioClip goAwayAudio;

    private bool conditionMet = false;

    [Header("AfterTaskAudio")]
    public AudioClip eddingQueenReaction;
    public GameObject eddingQueenReactionTrigger;


    void Update()
    {
        if (player.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && eddingUI.CompareTag("Edding_UI"))
        {
            TogglePortraits();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TaskTrigger") && eddingUI.activeSelf)
        {
            conditionMet = true;
        }

        // if (collision.gameObject.CompareTag("eddingQueenReactionTrigger") && 
        // {
        //     
        // }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TaskTrigger"))
        {
            conditionMet = false;
        }
    }

    private void TogglePortraits()
    {
        switch (normalPortrait.activeSelf)
        {
            case true:
                normalPortrait.SetActive(false);
                smearPortrait.SetActive(true);
                Destroy(taskTrigger);
                Destroy(eddingUI);
                if (goAwayAudio != null)
                {
                    if (smearPortrait.activeSelf)
                    {
                        player.GetComponent<AudioSource>().PlayOneShot(goAwayAudio);
                    }
                }
                break;
            case false:
                normalPortrait.SetActive(true);
                smearPortrait.SetActive(false);
                break;
        }
    }
}
