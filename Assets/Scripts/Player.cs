using System.Collections;
using UnityEngine;

public enum CharacterState
{
    idle,
    walking,
    interacting,
    attacking,
    changingRoom
}

public class Player : MonoBehaviour
{
    [SerializeField] private int baseSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float hitForce;
    public static CharacterState characterState;
    private float speed;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 direction;
    private Knockback knockbackController;
    // Start is called before the first frame update
    void Start()
    {
        speed = baseSpeed;
        knockbackController = GetComponent<Knockback>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterState != CharacterState.changingRoom)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");
            rb.velocity = (speed) * direction.normalized;
            if (characterState != CharacterState.attacking && characterState != CharacterState.interacting)
            {
                if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                {
                    animator.SetFloat("XMovement", direction.x);
                    animator.SetFloat("YMovement", direction.y);
                    animator.SetBool("isMoving", true);
                    characterState = CharacterState.walking;
                }
                else
                {
                    characterState = CharacterState.idle;
                    animator.SetBool("isMoving", false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.X) && characterState != CharacterState.interacting && characterState != CharacterState.attacking && characterState != CharacterState.changingRoom)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        characterState = CharacterState.attacking;
        animator.SetBool("IsAttacking", true);
        yield return new WaitForEndOfFrame();
        animator.SetBool("IsAttacking", false);
        GetComponent<AudioSource>().Play();
        speed = 0;
        yield return new WaitForSeconds(.35f);
        speed = baseSpeed;
        characterState = CharacterState.idle;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Knockback>().KnockbackAction((collision.transform.position - transform.position).normalized, hitForce, .15f, collision.attachedRigidbody);
            collision.GetComponent<LogEnemy>().RemoveLife(damage);
        }
        else if (collision.tag == "Heart")
        {
            collision.gameObject.GetComponent<GrabbableItem>().ItemGrab();
            GameManager.instance.AddHealth(2);
        }
    }
}
