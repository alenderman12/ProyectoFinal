using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCutscene : MonoBehaviour
{
    [SerializeField] private GameObject signal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!signal.activeInHierarchy)
        {

            SceneManager.LoadScene("MainHouse");
        }
    }
}
