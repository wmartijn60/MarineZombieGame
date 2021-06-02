using System.Collections.Generic;
using UnityEngine;

public class ImpactDamage : MonoBehaviour
{
    [SerializeField] private int maxDamage;
    [SerializeField] private int force;
    [SerializeField] private Collider2D area;

    public List<GameObject> inRange;

    public void DamageEnemies()
    {
        for (int i = 0; i < inRange.Count; i++)
        {
            if (inRange[i] != null)
            {
                inRange[i].GetComponent<HealthSystem>().StartCoroutine("TakeDamage", maxDamage);
                inRange[i].GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
            }
            else
            {
                inRange.RemoveAt(i);
            }
        }
        Shaker.Shake(0.3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombie")
        {
            inRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Zombie")
        {
            inRange.Remove(other.gameObject);
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
