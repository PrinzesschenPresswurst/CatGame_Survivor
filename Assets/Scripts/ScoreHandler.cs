using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int _score = 0;

    public void Start()
    {
        UpdateScore();
        Treat.OnFishCollected += TreatOnOnFishCollected;
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + _score;
    }

    private void TreatOnOnFishCollected(object sender, Treat.OnFishCollectedEventArgs e)
    {
        _score = _score + e.TreatScore;
        UpdateScore();
    }
}
