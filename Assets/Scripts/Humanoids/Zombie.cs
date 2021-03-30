using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : HumanoidBehavior
{
    private int damage;
    private float range = 1f;
    [SerializeField] CircleCollider2D visionRange;
    [SerializeField] CircleCollider2D attackRange;


    protected override void Start()
    {
        base.Start();
        visionRange.radius = range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target.tag != "Survivor" && collision.tag == "Survivor")
        {
            target = collision.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("target tag: " + target.tag);
        Debug.Log("collision tag: " + collision.gameObject.tag);
        if (target.tag == "Survivor" && collision.gameObject.tag == "Survivor")
        {
            Attack();
        }
    }

    public void Attack()
    {
        Debug.Log("DIE!!!!!!!!");
    }
}
