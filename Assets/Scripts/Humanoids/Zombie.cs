using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : HumanoidBehavior
{
    private int damage = 1;
    private float range = 1f;
    [SerializeField] CircleCollider2D visionRange;


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

    private void OnTriggerExit2D(Collider2D collision) {
        if (target.tag == "Survivor" && collision == target.GetComponent<Collider2D>()) {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (target.tag == "Survivor" && collision.gameObject.tag == "Survivor")
        {
            Attack();
        }
    }

    public void Attack()
    {
        target.GetComponent<HealthSystem>().TakeDamage(damage);
    }
}
