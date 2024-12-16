using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHealth : MonoBehaviour
{
    [SerializeField] private float minHealth;
    [SerializeField] private float maxHealth;
    float health;

    private void Awake()
    {
        health = maxHealth;
    }

    public void Heal(float amount)
    {
        if(health < maxHealth)
        {
            health = Mathf.Clamp(health + amount, minHealth, maxHealth);
        }
    }

    public void Damage(float amount)
    {
        if (health > minHealth)
        {
            health = Mathf.Clamp(health - amount, minHealth, maxHealth);
            if (health == minHealth)
            {
                OnDeath();
            }
        }
    }

    public abstract void OnDeath();
}
