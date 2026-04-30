using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    public int damage = 1;
    public float lifeTime = 2f;

    private Vector2 direction;

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bala tocó: " + collision.name);

        EnemyController enemy = collision.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        if (!collision.CompareTag("Player") && !collision.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}