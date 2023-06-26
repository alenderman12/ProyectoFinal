using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;

    public static GameManager instance;
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
            this.gameObject.name = "GameManager";
        }
    }

    public float GetHealth() => healthManager.GetHealth();


    public void RemoveHealth(float healthRemoved)
    {
        healthManager.Damage(healthRemoved);
    }

    public void AddHealth(float healthAdded)
    {
        healthManager.Heal(healthAdded);
    }

    public void Death()
    {
        healthManager.Death();
    }
}
