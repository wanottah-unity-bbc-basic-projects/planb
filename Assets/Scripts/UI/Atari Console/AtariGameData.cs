
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// modified 2020-08-04
//

public class AtariGameData : MonoBehaviour
{
    // reference to atari game data controller script
    private AtariGameDataController atariGameDataController;


    [HideInInspector] public int NUMBER_OF_GAMES;

    [HideInInspector] public int[] gameNumber;


    private const int ONE_PLAYER = 1;
    private const int TWO_PLAYERS = 2;
    private const int THREE_PLAYERS = 3;
    private const int FOUR_PLAYERS = 4;
    private const int DOUBLES = 2;


    // games
    public const string PLANB = "PLAN B";
    public const string WARLORDS   = "WARLORDS";
    public const string BREAKOUT   = "BREAKOUT";
    public const string QUADRAPONG = "QUADRA PONG";
    public const string PONG       = "PONG";


    private void Start()
    {
        atariGameDataController = GetComponent<AtariGameDataController>();
    }


    public void InitialiseGame(int numberOfGames)
    {
        gameNumber = new int[numberOfGames];
    }


    public void InitialiseGameOptions(int gameIndex, int numberOfPlayers)
    {
        gameNumber[gameIndex] = numberOfPlayers;
    }


    // *** GAMES *** \\

    public void PlanB()
    {
        NUMBER_OF_GAMES = 1;

        InitialiseGame(NUMBER_OF_GAMES);

        // game 1
        InitialiseGameOptions(0, ONE_PLAYER);
    }


    public void Warlords()
    {
        NUMBER_OF_GAMES = 5;

        InitialiseGame(NUMBER_OF_GAMES);

        // game 1
        InitialiseGameOptions(0, ONE_PLAYER);

        // game 2
        InitialiseGameOptions(1, TWO_PLAYERS);

        // game 3
        InitialiseGameOptions(2, THREE_PLAYERS);

        // game 4
        InitialiseGameOptions(3, FOUR_PLAYERS);

        // game 5
        InitialiseGameOptions(4, DOUBLES);
    }


    public void Breakout()
    {
        NUMBER_OF_GAMES = 4;

        InitialiseGame(NUMBER_OF_GAMES);

        // game 1
        InitialiseGameOptions(0, ONE_PLAYER);

        // game 2
        InitialiseGameOptions(1, TWO_PLAYERS);
    }


    public void QuadraPong()
    {
        NUMBER_OF_GAMES = 4;

        InitialiseGame(NUMBER_OF_GAMES);

        // game 1
        InitialiseGameOptions(0, ONE_PLAYER);

        // game 2
        InitialiseGameOptions(1, TWO_PLAYERS);

        // game 3
        InitialiseGameOptions(2, THREE_PLAYERS);

        // game 4
        InitialiseGameOptions(3, FOUR_PLAYERS);
    }


    public void Pong()
    {
        NUMBER_OF_GAMES = 2;

        InitialiseGame(NUMBER_OF_GAMES);

        // game 1
        InitialiseGameOptions(0, ONE_PLAYER);

        // game 2
        InitialiseGameOptions(1, TWO_PLAYERS);
    }


} // end of class
