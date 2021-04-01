using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] private ParticleSystem beam;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
    }
}
