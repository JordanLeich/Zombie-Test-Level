using UnityEngine; // Make sure this is included at the top of the script

public class ZombieMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb != null)
        {
            // Regular movement logic (example)
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
        }
    }

    // Stop the zombie's movement
    public void StopMoving()
    {
        if (rb != null)
        {
            // Stop the Rigidbody's velocity to halt movement
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero; // Optionally stop any rotation
        }
    }
}
