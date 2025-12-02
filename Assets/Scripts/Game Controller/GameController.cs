
using System.Collections;
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.23
//

public class GameController : MonoBehaviour
{
    // make game controller script accessible from other scripts
    public static GameController gameController;


    // reference to player
    public GameObject playerOne;

    // reference to first room collider
    public Collider2D roomOneRoomActivator;


    // get a reference to the audio source component
    [HideInInspector] public AudioSource audioPlayer;



    private const int KEY_1 = 13;
    private const int KEY_2 = 3;
    private const int KEY_3 = 2;
    private const int KEY_4 = 10;

    private const int ENERGY = 100;
    private const int AMMO = 100;
    private const int COMPUTERS_TO_DESTROY = 100;

    private const int SINGLE_TILE_POINTS = 1;

    private const int SPANNER_POINTS = 5;
    private const int AMMO_POINTS = 5;
    private const int OIL_POINTS = 5;
    private const int KEY_POINTS = 5;

    private const int COMPUTER_POINTS = 50;

    private const int ROBOT_7_POINTS = 10;
    private const int ROBOT_1_POINTS = 20;
    private const int ROBOT_9_POINTS = 30;
    private const int ROBOT_8_POINTS = 40;

    // player start position
    public const float PLAYER_START_POSITION_X = 255.5f;
    public const float PLAYER_START_POSITION_Y = -53.5f;

    // game camera start position
    public const float GAME_CAMERA_START_POSITION_X = 240f;
    public const float GAME_CAMERA_START_POSITION_Y = -52f;
    public const float GAME_CAMERA_Z = -10f;



    // reference to 'Score integers' assigned to each enemy
    public int score;
    public int highScore;

    public int key1;
    public int key2;
    public int key3;
    public int key4;

    public int energy;

    public int ammo;

    public int computers;

    // current room the player is in
    public int room;


    // are we playing the game
    public bool gamePawzed;

    // is the game over
    public bool gameOver;

    // level completed
    public bool levelComplete;

    // if we are starting the level
    public bool levelStart;

    // if we are entering a room
    public bool hasEnterdRoom;

    public bool canPlay;

    // is the game in play
    public bool inPlayMode;

    public bool inAttractMode;

    public bool inPawzMode;


    public float coolDownTimer = 3f;

    public float enteredRoomTimer;



    private void Awake()
    {
        gameController = this;
    }


    private void Start()
    {
        CabinetStartUp();
    }


    private void Update()
    {
        GameLoop();
    }


    private void CabinetStartUp()
    {
        InitialiseCabinet();

        StartAttractMode();
    }


    private void InitialiseCabinet()
    //private void InitialiseLevelStart()
    {
        canPlay = false; // ?????

        // set game play flags
        gameOver = true;

        ScoreController.scoreController.InitialiseScore();
    }


    public void StartAttractMode()
    {
        // start attract mode
        inAttractMode = true;

        inPlayMode = false;

        // activate the blanking planel
        CameraController.cameraController.blankingPanel.gameObject.SetActive(true);

        // cycle the title screen and high scores
        GameScreenController.gameScreenController.CycleTitleHighScoreScreens();
    }


    private void GameLoop()
    {
        GetKeyboardInput();

        GetPlayerInput();
    }


    private void GetKeyboardInput()
    {
        if (!inAttractMode)
        {
            return;
        }

        // start game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inAttractMode = false;

            GameScreenController.gameScreenController.titleScreen.SetActive(false);

            GameScreenController.gameScreenController.highScoreScreen.SetActive(false);

            StartOnePlayerGame();
        }



        // if the game is in play
        if (inPlayMode)
        {
            // and the game is not already pawzed
            if (!gamePawzed)
            {
                // and the player has pressed the 'O' key
                if (Input.GetKeyDown(KeyCode.O))
                {
                    GameScreenController.gameScreenController.PawzGame();
                }
            }
        }
    }


    private void GetPlayerInput()
    {
        if (!gameOver && !inPawzMode && !inAttractMode)
        {
            PlayerController.playerController.GetKeyboardInput();
        }




        if (Input.GetKeyDown(KeyCode.F))
        {
            score = 1234567;

            DisplayScore(score);
        }



    }


    public void StartOnePlayerGame()
    {
        InitialiseGame();
    }


    private void InitialiseGame()
    {
        // player score
        score = 0;

        ammo = 0;

        energy = 0;

        computers = COMPUTERS_TO_DESTROY;

        key1 = 0;
        key2 = 0;
        key3 = 0;
        key4 = 0;

        // game time left
        // 3 minutes or 180 seconds
        //gameTime = 180f;

        //SetTimeFormat();

        // set the game in play flags and enter room timer
        //inPlayMode = true;

        gameOver = false;

        // deactivate the starting room collider
        roomOneRoomActivator.enabled = false;


        // get the start room position for the game camera
        Vector3 gameCameraStartPosition = new Vector3(GAME_CAMERA_START_POSITION_X, GAME_CAMERA_START_POSITION_Y, GAME_CAMERA_Z);

        // store the position
        CameraController.cameraController.StorePreviousRoomPosition(roomOneRoomActivator.transform);

        // position the camera
        CameraController.cameraController.PositionGameCamera(gameCameraStartPosition);

        // display room name
        CameraController.cameraController.DisplayRoomName(roomOneRoomActivator.transform);

        // deactivate the blanking panel
        CameraController.cameraController.blankingPanel.gameObject.SetActive(false);


        // activate the player
        playerOne.SetActive(true);

        // initialise the player
        PlayerController.playerController.InitialisePlayer();
    }













    private void PlayerEnteredRoom()
    {
        // countdown timer
        //enteredRoomTimer -= Time.deltaTime;

        // if the time left is less than or equal to zero 
        //if (enteredRoomTimer <= 0)
        //{
            // set timer to zero
            //enteredRoomTimer = 0;

            // indicate we are no longer waiting for the player
            hasEnterdRoom = false;

            // spawn the enemy
            //CameraController.cameraController.SpawnEnemy();
        //}
    }


    public void OpenDoor(int doorToOpen)
    {
        // open door to next room
        //doors[doorToOpen].SetActive(false);
    }


    public void ResumeGame()
    {
        // un-pawz the game
        gamePawzed = false;

        // deactivate the background
        //backgroundPanel.SetActive(false);

        // close the pawz screen
        //pawzScreen.SetActive(false);

        // and un-freeze game play
        Time.timeScale = 1f;
    }


    public void RestartGame()
    {
        // close the game over screen
        //gameOverScreen.SetActive(false);

        // and un-freeze game play
        Time.timeScale = 1f;

        // restart the game
        //SceneManager.LoadScene(0);
    }



    public void DisplayScore(int score)
    {
        ScoreController.scoreController.UpdateScoreDisplay(score);
    }


    public void DisplayGameTime()
    {
        // countdown the time
        //gameTime -= Time.deltaTime;

        SetTimeFormat();

        // if the player is out of time
        //if (gameTime < 0)
        //{
            //gameTime = 0f;

            //GameOver();
        //}
    }


    private void SetTimeFormat()
    {
        // convert time to minutes and seconds
        //int minutes = ((int)gameTime / 60);

        //int seconds = ((int)gameTime % 60);

        // format and display the remaining time
        //gameTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


} // end of class
