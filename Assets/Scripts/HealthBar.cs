using UnityEngine;
using UnityEngine.UI;  // Required for working with UI components

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;  // Reference to the Slider UI component

    // Method to set the health value on the health bar
    public void SetHealth(int health)
    {
        healthSlider.value = health;  // Update the slider value to match the player's health
    }

    // Optionally, you can set the max health value for the slider
    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;  // Set the maximum value for the slider
        healthSlider.value = maxHealth;     // Optionally, set the slider to full at the start
    }
}
