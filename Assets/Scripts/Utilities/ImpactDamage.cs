using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactDamage : MonoBehaviour
{
    [SerializeField] private int maxDamage;
    [SerializeField] private int force;
    [SerializeField] private float range = 1.3f;
    [SerializeField] private Collider2D area;

    private bool canSplash = true;

    public List<GameObject> inRange;

    void Start()
    {

    }

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


}
