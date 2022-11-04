using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToLoad : MonoBehaviour
{
    [Header("Loading")]
    public string levelName;
    public float delay;

    private bool canLoad = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("AllowLoad", delay);

        if (Application.isMobilePlatform)
        {
            Application.targetFrameRate = 165;
        }
    }

    private void AllowLoad()
    {
        canLoad = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (canLoad)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FMODUnity.RuntimeManager.CreateInstance("event:/Ribbit").start();
                SceneManager.LoadScene(levelName);

                canLoad = false;
            }
        }
    }
}
