using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRoomController : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private UnityEvent OnFinish;
    [SerializeField] private List<GameObject> enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnter?.Invoke();
        if (collision.tag == "Player")
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                print("Activated [i] enemy");
                enemies[i].SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (enemies.Count == 0)
        {
            print("Bro have no enemies");
            OnFinish?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(WaitForEnemyAnim());
    }

    private IEnumerator WaitForEnemyAnim()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.Remove(enemies[i]);
            }
        }
    }
}
