using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    [SerializeField] TMP_Text currentScore;
    string currentScoreText = "Current Score : ";
    void OnEnable() 
    {
        ScoreBoard newScore = FindObjectOfType<ScoreBoard>();
        currentScore.text = currentScoreText + newScore.score.ToString();
    }
}
