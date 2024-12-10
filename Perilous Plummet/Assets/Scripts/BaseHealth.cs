using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float minHealth;
    [SerializeField] private float maxHealth;

    public void ChangeHealth(float amount)
    {
        health += amount;
    }

    public void OnDeath()
    {

    }
}
