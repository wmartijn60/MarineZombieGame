﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMine : MonoBehaviour
{
    private int damage = 1;
    private float range = 1f;
    [SerializeField] CircleCollider2D visionRange;


    void Start()
    {
        visionRange.radius = range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == null) return;
        if (target.tag != "Zombie" && collision.tag == "Zombie")
        {

            target = collision.transform;
            collision.GetComponent<HealthSystem>().died += FindNewTarget;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (target == null) return;
        if (target.tag == "Survivor" && collision.gameObject.tag == "Survivor")
        {
            Attack();
        }

    }

    public void Attack()
    {
        anim.SetBool("isAttacking", true);
        target.GetComponent<HealthSystem>().StartCoroutine("TakeDamage", damage);
    }

    private void FindNewTarget()
    {
        List<Collider2D> possibleTargets = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        visionRange.OverlapCollider(filter, possibleTargets);
        Collider2D newTarget = null;

        for (int i = 0; i < possibleTargets.Count; i++)
        {
            if (possibleTargets[i].tag == "Survivor" && possibleTargets[i] != target.GetComponent<Collider2D>())
            {
                newTarget = possibleTargets[i];
                break;
            }
        }

        anim.SetBool("isAttacking", false);

        if (newTarget != null)
        {
            target = newTarget.transform;
            newTarget.GetComponent<HealthSystem>().died += FindNewTarget;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
