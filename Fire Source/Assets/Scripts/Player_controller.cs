using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed; // Speed of the player movement
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    public Vector2 move; // Variable to store movement input

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the horizontal and vertical axes (WASD or arrow keys)
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        // Normalize the movement vector to ensure consistent speed in all directions
        move = move.normalized * speed;

        if(Input.GetKeyDown(KeyCode.F))
        {
            //UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized; // Maximize the Unity Editor window for better visibility during development
        }
    }

    private void FixedUpdate()
    {
        
        // Move the player by setting the velocity of the Rigidbody2D
        rb.linearVelocity = move * speed;
    }
}
