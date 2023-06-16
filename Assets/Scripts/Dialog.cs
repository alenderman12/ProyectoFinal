using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject dialog;
    [TextArea(3,20)] [SerializeField] private string[] texts;
    [SerializeField] private float baseWordTime;
    private float wordTime;


    private void Start()
    {
        wordTime = baseWordTime;
        WriteDialog();
    }

    public void WriteDialog()
    {
        StartCoroutine(WriteDialogCo());
    }

    public IEnumerator WriteDialogCo()
    {
        this.dialog.SetActive(true);
        Player.characterState = CharacterState.interacting;
        foreach (var text in texts)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    wordTime = .005f;
                }
                dialog.GetComponentInChildren<TMP_Text>().text += text[i];

                yield return new WaitForSeconds(wordTime);
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            wordTime = baseWordTime;
            dialog.GetComponentInChildren<TMP_Text>().text = "";
        }

        this.dialog.SetActive(false);
        Player.characterState = CharacterState.idle;
    }
}
