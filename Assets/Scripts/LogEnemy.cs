using System.Collections;
using UnityEngine;

public class LogEnemy : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private float KnockbackForce;
    [SerializeField] private EnemyData enemyType;
    [SerializeField] private Knockback knockbackController;
    private float enemyHealth;
    private Rigidbody2D rb;
    private Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyType.maxHealth;
        rb = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerPosition.position - transform.position).magnitude <= enemyType.auditionRange)
        {
            rb.velocity = (playerPosition.position - transform.position).normalized * enemyType.speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void RemoveLife(float lifeRemoved)
    {
        enemyHealth -= lifeRemoved;
        GetComponent<SpriteRenderer>().color = Color.red;
        if (enemyHealth < 0)
        {
            Destroy(gameObject);
        }
        StartCoroutine(ColorController());
    }

    private IEnumerator ColorController() 
    {
        yield return new WaitForSeconds(.10f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Knockback>().KnockbackAction((collision.transform.position - transform.position).normalized, enemyType.hitStrength, .15f, collision.rigidbody);
            manager.RemoveHealth(enemyType.damage);
        }
    }
}
