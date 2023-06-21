using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{
    [SerializeField] private UnityEvent OnBegin;
    [SerializeField] private UnityEvent OnFinished;
    public void KnockbackAction(Vector3 direction, float force, float inactiveTime, Rigidbody2D rb)
    {
        OnBegin?.Invoke();
        rb.AddForce(direction * force, ForceMode2D.Impulse);
        StartCoroutine(Reset(inactiveTime, rb));
    }

    private IEnumerator Reset(float time, Rigidbody2D rb)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector3.zero;
        OnFinished?.Invoke();
    }
}
