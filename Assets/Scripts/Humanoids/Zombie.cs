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
        if (target == null) return;
        if (target.tag != "Survivor" && collision.tag == "Survivor")
        {
            
            target = collision.transform;
            collision.GetComponent<HealthSystem>().died += FindNewTarget;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (target == null) return;
        if (target.tag == "Survivor" && collision == target.GetComponent<Collider2D>())
        {
            anim.SetBool("isAttacking", false);
            target.GetComponent<HealthSystem>().died -= FindNewTarget;
            target = GameObject.FindGameObjectWithTag("Player").transform;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Barricade") {
            target = collision.transform;
            collision.gameObject.GetComponent<HealthSystem>().died += FindNewTarget;
        }
        if (target == null) return;
        if ((target.tag == "Survivor" && collision.gameObject.tag == "Survivor") || (target.tag == "Barricade" && collision.gameObject.tag == "Barricade"))
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
        } else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
