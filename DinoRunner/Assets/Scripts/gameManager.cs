using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour

{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private float initialScrollSpeed;
    private int score;
    private float timer;
    private float ScrollSpeed;
    public static gameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }
    }

    
    void Update()
    {
        UpdateScore();
        UpdateSpeed();
    }

    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    private void UpdateScore()
    {
        int scorePerSeconds = 10;
        timer += Time.deltaTime;
        score = (int)(timer * scorePerSeconds);
        ScoreText.text = string.Format("{0:00000}", score);
    }

    public float GetScrollSpeed()
    {
        return ScrollSpeed;
    }
   
    private void UpdateSpeed()
    {
        float speedDivider = 10f;
        ScrollSpeed = initialScrollSpeed + timer/speedDivider;
    }
}
