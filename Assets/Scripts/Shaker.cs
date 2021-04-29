using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    Transform target;
    Vector3 startPos;
    [SerializeField]private float intesity = 1f;
    [SerializeField]private float totalShakeDuration = 1f;
    private bool isShaking = false;

    void Start()
    {
        target = GetComponent<Transform>();
        startPos = target.localPosition;
    }

    void Update()
    {
        if (totalShakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }

    public void Shake(float duration)
    {
        if (duration > 0)
        {
            totalShakeDuration += duration;
        }
    }

    IEnumerator DoShake()
    {
        isShaking = true;

        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + totalShakeDuration)
        {
            Vector3 randomPoint = new Vector3(Random.Range(-1f, 1f) * intesity, Random.Range(-1f, 1f) * intesity, startPos.z);
            target.localPosition = randomPoint;
            yield return null;
        }

        totalShakeDuration = 0f;
        target.localPosition = startPos;
        isShaking = false;
    }
}
