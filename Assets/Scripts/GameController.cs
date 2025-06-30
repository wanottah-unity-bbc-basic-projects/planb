
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
// modified 2020-08-04
//

public class GameController : MonoBehaviour
{
    // reference to audio controller script
    private AudioController audioController;

    // reference to atari console controller script
    [SerializeField] private AtariConsoleController atariConsoleController;


    // reference to player controller scripts
    //[SerializeField] private Player1SpriteController player1SpriteController = null;
    //[SerializeField] private Player2SpriteController player2SpriteController = null;
    //[SerializeField] private Player2SpriteController player3SpriteController;
    //[SerializeField] private Player2SpriteController player4SpriteController;

    // reference to ball controller script
    //public BallSpriteController ballSpriteController;


    // reference to d-pad controllers
    //[SerializeField] private GameObject player1Dpad;
    //[SerializeField] private GameObject player2Dpad;
    //[SerializeField] private GameObject player3Dpad;
    //[SerializeField] private GameObject player4Dpad;


    // reference to text components
    //public Text player1ScoreText;
    //public Text player2ScoreText;
    //public Text player3ScoreText;
    //public Text player4ScoreText;

    public Text insertCoinsText;
    public Text coinsInsertedText;

    public Text gameOverText;


    // player scores
    [HideInInspector] public int player1Score;
    [HideInInspector] public int player2Score;
    //[HideInInspector] public int player3Score;
    //[HideInInspector] public int player4Score;

    // game credits
    [HideInInspector] public int gameCredits;


    // player difficulty settings
    private float leftDifficultyASpriteWidth;
    private float leftDifficultyASpriteHeight;

    private float leftDifficultyBSpriteWidth;
    private float leftDifficultyBSpriteHeight;

    private float rightDifficultyASpriteWidth;
    private float rightDifficultyASpriteHeight;

    private float rightDifficultyBSpriteWidth;
    private float rightDifficultyBSpriteHeight;




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


    public const int INSERT_COINS = 0;
    public const int ONE_PLAYER_COINS = 1;
    public const int MAXIMUM_COINS = 99;


    // console initialisation
    private const string GAME_TITLE = "PLAN B";
    private const int TV_MODE = AtariConsoleController.BW_TV;



    void Start()
    {
        // set reference to audio source component
        audioController = AudioController.instance;

        Initialise();
    }


    private void Initialise()
    {
        InitialiseGameModes();

        InitialiseScreenBoundaries();

        InitialiseConsoleSystem();

        //audioController.PlayAudioClip("Music");

        StartDemoMode();
    }


    private void InitialiseGameModes()
    {
        gameCredits = INSERT_COINS;

        UpdateGameCreditsText();

        canPlay = false;

        inPawzMode = false;
        inDemoMode = false;
        inPlayMode = false;
    }


    public void InitialiseDifficultySwitchSettings()
    {
        leftDifficultyASpriteWidth = 0.4f;

        leftDifficultyASpriteHeight = 0.6f;

        leftDifficultyBSpriteWidth = 0.4f;

        leftDifficultyBSpriteHeight = 0.4f;

        rightDifficultyASpriteWidth = 0.4f;

        rightDifficultyASpriteHeight = 0.6f;

        rightDifficultyBSpriteWidth = 0.4f;

        rightDifficultyBSpriteHeight = 0.4f;
    }


    private void InitialiseScreenBoundaries()
    {
        upperBoundary = 4.3f;

        lowerBoundary = -4.3f;

        //leftBoundary = -6.43f;

        //rightBoundary = 6.43f;
    }


