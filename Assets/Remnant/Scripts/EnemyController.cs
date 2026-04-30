using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public int health = 3;
    public int damage = 1;

    private Transform player;
    private Rigidbody2D rb;

    private float attackCooldown = 1f;
    private float lastAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Bandido tocó: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= lastAttackTime)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    Debug.Log("Haciendo daño al Player");
                    playerHealth.TakeDamage(damage);
                }
                else
                {
                    Debug.LogWarning("El Player no tiene PlayerHealth");
                }

                lastAttackTime = Time.time + attackCooldown;
            }
        }
    }
}