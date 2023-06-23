using System.Collections;
using UnityEngine;

public class LogEnemy : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private float KnockbackForce;
    [SerializeField] private EnemyData enemyType;
    [SerializeField] private Knockback knockbackController;
    private bool isAlive;
    private float enemyHealth;
    private Transform playerPosition;
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        enemyHealth = enemyType.maxHealth;
        rb = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (!Physics2D.Raycast(transform.position, playerPosition.position, enemyType.auditionRange))
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("PlayerDirectionX", rb.velocity.normalized.x);
                animator.SetFloat("PlayerDirectionY", rb.velocity.normalized.y);
                rb.velocity = (playerPosition.position - transform.position).normalized * enemyType.speed;
            }
            else
            {
                animator.SetBool("isMoving", false);
                rb.velocity = Vector2.zero;
            }
        }
    }

    public void RemoveLife(float lifeRemoved)
    {
        enemyHealth -= lifeRemoved;
        GetComponent<SpriteRenderer>().color = Color.red;
        if (enemyHealth < 0)
        {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Knockback>().KnockbackAction((collision.transform.position - transform.position).normalized, enemyType.hitStrength, .15f, collision.rigidbody);
            manager.RemoveHealth(enemyType.damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, playerPosition.position);
    }
}
