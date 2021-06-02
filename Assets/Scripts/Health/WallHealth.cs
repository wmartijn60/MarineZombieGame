using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : HealthSystem
{
    [SerializeField] private SpriteRenderer wallSprite;
    [SerializeField] private List<Sprite> damageStates;
    [SerializeField] private List<int> stateValues;
    [SerializeField] private ParticleSystem breakLeft;
    [SerializeField] private ParticleSystem breakRight;

    public IEnumerator TakeDamage(int damage)
    {        
        health -= damage;
        SetHealthState();
        if (health <= 0 && !notified)
        {
            yield return new WaitForSeconds(0.01f);
            notified = true;
            died();
        }
        ParticleHit();
    }

    private void SetHealthState()
    {
        if (health <= 0)
        {
            wallSprite.sprite = damageStates[4];
            gameObject.GetComponent<Collider2D>().enabled = false;
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX One-Shots/Wall Break", GetComponent<Transform>().position);
        }
        else if (health <= stateValues[3])
        {
            wallSprite.sprite = damageStates[3];
        }
        else if (health <= stateValues[2])
        {
            wallSprite.sprite = damageStates[2];
        }
        else if (health <= stateValues[1])
        {
            wallSprite.sprite = damageStates[1];
        }
        else if (health <= stateValues[0])
        {
            wallSprite.sprite = damageStates[0];
        }
    }

    private void ParticleHit()
    {
        breakLeft.Play();
        breakRight.Play();
    }
}
