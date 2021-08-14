using UnityEngine;

// A script that quits at the end 

public class CreditsMenu : MonoBehaviour
{
    // On click event

    public void Quit()
    {
        Debug.Log("Quit");

        Application.Quit();
    }
}
