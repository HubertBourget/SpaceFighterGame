using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarterMenuScore : MonoBehaviour
{
[SerializeField] TMP_Text highScoreTMP;
string highScoreText = "Highest Score : ";
int previousBestScore;

void Awake() 
    {
        previousBestScore = PlayerPrefs.GetInt("highscore");
    }

 void OnEnable() 
{
    highScoreTMP.text = highScoreText + previousBestScore.ToString();
}   

}
