using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;

    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            this.gameObject.name = "GameManager";
            DontDestroyOnLoad(gameObject);
        }
    }

    public float GetHealth() => healthManager.GetHealth();


    public void RemoveHealth(int healthRemoved)
    {
        healthManager.Damage(healthRemoved);
    }

    public void AddHealth(int healthAdded)
    {
        healthManager.Heal(healthAdded);
    }

    public void Death()
    {
        healthManager.Death();
    }
}
