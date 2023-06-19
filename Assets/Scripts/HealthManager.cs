using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject heartContainer;
    private SpriteRenderer[] hearts;
    private float health;

    public float GetHealth() => health;

    private void Awake()
    {
        hearts = heartContainer.GetComponentsInChildren<SpriteRenderer>();
        health = maxHealth;
        RefreshHeartAnimation(health);
    }
    public void Damage(float healthRemoved)
    {
        if (maxHealth - healthRemoved <= 0)
        {
            Death();
        }
        else
        {
            health -= healthRemoved;
        }
        RefreshHeartAnimation(health);
    }

    public void Heal(float healthAdded)
    {
        if (health + healthAdded >= maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healthAdded;
        }
        RefreshHeartAnimation(health);
    }

    public void Death()
    {
        health = 0;
        print("Toy Muerto");
    }

    private void RefreshHeartAnimation(float life)
    {

    }
}
