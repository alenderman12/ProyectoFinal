using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject healthContainer;
    [SerializeField] private Sprite[] heartSprites;
    [SerializeField] private FloatValue health;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private RawImage sceneChangerImage;
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
            health.value = 0;
            RefreshHeartAnimation();
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
        healthContainer.GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        StartCoroutine(DeathAnimation());
    }

    private IEnumerator DeathAnimation()
    {
        playerAnimator.SetBool("isAlive", false);
        yield return new WaitForEndOfFrame();
        playerAnimator.SetBool("isAlive", true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(.267f);
        yield return new WaitUntil(() => Input.anyKeyDown);
        health.value = 8;
        sceneChanger.ChangeScene(true, "MainMenu", .5f, sceneChangerImage);
    }

    private void RefreshHeartAnimation()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
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