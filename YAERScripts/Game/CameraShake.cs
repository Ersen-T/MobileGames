using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 _originalPos = transform.localPosition;

        float _elapsed = 0.0f;

        while (_elapsed < duration)
        {
            float x = Random.Range(-1.0f, 1.0f) * magnitude;
            float y = Random.Range(-1.0f, 1.0f) * magnitude;

            transform.localPosition = new Vector3(x, y, _originalPos.z);

            _elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = _originalPos;
    }
}
