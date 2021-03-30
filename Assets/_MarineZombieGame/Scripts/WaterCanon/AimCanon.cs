using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCanon : MonoBehaviour
{
    [SerializeField]private Transform origin;
    [SerializeField]private ParticleSystem beam;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);

        beam.startLifetime = Vector2.Distance(origin.position, dir) / 200 /1.9f;
        
    }
}
