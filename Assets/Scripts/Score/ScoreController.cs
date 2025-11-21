
using System;
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.05
//

public class ScoreController : MonoBehaviour
{
    public static ScoreController scoreController;


    public SpriteRenderer[] scoreSpriteRenderer;

    public Sprite[] numberSprite;


    private const int NUMBER_OF_DIGITS = 7;



    private void Awake()
    {
        scoreController = this;
    }


    public void InitialiseScore()
    {
        for (int scoreDigit = 0; scoreDigit < NUMBER_OF_DIGITS; scoreDigit++)
        {
            scoreSpriteRenderer[scoreDigit].sprite = numberSprite[0];
        }
    }


    public void UpdateScoreDisplay(int score)
    {
        string scoreString = score.ToString("0000000");

        Debug.Log("scoreString: " + scoreString);

        for (int digitPosition = 0; digitPosition < scoreString.Length; digitPosition++)
        {
            string digitText = scoreString.Substring(digitPosition, 1);

            int digit = Convert.ToInt32(digitText);

            UpdateScore(scoreString, score, digitPosition, digit);
        }
    }


    private void UpdateScore(string scoreText, int score, int digitPosition, int digit)
    {
        int[] digitsArray = new int[NUMBER_OF_DIGITS + 1];


        // 0
        if (score < 10)
        {
            scoreSpriteRenderer[digitPosition].sprite = numberSprite[digit];
        }


        // 00
        if (score > 9 && score < 100)
        {
            digitsArray[digit] = digit;

            digitsArray[digit] /= 10;

            scoreSpriteRenderer[digitPosition].sprite = numberSprite[digit];
        }


        // 000
        if (score > 99 && score < 1000)
        {
            digitsArray[digit] %= 100;

            digitsArray[digit] /= 10;


            digitsArray[digit] /= 100;


            scoreSpriteRenderer[digitPosition].sprite = numberSprite[digit];
        }


        // 0000
        if (score > 999 && score < 10000)
        {
            digitsArray[digit] %= 1000;

            digitsArray[digit] %= 100;

            digitsArray[digit] /= 10;


            digitsArray[digit] %= 1000;

            digitsArray[digit] /= 100;


            digitsArray[digit] /= 1000;


            scoreSpriteRenderer[digitPosition].sprite = numberSprite[digit];
        }


        // 00000
        if (score > 9999 && score < 100000)
        {
            digitsArray[digit] %= 10000;

            digitsArray[digit] %= 1000;

            digitsArray[digit] %= 100;

            digitsArray[digit] /= 10;


            digitsArray[digit] %= 10000;

            digitsArray[digit] %= 1000;

            digitsArray[digit] /= 100;


            digitsArray[digit] %= 10000;

            digitsArray[digit] /= 1000;


            digitsArray[digit] /= 10000;


            scoreSpriteRenderer[digitPosition].sprite = numberSprite[digit];
        }


        // 000000
        if (score > 99999 && score < 1000000)
        {
            digitsArray[digit] %= 100000;

            digitsArray[digit] %= 10000;

            digitsArray[digit] %= 1000;

            digitsArray[digit] %= 100;

            digitsArray[digit] /= 10;


            digitsArray[digit] %= 100000;

            digitsArray[digit] %= 10000;

            digitsArray[digit] %= 1000;

            digitsArray[digit] /= 100;


            digitsArray[digit] %= 100000;

            digitsArray[digit] %= 10000;

            digitsArray[digit] /= 1000;


            digitsArray[digit] %= 100000;

            digitsArray[digit] /= 10000;


            digitsArray[digit] /= 100000;


            scoreSpriteRenderer[digitPosition].sprite = numberSprite[digit];
        }


        // 0000000
        if (score > 999999 && score < 10000000)
        {
            digitsArray[digit] %= 1000000;

            digitsArray[digit] %= 100000;

            digitsArray[digit] %= 10000;

            digitsArray[digit] %= 1000;

            digitsArray[digit] %= 100;

            digitsArray[digit] /= 10;


            digitsArray[digit] %= 1000000;

            digitsArray[digit] %= 100000;

            digitsArray[digit] %= 10000;

            digitsArray[digit] %= 1000;

            digitsArray[digit] /= 100;


            digitsArray[digit] %= 1000000;

            digitsArray[digit] %= 100000;

            digitsArray[digit] %= 10000;

            digitsArray[digit] /= 1000;


            digitsArray[digit] %= 1000000;

            digitsArray[digit] %= 100000;

            digitsArray[digit] /= 10000;


            digitsArray[digit] %= 1000000;

            digitsArray[digit] /= 100000;


            digitsArray[digit] /= 1000000;


            scoreSpriteRenderer[digitPosition].sprite = numberSprite[digit];
        }
    }


} // end of class
