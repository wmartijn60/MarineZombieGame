using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCanon : MonoBehaviour
{
    [SerializeField]private GameObject rotator;
    [SerializeField]private Transform origin;
    [SerializeField]private ParticleSystem beam;
    [SerializeField]private GameObject impact;
    [SerializeField]private LayerMask layer;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotator.transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);

        if (0.28f < Vector2.Distance(origin.position, dir) / 200 / 1.9f)
        {
            beam.startLifetime = Vector2.Distance(origin.position, dir) / 200 / 1.9f;
        }
        else
        {
            beam.startLifetime = 0.28f;
        }

        if (beam.gameObject.activeSelf)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 200f, layer);
            if (hit.collider != null)
            {
                impact.transform.position = hit.point;
                impact.SetActive(true);
            }
            else
            {
                impact.SetActive(false);
            }


        }
        else if (impact.activeSelf)
        {
            impact.SetActive(false);
        }
    }
}
