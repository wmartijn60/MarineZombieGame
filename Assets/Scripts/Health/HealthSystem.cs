using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    //[SerializeField] private Image healthBar;
    [SerializeField] private protected float maxHealth = 25;
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    private protected float health = 25;
    public float Health { get { return health; } set { health = value; } }
    public delegate void Died();
    public Died died;
    private protected bool notified = false;

    void Start()
    {
        ResetHealth();
    }

    public IEnumerator TakeDamage(int damage) 
    {
        health -= damage;
        //if(healthBar != null) healthBar.fillAmount = health / maxHealth;
        if (health <= 0 && !notified) 
        {
            yield return new WaitForSeconds(0.01f);
            notified = true;
            died();
        }
    }

    private void ResetHealth() 
    {
        health = maxHealth;
        //if (healthBar != null) healthBar.fillAmount = health / maxHealth;
    }
}
