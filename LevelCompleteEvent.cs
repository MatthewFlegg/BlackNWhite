using UnityEngine;
using UnityEngine.SceneManagement;

// Animation event loads next level

public class LevelCompleteEvent : MonoBehaviour
{
    public void LoadNextLevel() 
    {
        // Loads scene with the build index after the current one

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
