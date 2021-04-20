using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private HealthSystem health;

    void Start()
    {
        health = GetComponent<HealthSystem>();
    }
}
