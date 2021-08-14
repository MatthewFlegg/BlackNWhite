using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] _levelButtons;

    void Start() // Called on first frame update
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (i + 2 > levelAt) // If level hasn't been completed
            {
                _levelButtons[i].interactable = false; // Locks the buttons
            }
        }
    }

    void Update() 
    {
        var color = Color.white;

        color.a = 1F; // Alpha = 1

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (_levelButtons[i].interactable == false)
            {
                _levelButtons[i].GetComponent<Shadow>().effectColor = color;
            }
        }
    }

    public void SelectLevel() // Selects the level of the button pressed
    {
        string buttonClicked = EventSystem.current.currentSelectedGameObject.name;

        for (int i = 0; i < _levelButtons.Length; i++) // Loops through all buttons
        { 
            if (buttonClicked == i.ToString()) // Compares string to index
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);
            }
        }
    }
}
