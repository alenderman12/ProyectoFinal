using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject doorOpen;
    [SerializeField] private GameObject doorClosed;
    [SerializeField] private GameObject doorCollider;
    [SerializeField] private AudioSource solveSound;

    bool buttonIsActive;
    bool button1IsActive;

    public void OpenByButtons(string button)
    {
        if (button == "Button")
        {
            buttonIsActive = true;
        }

        else if (button == "Button1")
        {
            button1IsActive = true;
        }

        if (buttonIsActive && button1IsActive)
        {
            solveSound.Play();
            doorClosed.SetActive(false);
            doorCollider.SetActive(false);
            doorOpen.SetActive(true);
        }
    }
}
