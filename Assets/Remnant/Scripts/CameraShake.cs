using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 0.3f;
    public float strength = 0.2f;

    private Vector3 shakeOffset = Vector3.zero;
    private Coroutine shakeRoutine;

    public Vector3 GetShakeOffset()
    {
        return shakeOffset;
    }

    public void Shake()
    {
        if (shakeRoutine != null)
            StopCoroutine(shakeRoutine);

        shakeRoutine = StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        float timer = 0f;

        while (timer < duration)
        {
            shakeOffset = new Vector3(
                Random.Range(-strength, strength),
                Random.Range(-strength, strength),
                0f
            );

            timer += Time.deltaTime;
            yield return null;
        }

        shakeOffset = Vector3.zero;
    }
}