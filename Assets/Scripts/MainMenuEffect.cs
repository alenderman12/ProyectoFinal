using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject text;
    [SerializeField] private float timeToToogle;
    [SerializeField] private GameManager manager;
    private float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeToToogle && text != null) 
        {
            time = 0;
            text.SetActive(!text.activeInHierarchy);
        }

        if (Input.anyKey)
        {
            SceneManager.LoadScene("IntroCutscene");
        }
    }
}
