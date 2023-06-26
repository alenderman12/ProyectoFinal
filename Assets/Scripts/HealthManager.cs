using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject healthContainer;
    [SerializeField] private Sprite[] heartSprites;
    [SerializeField] private FloatValue health;
    private Image[] hearts;

    public float GetHealth() => health.value;

    private void Awake()
    {
        hearts = healthContainer.GetComponentsInChildren<Image>();
        RefreshHeartAnimation();
    }
    public void Damage(float healthRemoved/*, bool recoveryTime*/)
    {
        if (health.value - healthRemoved <= 0)
        {
            Death();
        }
        else
        {
            health.value -= healthRemoved;
            /*if (recoveryTime)
            {
                RecoveryTime();
            }*/
        }
        RefreshHeartAnimation();
        if (health.value <= 2)
        {
            healthContainer.GetComponent<AudioSource>().loop = true;
            healthContainer.GetComponent<AudioSource>().Play();
        }
    }

    public void Heal(float healthAdded)
    {
        if (health.value + healthAdded >= maxHealth)
        {
            health.value = maxHealth;
        }
        else
        {
            health.value += healthAdded;
        }
        healthContainer.GetComponent<AudioSource>().loop = false;
        RefreshHeartAnimation();
    }

    public void Death()
    {
        health.value = 8;
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator DeathAnimation()
    {

        yield return null;
    }

    private void RefreshHeartAnimation()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            print(hearts[i]);
            float heartsFill = health.value / 2;
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