using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreBoard : MonoBehaviour
{
    public int score;
    [SerializeField] TMP_Text scoreText;


    
    void Start() 
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = score.ToString();
    }
}
