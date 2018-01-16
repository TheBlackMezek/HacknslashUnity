using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score = 0;

    public Text scoreText;



    private void Start()
    {
        SetScore(score);
    }

    public void SetScore(int s)
    {
        score = s;
        if(scoreText)
        {
            scoreText.text = "SCORE: " + score.ToString();
        }
    }

    public void AddScore(int s)
    {
        SetScore(score + s);
    }

}
