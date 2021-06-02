using System.Collections;
using UnityEngine;

public class ZombieHealth : HealthSystem
{
    [SerializeField] private int score = 10;

    public IEnumerator TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !notified)
        {
            yield return new WaitForSeconds(0.01f);
            notified = true;
            ScoreManager.instance.AddScore(score);
            died();
        }
    }
}
