using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public enum CharacterState
{
    idle,
    walking,
    interacting,
    attacking
}

public class Player : MonoBehaviour
{
    [SerializeField] private int baseSpeed;
    [SerializeField] private GameManager manager;
    [SerializeField] private float recoveryTime;
    public static CharacterState characterState;
    private float speed;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 direction;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        speed = baseSpeed;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetKeyDown(KeyCode.X) && characterState != CharacterState.interacting && characterState != CharacterState.attacking)
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

    public void SetPlayerPosition(Vector3 position)
    {
        transform.position = position;
    }
}
