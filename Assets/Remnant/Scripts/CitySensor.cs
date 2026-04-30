using UnityEngine;

public class CitySensor : MonoBehaviour
{
    public CityRequirementsManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pushable"))
        {
            if (manager != null)
                manager.ActivateSensor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pushable"))
        {
            if (manager != null)
                manager.DeactivateSensor();
        }
    }
}