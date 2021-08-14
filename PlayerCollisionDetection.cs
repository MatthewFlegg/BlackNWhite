using UnityEngine;

// This script detects when the player hits a trigger

public class PlayerCollisionDetection : MonoBehaviour
{
    // Reference to components

    public PlayerController2D pc;

    public GameObject player;

    // Private variables

    bool _hasWonLevel = false;

    private void Start() // Called on start
    {
        // Find player controller script

        pc = GetComponent<PlayerController2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player reaches the finish line

        if (other.CompareTag("End Trigger") || other.CompareTag("Finish"))
        {       
            Debug.Log("You Hit the End Trigger"); // Debug message

            // Calls CompleteLevel function on GameManager script

            FindObjectOfType<GameManager>().CompleteLevel();

            _hasWonLevel = true;
        }

        if (other.CompareTag("Moving Platform") && pc.isGrounded)
        {
            Debug.Log("You're on a moving platform"); // Debug message

            pc.isGrounded = false; // Player is not jumping 

            // Player moves along with the platform

            player.transform.parent = other.gameObject.transform;
        }

        if (!_hasWonLevel)
        {
            // If player hits death trigger and hasn't already won

            if (other.CompareTag("Death Trigger"))
            {       
                Debug.Log("You Died"); // Debug message

                // Calls EndGame function on GameManager script

                FindObjectOfType<GameManager>().EndGame();

                _hasWonLevel = false;
            }

            // if player collides with an enemy

            if (other.CompareTag("Enemy"))
            {       
                Debug.Log("You Hit an Enemy"); // Debug message
 
                // Calls EndGame function on GameManager script

                FindObjectOfType<GameManager>().EndGameOnEnemy();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // When player leaves the platform

        if (other.CompareTag("Moving Platform"))
        {
            // Stop it following the platform

            player.transform.parent = null;
        }
    }
}