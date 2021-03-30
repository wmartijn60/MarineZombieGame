using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    private float health;
    private float maxHealth = 25;

    void Start()
    {
        ResetHealth();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if(healthBar != null) healthBar.fillAmount = health / maxHealth;
    }

    private void ResetHealth() {
        health = maxHealth;
        if (healthBar != null) healthBar.fillAmount = health / maxHealth;
    }
}
