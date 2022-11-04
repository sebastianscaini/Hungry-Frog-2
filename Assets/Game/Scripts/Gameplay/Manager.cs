using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [Header("Hunger")]
    public float maxHunger = 100f;
    public float hungerDrainRate = 1f;
    public GameObject lilipad;
    public GameObject frog;
    public GameObject tongue;
    public GameObject tongueLine;
    public float currentHunger;

    [Header("Score")]
    public int score;

    [Header("UI")]
    public TextMeshPro scoreDisplay;
    public TextMeshPro HighscoreDisplay;

    private void Start()
    {
        currentHunger = maxHunger;
        StartCoroutine(HandleHunger());

        InvokeRepeating("IncreaseDifficulty", 2.5f, 5f);
    }

    private void Update()
    {
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);
        lilipad.transform.localScale = new Vector3(currentHunger / maxHunger, currentHunger / maxHunger, 1f);

        scoreDisplay.text = score.ToString();
        HighscoreDisplay.text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void AddScore()
    {
        score++;

        scoreDisplay.gameObject.ShakeScale(new Vector3(0.5f, 0.5f, 0f), 0.1f, 0f);

        if(score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
            HighscoreDisplay.gameObject.ShakeScale(new Vector3(0.5f, 0.5f, 0f), 0.1f, 0f);
        }
    }

    private IEnumerator HandleHunger()
    {
        while(currentHunger > 0f)
        {
            currentHunger -= hungerDrainRate;

            yield return new WaitForSeconds(1f);
        }

        Destroy(tongue);
        Destroy(tongueLine);

        frog.GetComponent<Rigidbody2D>().gravityScale = 1f;
        frog.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-1f, 1f), ForceMode2D.Impulse);

        FMODUnity.RuntimeManager.CreateInstance("event:/Ribbit").start();

        yield return new WaitForSeconds(1f);

        FMODUnity.RuntimeManager.CreateInstance("event:/Splash").start();

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Menu");
    }

    private void IncreaseDifficulty()
    {
        hungerDrainRate += 0.5f;
    }
}
