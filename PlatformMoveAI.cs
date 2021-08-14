using UnityEngine;

// A script that moves a platform between two points

public class PlatformMoveAI : MonoBehaviour
{
    // Variables

    public float speed;

    Vector3 nextPosition;

    // Component references

    public Transform _position1;

    public Transform _position2;

    public Transform _startPosition;
    
    private void Start() // Called on first update
    {
        nextPosition = _startPosition.position;
    }

    void Update() // Called on every frame update
    {
        // If platform is at position 1, go to position 2

        if (transform.position == _position1.position)
        {
            nextPosition = _position2.position;
        }

        // If platform is at position 2, go to position 1

        if (transform.position == _position2.position)
        {
            nextPosition = _position1.position;
        }

        // Now that the target position has been set, move towards it (scaled by speed variable)

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }

    private void OnDrawGizmos() // Draws line between the points
    {
        Gizmos.DrawLine(_position1.position, _position2.position);
    }
}
