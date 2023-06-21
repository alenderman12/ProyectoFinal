using UnityEngine;
using UnityEngine.Events;

public class GrabbableItem : MonoBehaviour
{
    [SerializeField] private UnityEvent OnItemGrab;
    private GameManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnItemGrab?.Invoke();
        Destroy(gameObject);
    }
}
