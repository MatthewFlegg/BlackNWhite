using UnityEngine;
using UnityEngine.SceneManagement;

// This script manages scenes and the game in general

public class GameManager : MonoBehaviour
{
    // Variables

    public int nextSceneLoad;

    public float _waitBeforeReload = 1F;

    bool gameHasEnded = false;

    // Component references

    public GameObject completeLevelUI;

    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void EndGame() // Called on game end
    {
        // Checks if game has already ended

        if (!gameHasEnded)
        {
            gameHasEnded = true;

            Debug.Log("Game Over");

            // Restart & reload game

            Invoke("Restart", _waitBeforeReload);
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("You Won The Level"); // Debug message

        completeLevelUI.SetActive(true);

        if (nextSceneLoad > PlayerPrefs.GetInt("LevelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }
 
    void Restart() // Reloads the current scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGameOnEnemy() // Called on game end from enemy collision
    {
        // Checks if game has already ended

        if (!gameHasEnded)
        {
            gameHasEnded = true;

            Debug.Log("Game Over");

            // Restart & reload game

            Invoke("Restart", _waitBeforeReload / 3.5F);
        }
    }
}