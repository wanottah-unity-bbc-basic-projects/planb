
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Plan B 2020 Mk i
/// GameController.cs
/// Port of Atari's 1972 video game
/// by Atari
/// Adapted from 'Learn to Create A Roguelike Game in Unity'
/// by James Doyle
/// Created: 13/01/2020
/// </summary>

//
// v2025.10.15
//

public class GameController : MonoBehaviour
{


    // reference to text components
    //public Text player1ScoreText;
    //public Text player2ScoreText;
    //public Text player3ScoreText;
    //public Text player4ScoreText;


    public Text gameOverText;


    // player scores
    [HideInInspector] public int player1Score;
    [HideInInspector] public int player2Score;
    //[HideInInspector] public int player3Score;
    //[HideInInspector] public int player4Score;

    // game credits
    [HideInInspector] public int gameCredits;


    // player boundaries
    [HideInInspector] public float upperScreenBoundary;
    [HideInInspector] public float lowerScreenBoundary;
    [HideInInspector] public float leftScreenBoundary;
    [HideInInspector] public float rightScreenBoundary;
    private float upperBoundary;
    private float lowerBoundary;
    private float leftBoundary;
    private float rightBoundary;


    // game mode
    [HideInInspector] public bool canPlay;
    [HideInInspector] public bool inPlayMode;
    [HideInInspector] public bool inDemoMode;
    [HideInInspector] public bool inPawzMode;


    // direction of player
    public const int STOPPED = 0;
    public const int UP = 1;
    public const int DOWN = -1;
    public const int LEFT = -1;
    public const int RIGHT = 1;


    public const int PLAYER_ONE = 1;
    public const int PLAYER_TWO = 2;
    public const int PLAYER_THREE = 3;
    public const int PLAYER_FOUR = 4;


    // colours
    public const int WHITE = 255;
    public const int RED = 255;
    public const int GREEN = 255;
    public const int BLUE = 255;


    // game arena y offset
    public const float POSITIVE_Y_OFFSET = 0.33f;
    public const float NEGATIVE_Y_OFFSET = -0.33f;

    public const int START_SCORE = 0;
    private const int WINNING_SCORE = 11;
    private const int GAMEOVER_SCORE = 0;



    void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        InitialiseGameModes();

        InitialiseScreenBoundaries();

