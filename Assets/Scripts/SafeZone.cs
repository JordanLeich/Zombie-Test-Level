using UnityEngine;

public class SafeZone : MonoBehaviour
{
    // Reference to the GameManager to trigger the win condition
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger the win condition when the player enters the Safe Zone
            Debug.Log("Player has entered the Safe Zone! You Win!");
            if (gameManager != null)
            {
                gameManager.WinGame(); // Call the WinGame method on GameManager
            }
            else
            {
                Debug.LogError("GameManager reference is not set in the SafeZone script.");
            }
        }
    }
}
