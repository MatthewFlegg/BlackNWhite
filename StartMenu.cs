using UnityEngine;
using UnityEngine.SceneManagement;

// Starts the game when button is pressed

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Loads the first scene in the game on button click 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
