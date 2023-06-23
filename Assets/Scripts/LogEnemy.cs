using System.Collections;
using UnityEngine;

public class LogEnemy : Enemy
{
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
            if (/*!Physics2D.Raycast(transform.position, playerPosition.position, enemyType.auditionRange)*/ (transform.position - playerPosition.position).magnitude <= enemyType.auditionRange)
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
        Damage(lifeRemoved);
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
