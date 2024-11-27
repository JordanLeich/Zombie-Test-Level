using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TextMeshProUGUI healthText;

    void Start()
    {
        UpdateHealthText();
    }

    void OnCollisionEnter(Collision collision)
{
    Debug.Log("Collided with: " + collision.gameObject.name); // Check collision detection
    if (collision.gameObject.CompareTag("Zombie"))
    {
        health--;
        Debug.Log("Player Health: " + health); // Confirm health decreases
        UpdateHealthText();

        if (health <= 0)
        {
            Debug.Log("Player is dead!");
            GameManager.instance.EndGame();
        }
    }
}

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
        else
        {
            Debug.LogError("HealthText not assigned!");
        }
    }
}
