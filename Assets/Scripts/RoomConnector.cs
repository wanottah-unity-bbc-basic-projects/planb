
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Plan B Reloaded v0.0.0
/// Port of 'Plan B' for the BBC Model B by Andrew Foord - Copyright 1987
/// RoomExit.cs
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 08/04/2019
/// </summary>

//
// modified 2020-08-15
//

public class RoomConnector : MonoBehaviour
{
    // reference to door controller script
    //[SerializeField] private DoorController doorController;


    // reference to player controller script
    //private PlayerController playerController;


    // number of room
    public string roomNumber;

    // description of room to load
    public string roomDescription;

    // name of room to load
    public string roomName;


    // name of spawn starting position
    //public string spawnStartPosition;


    // name of exit door
    private string doorName;

    // exit door sub type
    private string doorID;


    // player in room exit zone
    private bool inRoomExitZone;



    // find the player controller script
    private void Awake()
    {
        //playerController = FindObjectOfType<PlayerController>();
    }

    
    // check for keyboard input
    private void FixedUpdate()
    {
        CheckKeyboardInput();
    }


    // see if player is trying to open a door
    private void CheckKeyboardInput()
    {
        // if player is pressing the 'Return' key
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // and player is in an exit zone
            if (inRoomExitZone)
            {
                // check the exit door ID
                //CheckDoorType();
            }
        }
    }


} // end of class
