using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private ParticleSystem beam;

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Zombie")
        {
            other.GetComponent<HealthSystem>().StartCoroutine("TakeDamage", damage);
        }
    }
}
