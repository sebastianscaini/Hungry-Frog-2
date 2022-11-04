using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetHighscore : MonoBehaviour
{
    private TextMeshPro tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
}
