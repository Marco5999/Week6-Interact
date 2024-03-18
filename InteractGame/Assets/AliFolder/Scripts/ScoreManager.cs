using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncrementScore(int value)
    {
        score += value;
        UpdateScoreText();
    }
}
