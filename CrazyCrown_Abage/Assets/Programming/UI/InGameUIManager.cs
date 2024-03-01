using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject keyAssignmentMenu;
    public Button continueButton;
    public Button settingsButton;
    public Button keyAssignmentButton;
    public Button exitButton;
    public Button backButton1; // For settings menu
    public Button backButton2; // For key assignment menu

    private bool isPaused = false;

    void Start()
    {
        // Hide menus at start
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        keyAssignmentMenu.SetActive(false);

        // Add listeners to buttons
        continueButton.onClick.AddListener(ContinueGame);
        settingsButton.onClick.AddListener(ShowSettingsMenu);
        keyAssignmentButton.onClick.AddListener(ShowKeyAssignmentMenu);
        exitButton.onClick.AddListener(ExitToMainMenu);
        backButton1.onClick.AddListener(BackToPauseMenu);
        backButton2.onClick.AddListener(BackToSettingsMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Stop time
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time
        isPaused = false;
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        keyAssignmentMenu.SetActive(false);
    }

    void ContinueGame()
    {
        ResumeGame(); // Hide pause menu when continuing game
        // You can add custom logic here to resume the game if necessary
    }

    void ShowSettingsMenu()
    {
        Time.timeScale = 0f; // Freeze time when settings menu is shown
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    void ShowKeyAssignmentMenu()
    {
        Time.timeScale = 0f; // Freeze time when key assignment menu is shown
        pauseMenu.SetActive(false);
        keyAssignmentMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    void ExitToMainMenu()
    {
        Time.timeScale = 1f; // Ensure time scale is reset
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the name of your main menu scene
    }

    void BackToPauseMenu()
    {
        Time.timeScale = 0f; // Freeze time when back to pause menu
        settingsMenu.SetActive(false);
        keyAssignmentMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    void BackToSettingsMenu()
    {
        Time.timeScale = 0f; // Freeze time when back to settings menu
        keyAssignmentMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
