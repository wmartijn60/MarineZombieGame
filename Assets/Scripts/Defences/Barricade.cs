using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : Defence
{
    private HealthSystem health;
    public Animator anim;

    void Start()
    {
        health = GetComponent<HealthSystem>();
        health.died += Destroyed;
    }
}
