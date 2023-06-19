using Cinemachine;
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
            Time.timeScale = 1;
        }
    }
}