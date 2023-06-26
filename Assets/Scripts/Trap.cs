using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] GameObject groundLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        groundLayer.gameObject.SetActive(true);
    }
}
