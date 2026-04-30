using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public DamageFlashUI damageFlash;
    public CameraShake cameraShake;
    public DeathFadeUI deathFade;
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        Debug.Log("Vida jugador: " + currentHealth);

        if (damageFlash != null)
            damageFlash.TriggerFlash();

        if (cameraShake != null)
            cameraShake.Shake();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void Die()
    {
        Debug.Log("Jugador murió");

        if (animator != null)
            animator.SetBool("IsDead", true);

        if (damageFlash != null)
            damageFlash.ClearFlash();

        if (deathFade != null)
            deathFade.StartFade();

        Invoke(nameof(StopGame), 1.5f);
        if (animator != null)
        {
            Debug.Log("Activando animación de muerte");
            animator.SetBool("IsDead", true);
        }
        else
        {
            Debug.LogWarning("Animator no asignado en PlayerHealth");
        }
    }
    void StopGame()
    {
        Time.timeScale = 0f;
    }
}