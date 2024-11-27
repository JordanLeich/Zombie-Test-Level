using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    // Movement speed of the zombie
    public float moveSpeed = 3f;
    
    // Reference to the player's position (if chasing)
    private Transform player;
    
    // Rigidbody for physics-based movement
    private Rigidbody rb;
    
    // Boolean to check if zombie should move
    private bool canMove = true;

    void Start()
    {
        // Get the player object (make sure the player is tagged as "Player")
        player = GameObject.FindWithTag("Player").transform;
        
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Only move if the zombie is allowed to move (canMove is true)
        if (canMove)
        {
            MoveTowardsPlayer();
        }
    }

    // Zombie movement logic towards the player
    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            // Calculate the direction from the zombie to the player
            Vector3 direction = (player.position - transform.position).normalized;
            
            // Move the zombie using Rigidbody physics
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
    }

    // Call this method to stop the zombie's movement
    public void StopMoving()
    {
        canMove = false; // Stop movement by setting canMove to false
        rb.linearVelocity = Vector3.zero; // Stop any movement from Rigidbody
        rb.angularVelocity = Vector3.zero; // Stop any rotation from Rigidbody
        Debug.Log("Zombie movement stopped.");
    }
    
    // Optionally, you can restart the zombie's movement (if needed)
    public void ResumeMovement()
    {
        canMove = true; // Allow movement again
    }
}
