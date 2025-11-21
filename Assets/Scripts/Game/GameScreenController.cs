
using System.Collections;
using UnityEditor.Search;
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.02
//

public class GameScreenController : MonoBehaviour
{
    // make screen controller script accessible from other scripts
    public static GameScreenController gameScreenController;


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



    private void Awake()
    {
        gameScreenController = this;
    }


    public void CycleTitleHighScoreScreens()
    {
        StartCoroutine(CycleScreens());
    }


    public IEnumerator CycleScreens()
    {
        if (!GameController.gameController.inAttractMode)
        {
            yield break;
        }

        titleScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(6f);

        if (!GameController.gameController.inAttractMode)
        {
            yield break;
        }

        titleScreen.gameObject.SetActive(false);

        highScoreScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(6f);

        if (!GameController.gameController.inAttractMode)
        {
            yield break;
        }

        highScoreScreen.gameObject.SetActive(false);

        StartCoroutine(CycleScreens());
    }


    public void PawzGame()
    {
        // pawz the game
        GameController.gameController.gamePawzed = true;

        // activate the background
        //backgroundPanel.SetActive(true);

        // load the pawz screen
        pawzScreen.SetActive(true);

        // and freeze game play
        Time.timeScale = 0f;
    }


    public void MissionFailed()
    {
        // game over
        GameController.gameController.gameOver = true;

        //levelComplete = true;

        //inPlayMode = false;

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
        GameController.gameController.gameOver = true;

        //levelComplete = true;

        //inPlayMode = false;

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
        GameController.gameController.gameOver = true;

        //inPlayMode = false;

        // activate the background
        //backgroundPanel.SetActive(true);

        // open the game over screen
        gameOverScreen.SetActive(true);

        // and freeze game play
        Time.timeScale = 0f;
    }


    // if the quit button is pressed
    public void QuitGame()
    {
        // quit the game
        quitGameScreen.SetActive(true);

        Application.Quit();
    }


} // end of class
