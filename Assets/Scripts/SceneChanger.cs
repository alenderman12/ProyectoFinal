using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class SceneChanger : MonoBehaviour
{
    private void Awake()
    {

        Time.maximumDeltaTime = 0.001f;
    }
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
                StartCoroutine(SceneChangeEffect(collision));
            }
            else
            {
                SceneManager.LoadScene(sceneToChange);
            }
            collision.transform.position = GetVector3(SceneManager.GetActiveScene() + "PlayerPos");
        }
    }
    private IEnumerator SceneChangeEffect(Collider2D collision)
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

    public void SaveVector3(string vectorKey, UnityEngine.Vector3 vector3)
    {
        float x = vector3.x;
        float y = vector3.y;
        float z = vector3.z;

        PlayerPrefs.SetFloat(vectorKey + "x", x);
        PlayerPrefs.SetFloat(vectorKey + "y", y);
        PlayerPrefs.SetFloat(vectorKey + "z", z);
    }


    public UnityEngine.Vector3 GetVector3(string vectorKey)
    {
        float x = PlayerPrefs.GetFloat(vectorKey + "x");
        float y = PlayerPrefs.GetFloat(vectorKey + "y");
        float z = PlayerPrefs.GetFloat(vectorKey + "z");

        return new UnityEngine.Vector3(x, y, z);
    }
}
