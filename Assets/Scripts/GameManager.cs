using UnityEngine;
using UnityEngine.SceneManagement;  // For reloading the scene

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Player's health
    public int playerHealth = 100;

    // Reference to the game over UI (optional)
    public GameObject gameOverUI;
    public GameObject winUI;

    // Reference to the player (assuming player has a tag 'Player')
    private GameObject player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate GameManager instances
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        playerHealth = 100;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        if (winUI != null)
        {
            winUI.SetActive(false);
        }
    }

    // Method to deal damage to the player
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        // If the player's health reaches zero, end the game
        if (playerHealth <= 0)
        {
            GameOver();
        }
    }

    // Trigger the Game Over condition
    private void GameOver()
    {
        Debug.Log("Game Over!");
        
        // Show Game Over UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    // Trigger the win condition
    public void WinGame()
    {
        Debug.Log("You Win!");

        // Show Win UI
        if (winUI != null)
        {
            winUI.SetActive(true);
        }
    }

    // End the game (you can use this as EndGame())
    public void EndGame()
    {
        // Optionally, you can perform additional tasks here before quitting or restarting.
        Debug.Log("Game Ended!");
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Heal the player
    public void HealPlayer(int amount)
    {
        playerHealth += amount;
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
    }
}
