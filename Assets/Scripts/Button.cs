using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private bool oneUse;
    [SerializeField] private UnityEvent onButtonPressed;
    [SerializeField] private UnityEvent onButtonReleased;
    [SerializeField] private Sprite[] buttonSprites;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = buttonSprites[0];
        onButtonPressed?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!oneUse)
        {
            GetComponent<SpriteRenderer>().sprite = buttonSprites[1];
            onButtonReleased?.Invoke();
        }
    }
}
