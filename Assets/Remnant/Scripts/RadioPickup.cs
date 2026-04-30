using UnityEngine;

public class RadioPickup : MonoBehaviour
{
    public CityRequirementsManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (manager != null)
                manager.CollectRadio();


            gameObject.SetActive(false);
        }
    }
}