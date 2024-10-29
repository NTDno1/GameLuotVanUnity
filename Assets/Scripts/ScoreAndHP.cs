using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndHP : MonoBehaviour
{
    public static ScoreAndHP scoreAndHP;
    public TextMeshProUGUI score;
    public TextMeshProUGUI hpChar;
    public int intScore;
    public int intHpChar = 3;
    private void Awake()
    {
        scoreAndHP = this;
    }
    void Start()
    {
        score.text = "Score: " + intScore.ToString();
        hpChar.text = "Hp: " + intHpChar.ToString();

    }

    public void AddScore()
    {
        intScore += 1;
        score.text = "Score: " + intScore.ToString();
    }
    public void MisusScore()
    {
        intScore -= 1;
        score.text = "Score: " + intScore.ToString();
    }
    public void MisusHP()
    {
        intHpChar -= 1;
        hpChar.text = "HP: " + intHpChar.ToString();
    }
}
