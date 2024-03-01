using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;

    void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        // Credits werden erst gesucht, wenn sie benötigt werden
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Disclaimer");
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        // Credits deaktivieren, falls sie aktiviert sind
        if (credits != null)
            credits.SetActive(false);
    }

    public void ShowCredits()
    {
        // Credits werden erst gesucht, wenn sie benötigt werden
        if (credits == null)
            credits = GameObject.FindGameObjectWithTag("Credits");

        mainMenu.SetActive(false);
        if (credits != null)
            credits.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        if (credits != null)
            credits.SetActive(false);
        ShowMainMenu();
    }
}
