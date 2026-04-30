using UnityEngine;

public class TaskCombatManager : MonoBehaviour
{
    public EnemySpawner spawner;
    public GameObject doorClosed;
    public GameObject doorOpen;

    private bool combatStarted = false;

    public void StartCombat()
    {
        combatStarted = true;
    }

    void Update()
    {
        if (combatStarted && !spawner.AreEnemiesAlive())
        {
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
            Destroy(this);
        }
    }
}