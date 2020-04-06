using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ResultWindowHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text medalText;

    public TMP_Text ScoreText
        => this.scoreText;
    public TMP_Text MedalText
        => this.medalText;

    public void SetScore(int Score)
    {
        this.scoreText.text = Score.ToString();
    }

    public void SetMedal(int Score)
    {
        this.medalText.text = Score.ToString();
    }
}
