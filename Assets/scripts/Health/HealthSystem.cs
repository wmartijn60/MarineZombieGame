using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float maxHealth = 25;
    private float health;
    public float Health { get { return health; } }
    public delegate void Died();
    public Died died;
    private bool notified = false;

    void Start()
    {
        ResetHealth();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(1);
        }
    }

    public IEnumerator TakeDamage(int damage) 
    {
        health -= damage;
        if(healthBar != null) healthBar.fillAmount = health / maxHealth;
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
        if (healthBar != null) healthBar.fillAmount = health / maxHealth;
    }
}
