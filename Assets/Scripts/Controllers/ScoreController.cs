
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Plan B Reloaded v0.0.0
/// Port of 'Plan B' for the BBC Model B by Andrew Foord - Copyright 1987
/// ScoreController.cs
/// Adapted from 'Learn to Code By Making a 2D Platformer in Unity'
/// by James Doyle
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 23/03/2019
/// </summary>

//
// modified 2020-08-10
//

public class ScoreController : MonoBehaviour
{
    public static ScoreController _scoreControllerInstance;



    public int score;



    private void Awake()
    {
        _scoreControllerInstance = this;
    }


    // Initialise score
    private void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        score = 0;
    }


    // Add points to score
    public void AddPoints(int points)
    {
        score += points;

        UpdateScoreValueText();
    }


    private void UpdateScoreValueText()
    {
        HudController._hudControllerInstance.scoreValueText.text = FormatScore();
    }


    private string FormatScore()
    {
        string scoreText = "";


        if (score < 0) { score = 0; }

        if (score == 0 || score >= 1 && score <= 9) { scoreText = "000000"; }

        if (score >= 10 && score <= 99) { scoreText = "00000"; }

        if (score >= 100 && score <= 999) { scoreText = "0000"; }

        if (score >= 1000 && score <= 9999) { scoreText = "000"; }

        if (score >= 10000 && score <= 99999) { scoreText = "00"; }

        if (score >= 100000 && score <= 999999) { scoreText = "0"; }

        if (score >= 1000000) { scoreText = ""; }


        scoreText += score.ToString();

        return scoreText;
    }


} // end of class
