using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    //Public variables
    public static Score Instance;
    //Private variables
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI hightestScoreText;

    private int score;
    private int hightestScore;
    //Protected variables

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        if (PlayerPrefs.HasKey("HightestScore"))
        {
            hightestScore = PlayerPrefs.GetInt("HightestScore");
        }
        else
        {
            hightestScore = 0;
        }
        
        scoreText.text = score.ToString();
        hightestScoreText.text = hightestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateScore()
    {
        score++;
        UpdateHightestScore();
    }
    void UpdateHightestScore()
    {
        if (score > PlayerPrefs.GetInt("HightestScore"))
        {
            PlayerPrefs.SetInt("HightestScore", score);
        }
    }
}
