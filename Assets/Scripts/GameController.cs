
using System.Collections;
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.01
//

public class GameController : MonoBehaviour
{
    // make game controller script accessible from other scripts
    public static GameController gameController;


    // reference to title screen
    public GameObject titleScreen;

    // reference to high score screen
    public GameObject highScoreScreen;

    // reference to the pawz screen
    public GameObject pawzScreen;

    // reference to the game over screen
    public GameObject gameOverScreen;

    // reference to the game over screen
    public GameObject missionFailedScreen;

    // reference to the victory screen
    public GameObject victoryScreen;

    // reference to quit game background
    public GameObject quitGameScreen;

    // reference to player
    public GameObject playerOne;

    // reference to first room collider
    public Collider2D roomActivator;


    // get a reference to the audio source component
    [HideInInspector] public AudioSource audioPlayer;


    private const int KEY_1 = 13;
    private const int KEY_2 = 3;
    private const int KEY_3 = 2;
    private const int KEY_4 = 10;

    private const int ENERGY = 100;
    private const int AMMO = 100;
    private const int COMPUTERS = 100;

    private const int SINGLE_TILE_POINTS = 1;

    private const int SPANNER_POINTS = 5;
    private const int AMMO_POINTS = 5;
    private const int OIL_POINTS = 5;
    private const int KEY_POINTS = 5;

    private const int COMPUTER_G_POINTS = 50;

    private const int ROBOT_7_POINTS = 10;
    private const int ROBOT_1_POINTS = 20;
    private const int ROBOT_9_POINTS = 30;
    private const int ROBOT_8_POINTS = 40;


    // rooms
    public Transform[] roomArray;


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
    }


    public void StartAttractMode()
    {
        // start attract mode
        inAttractMode = true;

        inPlayMode = false;

        // activate the blanking planel
        CameraController.cameraController.blankingPanel.gameObject.SetActive(true);

        // cycle the title screen and high scores
        StartCoroutine(CycleText());
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

            //StopCoroutine(CycleText());

            //StartCoroutine(StartDelay());

            titleScreen.SetActive(false);

            highScoreScreen.SetActive(false);

            StartOnePlayerGame();
        }



        // if the game is in play
        if (inPlayMode)
        {
            // and the game is not already pawzed
            if (!gamePawzed)
            {
                // and the player has pressed the escape key
                if (Input.GetKeyDown(KeyCode.P))
                {
                    PawzGame();
                }
            }
        }
    }


    private void GetPlayerInput()
    {
        if (!gameOver && !inPawzMode && !inAttractMode)
        {
            PlayerController.playerController.GetPlayerInput();
        }
    }


    IEnumerator CycleText()
    {
        if (!inAttractMode)
        {
            yield break;
        }

        titleScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(6f);

        if (!inAttractMode)
        {
            yield break;
        }

        titleScreen.gameObject.SetActive(false);

        highScoreScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(6f);

        if (!inAttractMode)
        {
            yield break;
        }

        highScoreScreen.gameObject.SetActive(false);

        StartCoroutine(CycleText());
    }


    public void StartOnePlayerGame()
    {
        InitialiseGame();
    }


    private void InitialiseGame()
    {
        // player score
        score = 0;

        // player lives
        //lives = 3;

        // player health
        //playerHealth = 100;


        // game time left
        // 3 minutes or 180 seconds
        //gameTime = 180f;

        //SetTimeFormat();

        // set the game in play flags and enter room timer
        inPlayMode = true;

        gameOver = false;

        //inAttractMode = false;

        //levelStart = false;

        //levelComplete = false;

        //enteredRoomTimer = coolDownTimer;

        //hasEnterdRoom = true;

        // deactivate the starting room collider
        roomActivator.enabled = false;

        // deactivate the blanking panel
        CameraController.cameraController.blankingPanel.gameObject.SetActive(false);

        playerOne.SetActive(true);

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


    private void PawzGame()
    {
        // pawz the game
        gamePawzed = true;

        // activate the background
        //backgroundPanel.SetActive(true);

        // load the pawz screen
        pawzScreen.SetActive(true);

        // and freeze game play
        Time.timeScale = 0f;
    }


    public void ResumeGame()
    {
        // un-pawz the game
        gamePawzed = false;

        // deactivate the background
        //backgroundPanel.SetActive(false);

        // close the pawz screen
        pawzScreen.SetActive(false);

        // and un-freeze game play
        Time.timeScale = 1f;
    }


    public void RestartGame()
    {
        // close the game over screen
        gameOverScreen.SetActive(false);

        // and un-freeze game play
        Time.timeScale = 1f;

        // restart the game
        //SceneManager.LoadScene(0);
    }


    public void TitleScreen()
    {
        // close the victory screen
        //victoryScreen.SetActive(false);

        // load the title screen
        titleScreen.SetActive(true);

        // play title music
        //AudioController.audioControllerScript.PlayTitleMusic();
    }


    // if the play button is pressed
    public void PlayButton()
    {
        // hide the background panel
        //backgroundPanel.SetActive(false);

        // close the main menu
        titleScreen.SetActive(false);

        // close the game over screen
        //gameOverScreen.SetActive(false);

        // display the player ui panel
        //playerUiPanel.SetActive(true);

        // play title music
        //AudioController.audioControllerScript.PlayLevelMusic();

        //Initialise();
    }



    public void MissionFailed()
    {
        // game over
        gameOver = true;

        levelComplete = true;

        inPlayMode = false;

        // activate the background
        //backgroundPanel.SetActive(true);

        // load the victory screen
        victoryScreen.SetActive(true);

        // and freeze game play
        Time.timeScale = 0f;
    }


    public void Victory()
    {
        // game over
        gameOver = true;

        levelComplete = true;

        inPlayMode = false;

        // activate the background
        //backgroundPanel.SetActive(true);

        // load the victory screen
        victoryScreen.SetActive(true);

        // and freeze game play
        Time.timeScale = 0f;
    }


    public void GameOver()
    {
        // game over
        gameOver = true;

        inPlayMode = false;

        // activate the background
        //backgroundPanel.SetActive(true);

        // open the game over screen
        gameOverScreen.SetActive(true);

        // and freeze game play
        Time.timeScale = 0f;
    }


    public void DisplayPlayerScore()
    {
        //scoreText.text = score.ToString("000000");
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


    // if the quit button is pressed
    public void QuitGame()
    {
        // quit the game
        quitGameScreen.SetActive(true);

        Application.Quit();
    }


} // end of class
