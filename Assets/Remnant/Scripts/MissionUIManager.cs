using TMPro;
using UnityEngine;

public class MissionUIManager : MonoBehaviour
{
    public TextMeshProUGUI missionText;

    private bool radioDone = false;
    private bool sensorDone = false;
    public TextMeshProUGUI baseOpenedText;

    void Start()
    {
        UpdateText();
    }

    public void SetRadioDone()
    {
        radioDone = true;
        UpdateText();
    }

    public void SetSensorDone(bool active)
    {
        sensorDone = active;
        UpdateText();
    }
    void ShowBaseOpened()
    {
        if (baseOpenedText != null)
        {
            baseOpenedText.gameObject.SetActive(true);
            baseOpenedText.text = "La puerta de la base ha sido abierta.";

            Color color = baseOpenedText.color;
            color.a = 1f;
            baseOpenedText.color = color;
        }
    }

    void UpdateText()
    {
        string radio = radioDone ? "[✓]" : "[ ]";
        string sensor = sensorDone ? "[✓]" : "[ ]";

        missionText.text =
            $"{radio} Encontrar la radio\n" +
            $"{sensor} Activar el sensor";

        if (radioDone && sensorDone)
        {
            ShowBaseOpened();
        }
    }

}