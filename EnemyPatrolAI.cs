using UnityEngine;

public class EnemyPatrolAI : MonoBehaviour
{
    // Variables

    public float enemySpeed;

    private bool movingRight = true;

    // Component references

    public Transform _groundDetection;

    private void Update()
    {
        // Moves the enemy to the right via transform 

        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);

        RaycastHit2D _groundInfo = Physics2D.Raycast(_groundDetection.position, Vector2.down, 2F);

        if (!_groundInfo.collider) // If the ray hasn't collided, we know it's time to turn
        {
            if (movingRight) // If we're moving right, turn left
            {
                transform.eulerAngles = new Vector3 (0, -180, 0);

                movingRight = false; // We're now moving left
            }

            else // If we're moving left, turn right
            {
                transform.eulerAngles = new Vector3 (0, 0, 0);

                movingRight = true; // We're now moving right
            }
        }
    }
}
