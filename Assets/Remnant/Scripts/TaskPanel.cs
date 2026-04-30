using UnityEngine;

public class TaskPanel : MonoBehaviour
{
    public EnemySpawner spawner;
    public GameObject doorClosed;
    public GameObject doorOpen;
    public GameObject taskMessage;

    private bool playerInside = false;
    private bool taskCompleted = false;

    void Update()
    {
        if (playerInside && !taskCompleted && Input.GetKeyDown(KeyCode.F))
        {
            CompleteTask();
        }
    }

    private void CompleteTask()
    {
        taskCompleted = true;

        if (taskMessage != null)
            taskMessage.SetActive(false);

        if (doorClosed != null)
            doorClosed.SetActive(true);

        if (doorOpen != null)
            doorOpen.SetActive(false);

        spawner.SpawnEnemies();

        TaskCombatManager manager = FindObjectOfType<TaskCombatManager>();
        if (manager != null)
        {
            manager.StartCombat();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !taskCompleted)
        {
            playerInside = true;

            if (taskMessage != null)
                taskMessage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;

            if (taskMessage != null)
                taskMessage.SetActive(false);
        }
    }
}