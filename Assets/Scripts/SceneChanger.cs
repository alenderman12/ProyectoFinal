using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] private float effectTime;
    [SerializeField] private bool useEffect;
    [SerializeField] private RawImage image;
    [SerializeField] private string sceneToChange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SaveVector3(SceneManager.GetActiveScene() + "PlayerPos", collision.transform.position);
            if (useEffect)
            {
                StartCoroutine(SceneChangeEffect());
            }
            else
            {
                SceneManager.LoadScene(sceneToChange);
            }
        }
    }

    private IEnumerator SceneChangeEffect()
    {
        Time.timeScale = 0;
        for (float i = 0; i < 1; i += Time.unscaledDeltaTime / effectTime)
        {
            image.color += new Color(0, 0, 0, Time.unscaledDeltaTime / effectTime);
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(sceneToChange);
        Time.timeScale = 1;
    }

    public void SaveVector3(string vectorKey, Vector3 vector3)
    {
        float x = vector3.x;
        float y = vector3.y;
        float z = vector3.z;

        PlayerPrefs.SetFloat(vectorKey + "x", x);
        PlayerPrefs.SetFloat(vectorKey + "y", y);
        PlayerPrefs.SetFloat(vectorKey + "z", z);
    }


    public Vector3 GetVector3(string vectorKey)
    {
        float x = PlayerPrefs.GetFloat(vectorKey + "x");
        float y = PlayerPrefs.GetFloat(vectorKey + "y");
        float z = PlayerPrefs.GetFloat(vectorKey + "z");

        return new Vector3(x, y, z);
    }
}
