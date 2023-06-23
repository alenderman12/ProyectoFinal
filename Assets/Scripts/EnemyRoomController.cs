using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemiesToSpawn;
    private void OnRoomEnter()
    {
        foreach (var enemy in enemiesToSpawn)
        {
            Instantiate(enemy);
        }
    }
}
