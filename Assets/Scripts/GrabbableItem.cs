using UnityEngine;
using UnityEngine.Events;

public class GrabbableItem : MonoBehaviour
{
    [SerializeField] private UnityEvent OnItemGrab;

    public void ItemGrab()
    {
        OnItemGrab?.Invoke();
        Destroy(gameObject);
    }
}
