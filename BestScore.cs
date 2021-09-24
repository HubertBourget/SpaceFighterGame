using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    [SerializeField] TMP_Text bestScore;
    string bestScoreText = "Best Score : ";

    int previousBestScore;

    void Awake() 
    {
        previousBestScore = PlayerPrefs.GetInt("highscore");
    }
    void OnEnable() 
    {
        ScoreBoard actualScoreBoard = FindObjectOfType<ScoreBoard>();
        int actualScore = actualScoreBoard.score;

        if(actualScore > previousBestScore)
        {
        bestScore.text = bestScoreText + actualScore.ToString();
        PlayerPrefs.SetInt("highscore", actualScore);
        }
        else
        {
            bestScore.text = bestScoreText + previousBestScore.ToString();
        }
        // the save can be accessed in regedit
    }
}
