using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCanon : MonoBehaviour
{
    void Update()
    {
        Vector2 mouse = Input.mousePosition;
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector2(
                                                            mouse.x,
                                                            transform.position.y));
        Vector2 forward = mouseWorld - new Vector2(transform.position.x, transform.position.y);
        transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, -forward.y), Vector3.up);
    }
}