    private void InitialiseConsoleSystem()
    {
        atariConsoleController.initialisingConsoleSystem = true;

        atariConsoleController.InitialiseConsole(GAME_TITLE, TV_MODE);
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


    private void SetAtariConsoleMode(int consoleMode)
    {
        atariConsoleController.consoleMode = consoleMode;

        atariConsoleController.SetConsoleMode(consoleMode);
    }


    public void SetTvMode(int tvMode)
    {
        switch (tvMode)
        {
            case AtariConsoleController.BW_TV:

                SetClassicMode(tvMode);

                break;

            case AtariConsoleController.COLOUR_TV:

                SetColourMode(tvMode);

                break;
        }
    }


    private void SetClassicMode(int tvMode)
    {
        SetPlayer1Colour(WHITE, WHITE, WHITE);

        SetPlayer2Colour(WHITE, WHITE, WHITE);

        //SetPlayer3Colour(WHITE, WHITE, WHITE);

        //SetPlayer4Colour(WHITE, WHITE, WHITE);

        SetBallColour(tvMode, PLAYER_ONE);
    }


    private void SetColourMode(int tvMode)
    {
        SetPlayer1Colour(RED, 0, 0);

        SetPlayer2Colour(0, GREEN, 0);

        //SetPlayer3Colour(0, 0, BLUE);

        //SetPlayer4Colour(RED, GREEN, 0);

        SetBallColour(tvMode, PLAYER_ONE);
    }


    private void SetPlayer1Colour(int r, int g, int b)
    {
        // red
        //player1SpriteController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);

        //player1ScoreText.color = new Color(r, g, b);

        //player1Goal.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);

        //player1ScoreCounter1.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player1ScoreCounter2.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player1ScoreCounter3.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player1ScoreCounter4.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
    }


    private void SetPlayer2Colour(int r, int g, int b)
    {
        // green
        //player2SpriteController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);

        //player2ScoreText.color = new Color(r, g, b);

        //player2Goal.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);

        //player2ScoreCounter1.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player2ScoreCounter2.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player2ScoreCounter3.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player2ScoreCounter4.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
    }


    private void SetPlayer3Colour(int r, int g, int b)
    {
        // blue
        //player3SpriteController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);

        //player3Goal.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);

        //player3ScoreCounter1.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player3ScoreCounter2.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player3ScoreCounter3.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player3ScoreCounter4.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
    }


    private void SetPlayer4Colour(int r, int g, int b)
    {
        // yellow
        //player4SpriteController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);

        //player4Goal.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);

        //player4ScoreCounter1.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player4ScoreCounter2.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player4ScoreCounter3.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
        //player4ScoreCounter4.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b);
    }



    public void SetLeftDifficultyA()
    {
        //player1SpriteController.gameObject.transform.localScale = new Vector3(leftDifficultyASpriteWidth, leftDifficultyASpriteHeight, 0);
    }


    public void SetLeftDifficultyB()
    {
        //player1SpriteController.gameObject.transform.localScale = new Vector3(leftDifficultyBSpriteWidth, leftDifficultyBSpriteHeight, 0);
    }


    public void SetRightDifficultyA()
    {
        //player2SpriteController.gameObject.transform.localScale = new Vector3(rightDifficultyASpriteWidth, rightDifficultyASpriteHeight, 0);
    }


    public void SetRightDifficultyB()
    {
        //player2SpriteController.gameObject.transform.localScale = new Vector3(rightDifficultyBSpriteWidth, rightDifficultyBSpriteHeight, 0);
    }


    public void SetPawzMode()
    {
        //SetGamePadControllers();

        //ballSpriteController.FreezeBall();

        SetAtariConsoleMode(AtariConsoleController.CONSOLE_VISIBLE);
    }


    public void SetPlayMode()
    {
        SetAtariConsoleMode(AtariConsoleController.CONSOLE_HIDDEN);

        //SetGamePadControllers();

        //ballSpriteController.ResumeBall();
    }



    public void SetBallColour(int tvMode, int player)
    {
        if (tvMode == AtariConsoleController.COLOUR_TV && !inDemoMode)
        {
            switch (player)
            {
                case PLAYER_ONE:

                    // red
                    //ballSpriteController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(RED, 0, 0);

                    break;

                case PLAYER_TWO:

                    // green
                    //ballSpriteController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(0, GREEN, 0);

                    break;

                case PLAYER_THREE:

                    // blue
                    //ballSpriteController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(0, 0, BLUE);

                    break;

                case PLAYER_FOUR:

                    // yellow
                    //ballSpriteController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(RED, GREEN, 0);

                    break;
            }
        }

        else
        {
            // white
            //ballSpriteController.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(WHITE, WHITE, WHITE);
        }
    }


    // Start demo mode
    public void StartDemoMode()
    {
        gameOverText.gameObject.SetActive(true);

        // start demo mode
        inDemoMode = true;
        inPlayMode = false;

        atariConsoleController.SetPawzModeSwitches();

        // show atari console
        SetAtariConsoleMode(AtariConsoleController.CONSOLE_VISIBLE);

        // check if there are any credits
        if (gameCredits == INSERT_COINS)
        {
            insertCoinsText.gameObject.SetActive(true);
        }

        atariConsoleController.SetGameSelection();

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
        gameCredits -= 1;

        UpdateGameCreditsText();

        if (gameCredits == INSERT_COINS)
        {
            canPlay = false;

            atariConsoleController.gameNumberSelected = AtariConsoleController.NO_GAME_SELECTED;

            atariConsoleController.SetGameSelection();
        }

        gameOverText.gameObject.SetActive(false);

        inPlayMode = true;
        inDemoMode = false;

        atariConsoleController.SetPawzModeSwitches();

        // hide atari console
        SetAtariConsoleMode(AtariConsoleController.CONSOLE_HIDDEN);

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


        // otherwise,
        // reset ball and set colour for player scored
        switch (playerScored)
        {
            case PLAYER_ONE:

                SetBallColour(atariConsoleController.tvMode, PLAYER_ONE);

                break;

            case PLAYER_TWO:

                SetBallColour(atariConsoleController.tvMode, PLAYER_TWO);

                break;
        }

        //ballSpriteController.ResetBall(ballSpriteController.ballSpeed, ballSpriteController.ballSpeed);
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


    public void UpdateGameCreditsText()
    {
        coinsInsertedText.text = gameCredits.ToString("00");
    }


} // end of class
