using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Reference to UI component

    public GameObject _pauseMenuUI;

    // Used to tell if game has been paused yet

    public static bool gameIsPaused = false;

    void Start() // Called on first frame update
    {
        _pauseMenuUI.SetActive(false);
    }

    private void Update() // Called every frame update
    {
        // If the pause button (esc) is pressed 

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            // Pressed esc while already paused

            if (gameIsPaused) 
            {
                Resume();
            }

            else // Pressed esc while paused
            {
                Pause();
            }
        }
    }

    public void Resume() // Resume the game
    {
        _pauseMenuUI.SetActive(false);

        // Restart time in game

        Time.timeScale = 1F;

        gameIsPaused = false;
    }

    public void Pause() // Bring up pause UI
    {
        _pauseMenuUI.SetActive(true);

        // Freeze time in game 

        Time.timeScale = 0F;

        gameIsPaused = true;
    }

    public void QuitGame()
    {
        // When quit button pressed

        Debug.Log("Quitting Game");

        Application.Quit(); // Quits game
    }
}
