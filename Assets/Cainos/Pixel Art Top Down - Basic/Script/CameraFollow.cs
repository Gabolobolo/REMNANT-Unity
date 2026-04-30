using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothSpeed = 5f;

    private CameraShake cameraShake;

    void Start()
    {
        cameraShake = GetComponent<CameraShake>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        if (cameraShake != null)
        {
            desiredPosition += cameraShake.GetShakeOffset();
        }

        Vector3 smoothPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothPosition;
    }
}