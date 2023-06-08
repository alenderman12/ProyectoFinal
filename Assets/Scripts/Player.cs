using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private GameManager manager;
    [SerializeField] private TMP_Text textMeshPro;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float recoveryTime;
    private Vector3 direction;
    protected float damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        rb.velocity = (speed) * direction.normalized;
        textMeshPro.text = manager.GetHealth().ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

        }
    }
}
