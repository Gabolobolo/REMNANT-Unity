using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerHealth playerHealth;

    void Start()
    {
        healthSlider.minValue = 0;
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.maxHealth;
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetCurrentHealth();
    }
}