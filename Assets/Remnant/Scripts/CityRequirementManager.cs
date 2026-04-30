using UnityEngine;

public class CityRequirementsManager : MonoBehaviour
{
    public MissionUIManager missionUI;
    public bool radioCollected = false;
    public bool sensorActivated = false;

    public GameObject doorClosed;
    public GameObject doorOpen;

    void Start()
    {
        UpdateDoor();
    }

    public void CollectRadio()
    {
        radioCollected = true;

        if (missionUI != null)
            missionUI.SetRadioDone();

        UpdateDoor();
    }

    public void ActivateSensor()
    {
        sensorActivated = true;

        if (missionUI != null)
            missionUI.SetSensorDone(true);

        UpdateDoor();
    }

    public void DeactivateSensor()
    {
        sensorActivated = false;

        if (missionUI != null)
            missionUI.SetSensorDone(false);

        UpdateDoor();
    }

    private void UpdateDoor()
    {
        bool canOpen = radioCollected && sensorActivated;

        if (doorClosed != null)
            doorClosed.SetActive(!canOpen);

        if (doorOpen != null)
            doorOpen.SetActive(canOpen);
    }
}