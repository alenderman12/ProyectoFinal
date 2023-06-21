using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject healthContainer;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite[] heartSprites;
    private float health;

    public float GetHealth() => health;

    private void Awake()
    {
        health = maxHealth;
        RefreshHeartAnimation();
    }
    public void Damage(float healthRemoved/*, bool recoveryTime*/)
    {
        if (health - healthRemoved <= 0)
        {
            Death();
        }
        else
        {
            health -= healthRemoved;
            /*if (recoveryTime)
            {
                RecoveryTime();
            }*/
        }
        RefreshHeartAnimation();
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
        RefreshHeartAnimation();
    }

    public void Death()
    {
        health = 0;
        print("Toy Muerto");
    }

    private void RecoveryTime()
    {

    }

    private void RefreshHeartAnimation()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            float heartsFill = health / 2;
            if (i <= heartsFill-1)
            {
                hearts[i].sprite = heartSprites[0];
            }
            else if (i >= heartsFill)
            {
                hearts[i].sprite = heartSprites[2];
            }
            else
            {
                hearts[i].sprite = heartSprites[1];
            }
        }
    }
}