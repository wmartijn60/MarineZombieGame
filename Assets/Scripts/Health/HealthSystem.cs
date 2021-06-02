using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private protected float maxHealth = 25;
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    private protected float health = 25;
    public float Health { get { return health; } set { health = value; } }
    private protected bool notified = false;
    public delegate void Died();
    public Died died;

    void Start()
    {
        ResetHealth();
    }

    public IEnumerator TakeDamage(int damage) 
    {
        health -= damage;
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
    }
}
