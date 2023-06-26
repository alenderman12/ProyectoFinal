using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCutscene1 : MonoBehaviour
{
    [SerializeField] private GameObject signal;
    [SerializeField] private string sceneName;

    // Update is called once per frame
    void Update()
    {
        print(Player.characterState);
        if (Dialog.dialogEnded)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
