
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// modified 2020-08-04
//

public class AtariGameDataController : MonoBehaviour
{
    // reference to atari game data script
    private AtariGameData atariGameData;


    private void Awake()
    {
        atariGameData = GetComponent<AtariGameData>();
    }


    public void SelectGame(string GAME_TITLE)
    {
        switch (GAME_TITLE)
        {
            case AtariGameData.PLANB:

                atariGameData.PlanB();

                break;

            case AtariGameData.WARLORDS:

                atariGameData.Warlords();

                break;

            case AtariGameData.BREAKOUT:

                atariGameData.Breakout();

                break;

            case AtariGameData.QUADRAPONG:

                atariGameData.QuadraPong();

                break;

            case AtariGameData.PONG:

                atariGameData.Pong();

                break;
        }
    }


} // end of class
