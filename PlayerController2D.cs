using UnityEngine;

// This script handles the player movement

public class PlayerController2D : MonoBehaviour
{
    // Public variables

    public float speed; 

    public float jumpForce;

    public float climbSpeed;

    public float xWallForce;

    public float yWallForce;

    public float wallJumpTime;

    public int extraJumpsValue;

    public float wallSlidingSpeed;

    public float _checkRadius;

    public float _distance;

    // Private variables

    private int extraJumps;

    private bool wallJumping;

    private bool _facingRight = true;

    private bool _isJumping;

    private bool _isGrounded;

    private bool _isTouchingFront;

    private bool _wallSliding;

    // Component references

    private Rigidbody2D rb;

    public Transform groundCheck;

    public Transform frontCheck;

    public LayerMask whatIsGround;

    // Properties
 
    public bool isGrounded {
    
        get { return _isGrounded; }
    
        set { _isGrounded = value; } }

    private float inputVertical { get; set; }

    private float moveInput { get; set; }

    private void Start()
    {
        // Allows physics changes via script

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() // Updates every frame
    {
        // Player movement corresponds to -ve or +ve x value

        moveInput = Input.GetAxis("Horizontal"); // -ve if a key, +ve if d key

        // Reset extra jumps when player hits ground

        if (_isGrounded) // If grounded
        {
            extraJumps = extraJumpsValue; 
        }

        // If player presses w and has over 1 extra jump

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            // Move player up with jump force specified

            rb.velocity = Vector2.up * jumpForce;

            extraJumps--; // Take an extra jump away
        }

        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && _isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce; // Don't decrease extra jumps if grounded
        }
    }

    private void FixedUpdate()
    {
        // Create circle around player's feet and check for collisions, then send to bool var

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, _checkRadius, whatIsGround);

        rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);

        // Create circle around player's front and check for collisions, then send to bool var

        _isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, _checkRadius, whatIsGround);

        if (_isTouchingFront && !_isGrounded && inputVertical != 0) // If the front of the player is touching a wall
        {
            _wallSliding = true; // Sets player wall sliding bool to true
        }

        else // Set bool to false
        {
            _wallSliding = false;
        }

        if (_wallSliding) // If wallsliding, speed of the slide can be anything between the set speed and max value
        {
            rb.velocity = new Vector2 (rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        // If character is moving right while facing left

        if (!_facingRight && moveInput > 0)
        {
            Flip(); // Flip the player on the x axis
        }

        // If character is moving left while facing right

        else if (_facingRight && moveInput < 0)
        {
            Flip(); // Flip the player on the x axis
        }

        if (Input.GetKeyDown(KeyCode.Space) && _wallSliding)
        {
            wallJumping = true; // Set walljump to true

            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if (wallJumping) // If the player is walljumping 
        {
            rb.velocity = new Vector2 (xWallForce * -moveInput, yWallForce);
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight; // Flips player's x orientation

        // Create vector identical to player velocity

        Vector3 _scaler = transform.localScale;

        // Flip velocity x direction

        _scaler.x = _scaler.x * -1;

        transform.localScale = _scaler;
    }   

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    } 
}