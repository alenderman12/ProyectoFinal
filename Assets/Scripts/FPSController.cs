using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(RefreshFramerate());
    }

    private IEnumerator RefreshFramerate()
    {
        while (true)
        {
            GetComponentInChildren<TMP_Text>().text = (Mathf.RoundToInt(1 / Time.unscaledDeltaTime)).ToString();
            yield return new WaitForSeconds(1);
        }
    }
}
