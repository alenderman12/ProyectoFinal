using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LogEnemy : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private float KnockbackForce;
    [SerializeField] private EnemyData enemyType;
    [SerializeField] private Knockback knockbackController;
    private Rigidbody2D rb;
    private Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerPosition.position - transform.position).magnitude <= enemyType.auditionRange)
        {
            transform.position = Vector3.MoveTowards(playerPosition.position, transform.position, enemyType.speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            knockbackController.KnockbackAction((collision.transform.position - transform.position).normalized, enemyType.hitStrength, .15f, collision.rigidbody);
            manager.RemoveHealth(enemyType.damage);
        }
        else if (collision.gameObject.tag == "Player")
        {

        }
    }
}
