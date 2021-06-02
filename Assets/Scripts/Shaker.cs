using System.Collections;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    private Transform target;
    private Vector3 startPos;
    [SerializeField] private float standardIntensity;
    private static float intensity = 1f;
    private static float totalShakeDuration = 0.6f;
    private bool isShaking = false;

    void Start()
    {
        target = GetComponent<Transform>();
        startPos = target.localPosition;
        intensity = standardIntensity;
    }

    void Update()
    {
        if (totalShakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }

    public static void Shake(float duration)
    {
        if (duration > 0)
        {
            totalShakeDuration += duration;
        }
    }

    public static void NewShake(float duration)
    {
        totalShakeDuration = duration;
    }

    public static void SetIntensity(float inten)
    {
        intensity = inten;
    }

    public static void ResetIntensity(float inten)
    {
        intensity = inten;
    }

    IEnumerator DoShake()
    {
        isShaking = true;

        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + totalShakeDuration)
        {
            Vector3 randomPoint = new Vector3(Random.Range(-1f, 1f) * intensity, Random.Range(-1f, 1f) * intensity, startPos.z);
            target.localPosition = randomPoint;
            yield return null;
        }

        totalShakeDuration = 0f;
        target.localPosition = startPos;
        isShaking = false;
    }
}
