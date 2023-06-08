using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public float GetHealth() => maxHealth;
    public void Damage(float healthRemoved)
    {
        if (maxHealth - healthRemoved <= 0)
        {
            Death();
        }
        else
        {
            maxHealth -= healthRemoved;
        }
    }

    public void Heal(float healthAdded)
    {
        if (maxHealth + healthAdded >= maxHealth)
        {
            Death();
        }
        else
        {
            maxHealth += healthAdded;
        }
    }

    public void Death()
    {
        maxHealth = 0;
        print("Toy Muerto");
    }
}
