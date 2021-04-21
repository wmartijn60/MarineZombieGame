using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField]private GameObject impactLocation;
    [SerializeField]private ImpactDamage impactDamage;

    void Start()
    {
        
    }

    public void MakeASplash()
    {
        impactDamage.DamageEnemies();
    }



}