        StartDemoMode();
    }


    private void InitialiseGameModes()
    {
        canPlay = false;

        inPawzMode = false;
        inDemoMode = false;
        inPlayMode = false;
    }


    private void InitialiseScreenBoundaries()
    {
        upperBoundary = 4.3f;

        lowerBoundary = -4.3f;

        //leftBoundary = -6.43f;

        //rightBoundary = 6.43f;
    }


    // =============================================================================
    // check for player input
    // =============================================================================
    void Update()
    {
        ControllerInput();
    }


    private void ControllerInput()
    {
        if (!inPawzMode)
        {
            //player1SpriteController.CheckPlayerInput();

            //player2SpriteController.CheckPlayerInput();

            //player3SpriteController.CheckPlayerInput();

            //player4SpriteController.CheckPlayerInput();
        }
    }


    // =============================================================================
    // set upper and lower limits for player sprite movement
    // =============================================================================
    private void SetGameArenaBoundaries()
    {
        // player boundaries
        upperScreenBoundary = upperBoundary + GameController.POSITIVE_Y_OFFSET;

        lowerScreenBoundary = lowerBoundary + GameController.POSITIVE_Y_OFFSET;

        //leftBoundary = -6.43f;

        //rightBoundary = 6.43f;
    }


    public void SetPawzMode()
    {
        //SetGamePadControllers();

        //ballSpriteController.FreezeBall();
    }


    public void SetPlayMode()
    {
        //SetGamePadControllers();

        //ballSpriteController.ResumeBall();
    }


    // Start demo mode
    public void StartDemoMode()
    {
        gameOverText.gameObject.SetActive(true);

        // start demo mode
        inDemoMode = true;
        inPlayMode = false;

        SetGameArenaBoundaries();

        //player1SpriteController.player1IsComputer = true;

        //player2SpriteController.player2IsComputer = true;

        //player2SpriteController.isPlayer2 = false;


        //player3SpriteController.player3IsComputer = true;

        //player3SpriteController.isPlayer3 = false;


        //player4SpriteController.player4IsComputer = true;

        //player4SpriteController.isPlayer4 = false;


        // initialise paddles
        //player1SpriteController.InitialiseSprite();

        //player2SpriteController.InitialiseSprite();

        //player3SpriteController.InitialisePaddle();

        //player4SpriteController.InitialisePaddle();


        // disable dpads
        //player1Dpad.gameObject.SetActive(false);

        //player2Dpad.gameObject.SetActive(false);

        //player3Dpad.gameObject.SetActive(false);

        //player4Dpad.gameObject.SetActive(false);


        // Enable ball
        //ballSpriteController.gameObject.SetActive(true);

        // Call ball controller script
        //ballSpriteController.InitialiseBall();
    }


    // Start one player game
    public void StartOnePlayerGame()
    {
        //player1SpriteController.player1IsComputer = false;


        //player2SpriteController.player2IsComputer = true;

        //player2SpriteController.isPlayer2 = false;


        //player3SpriteController.player3IsComputer = true;

        //player3SpriteController.isPlayer3 = false;


        //player4SpriteController.player4IsComputer = true;

        //player4SpriteController.isPlayer4 = false;


        InitialiseGameMode();
    }


    // Start two player game
    public void StartTwoPlayerGame()
    {
        //player1SpriteController.player1IsComputer = false;


        //player2SpriteController.player2IsComputer = false;

        //player2SpriteController.isPlayer2 = true;


        //player3SpriteController.player3IsComputer = true;

        //player3SpriteController.isPlayer3 = false;


        //player4SpriteController.player4IsComputer = true;

        //player4SpriteController.isPlayer4 = false;


        InitialiseGameMode();
    }


    // Start two player game
    public void StartThreePlayerGame()
    {
        //player1SpriteController.player1IsComputer = false;


        //player2SpriteController.player2IsComputer = false;

        //player2SpriteController.isPlayer2 = true;


        //player3SpriteController.player3IsComputer = false;

        //player3SpriteController.isPlayer3 = true;


        //player4SpriteController.player4IsComputer = true;

        //player4SpriteController.isPlayer4 = false;


        InitialiseGameMode();
    }


    // Start two player game
    public void StartFourPlayerGame()
    {
        //player1SpriteController.player1IsComputer = false;


        //player2SpriteController.player2IsComputer = false;

        //player2SpriteController.isPlayer2 = true;


        //player3SpriteController.player3IsComputer = false;

        //player3SpriteController.isPlayer3 = true;


        //player4SpriteController.player4IsComputer = false;

        //player4SpriteController.isPlayer4 = true;


        InitialiseGameMode();
    }


    // Initialise
    private void InitialiseGameMode()
    {

        gameOverText.gameObject.SetActive(false);

        inPlayMode = true;
        inDemoMode = false;

        InitialiseScore();

        // initialise paddles
        //player1SpriteController.InitialiseSprite();

        //player2SpriteController.InitialiseSprite();

        //player3SpriteController.InitialisePaddle();

        //player4SpriteController.InitialisePaddle();


        // initialise game controllers
        //SetGamePadControllers();


        // Reset and enable ball
        //ballSpriteController.ResetBall(ballSpriteController.ballSpeed, ballSpriteController.ballSpeed);
    }


    private void SetGamePadControllers()
    {
        if (inPawzMode)
        {
            //player1Dpad.gameObject.SetActive(false);

            //player2Dpad.gameObject.SetActive(false);

            //player3Dpad.gameObject.SetActive(false);

            //player4Dpad.gameObject.SetActive(false);
        }

        else
        {
            //player1Dpad.gameObject.SetActive(true);

            //if (player2SpriteController.player2IsComputer)
            //{
            //player2Dpad.gameObject.SetActive(false);
            //}

            //else
            //{
            //player2Dpad.gameObject.SetActive(true);
            //}
        }
    }


    private void InitialiseScore()
    {
        player1Score = START_SCORE;

        player2Score = START_SCORE;

        //player3Score = 0;

        //player4Score = 0;

        UpdateScoreText();
    }


    // When a goal is scored . . .
    public void GoalScored(int playerScored)
    {
        if (!inDemoMode)
        {
            // update score
            UpdateScore(playerScored);

            IsGameOver(playerScored);
        }
    }


    // update score
    private void UpdateScore(int playerScored)
    {
        if (!inDemoMode)
        {
            switch (playerScored)
            {
                case PLAYER_ONE:

                    UpdatePlayer1Score();

                    break;

                case PLAYER_TWO:

                    UpdatePlayer2Score();

                    break;
            }

            IsGameOver(playerScored);
        }
    }


    public void UpdatePlayer1Score()
    {
        player1Score = player1Score + 1;

        UpdateScoreText();
    }


    public void UpdatePlayer2Score()
    {
        player2Score = player2Score + 1;

        UpdateScoreText();
    }


    // Check if game over
    public void IsGameOver(int playerScored)
    {
        // Check to see which player has won
        if (player1Score == WINNING_SCORE)
        {
            GameOver(PLAYER_ONE);
        }

        else if (player2Score == WINNING_SCORE)
        {
            GameOver(PLAYER_TWO);
        }
    }


    // When the game is over
    private void GameOver(int winner)
    {
        StartDemoMode();
    }


    // Update the player's scores
    private void UpdateScoreText()
    {
        //player1ScoreText.text = player1Score.ToString();

        //player2ScoreText.text = player2Score.ToString();

        //player3ScoreText.text = player3Score.ToString();

        //player4ScoreText.text = player4Score.ToString();
    }


} // end of class
