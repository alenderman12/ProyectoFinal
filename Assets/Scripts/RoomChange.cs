using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] cameras;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            foreach (var camera in cameras)
            {
                camera.gameObject.SetActive(!camera.gameObject.activeInHierarchy);
            }
        }
    }

    private IEnumerator FixPlayerPosition()
    {
        
        yield return null;
    }
}