using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject rainPrefab;
    [SerializeField] private float maxTime;
    private float timer;
    [SerializeField] private int totalScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Button gameOverBtn;
    private void Awake()
    {
        Time.timeScale = 1f;
        instance = this;
    }

    void Start()
    {
        timer = maxTime;
        InvokeRepeating(nameof(MakeRain), 0.25f, 0.5f);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer < 0)
        {
            Time.timeScale = 0f;
            gameOverBtn.gameObject.SetActive(true);
        }
        
        timeText.text = $"{timer:F2}";
    }

    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    private void MakeRain()
    {
        Instantiate(rainPrefab);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreText.text = $"{totalScore}";
    }

}
