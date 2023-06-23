using Cinemachine;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.characterState = CharacterState.changingRoom;
            foreach (var camera in cameras)
            {
                camera.gameObject.SetActive(!camera.gameObject.activeInHierarchy);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player.characterState = CharacterState.idle;
    }
}