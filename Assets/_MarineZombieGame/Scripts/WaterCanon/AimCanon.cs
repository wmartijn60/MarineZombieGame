using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCanon : MonoBehaviour
{
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                                                            mouse.x,
                                                            mouse.y,
                                                            transform.position.y));
        Vector3 forward = mouseWorld - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z), Vector3.up);
    }
}
