using System.Collections.Generic;
using UnityEngine;

public class Zombie : HumanoidBehavior
{
    [SerializeField] private int damage = 1;
    [SerializeField] private CircleCollider2D visionRange;
    private float range = 1f;

    protected override void Start()
    {        
        base.Start();
        visionRange.radius = range;
        FindNewTarget();
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
            target = defaultTarget;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Barricade")
        {
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
        if (target == null || target.tag == "Player") return;
        if (target.GetComponent<HealthSystem>().Health > 0) 
        {
            anim.SetBool("isAttacking", true);
            target.GetComponent<HealthSystem>().StartCoroutine("TakeDamage", damage);
            AnimatorClipInfo[] info = anim.GetCurrentAnimatorClipInfo(0);
            Invoke("Attack", info[0].clip.length);
        }
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
            target = defaultTarget;
        }
    }
}
