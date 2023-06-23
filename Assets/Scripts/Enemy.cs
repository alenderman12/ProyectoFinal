using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected GameManager manager;
    [SerializeField] protected float KnockbackForce;
    [SerializeField] protected EnemyData enemyType;
    [SerializeField] protected Knockback knockbackController;
    [SerializeField] protected GameObject heart;
    protected bool isAlive;
    protected float enemyHealth;
    protected Transform playerPosition;
    protected Animator animator;
    protected Rigidbody2D rb;

    protected void Damage(float lifeRemoved)
    {
        enemyHealth -= lifeRemoved;
        GetComponent<SpriteRenderer>().color = Color.red;
        if (enemyHealth < 0)
        {
            if (manager.GetHealth() != 8 && Random.Range(0, 100) < 49)
            {
                Instantiate(heart, transform.position, Quaternion.identity);
            }
            isAlive = false;
            animator.SetBool("isAlive", false);
            StartCoroutine(WaitForAnimation());
        }
        StartCoroutine(ColorController());
    }

    private IEnumerator ColorController()
    {
        yield return new WaitForSeconds(.10f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(.517f);
        isAlive = true;
        Destroy(gameObject);
    }
}
