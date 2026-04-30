using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner spawner;
    public GameObject doorClosed;
    public GameObject doorOpen;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            activated = true;

            // cerrar puerta
            doorClosed.SetActive(true);
            doorOpen.SetActive(false);

            spawner.SpawnEnemies();
        }
    }

    private void Update()
    {
        if (activated && !spawner.AreEnemiesAlive())
        {
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);

            Destroy(this); 
        }
    }
}