using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCameraShake : MonoBehaviour
{
    public static FinalCameraShake instance;
    [Header("抖动时间")]
    [SerializeField]float duration;
    [Header("抖动幅度")]
    [SerializeField]float magnitude;

    private void Start()
    {
        instance = this;
    }

    public IEnumerator Shake()
    {

        float elapsed = 0.0f;

        while (elapsed < duration)
        {

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
