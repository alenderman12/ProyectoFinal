using System.Collections;
using UnityEngine;

public class HoleBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject fallAnimation;
    [SerializeField] private GameObject player;
    [SerializeField] private GameManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 direction = new Vector3 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 animationPosition = collision.transform.position + direction * .5f;
        var fallAnimationInstance = Instantiate(fallAnimation, animationPosition, Quaternion.identity);
        StartCoroutine(animationControl(fallAnimationInstance, collision, direction));
        collision.gameObject.SetActive(false);
        GetComponent<AudioSource>().Play();
    }

    private IEnumerator animationControl(GameObject instance, Collider2D collision, Vector3 direction)
    {
        yield return new WaitForSeconds(0.571f);
        Destroy(instance);

        if (collision.tag == "Player")
        {
            yield return new WaitForSeconds(.5f);
            player.transform.position += -direction;
            manager.RemoveHealth(1);
            player.SetActive(true);
        }
    }
}
