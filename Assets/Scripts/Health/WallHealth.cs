﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : HealthSystem
{
    public SpriteRenderer wallSprite;
    public List<Sprite> damageStates;
    public List<int> stateValues;
    public ParticleSystem breakLeft;
    public ParticleSystem breakRight;

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