using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : Defence
{
    private HealthSystem health;
    //public Animator anim;

    void Start()
    {
        health = GetComponent<HealthSystem>();
        health.died += Destroyed;
    }

    public override void Destroyed() {
        base.Destroyed();
        Destroy(gameObject, 1f); // change time depending on animation duration
    }
}
