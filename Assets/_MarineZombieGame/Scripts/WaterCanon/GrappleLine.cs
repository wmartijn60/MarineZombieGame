using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleLine : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    LineRenderer Line;

    void Start()
    {
        Line = GetComponent<LineRenderer>();
        Line.SetPosition(0, start.position);
        Line.SetPosition(1, end.position);
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Line.SetPosition(0, start.position);
            Line.SetPosition(1, end.position);
        }
        
    }
}
