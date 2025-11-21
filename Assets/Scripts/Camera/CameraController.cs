
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.04
//

public class CameraController : MonoBehaviour
{
    public static CameraController cameraController;


    // the room where the camera will move to
    public Transform targetRoom;

    // the name of the room being entered
    private Transform newRoomName;

    // the name of the room last entered
    private Transform previousRoomName;

    
    public Transform blankingPanel;


    // room size
    private const int roomWidth = 40;
    private const int roomHeight = 26;

    private const int arrayModifier = 10;


    // speed at which the camera moves between rooms
    public float cameraMovementSpeed;



    private void Awake()
    {
        cameraController = this;
    }


    void Update()
    {
        MoveGameCamera();
    }


    public void PositionGameCamera(Vector3 gameCameraPosition)
    {
        transform.position = gameCameraPosition;
    }


    public void StorePreviousRoomPosition(Transform previousRoom)
    {
        previousRoomName = previousRoom;
    }


    // move camera to new room when player enters it
    private void MoveGameCamera()
    {
        // if we have moved into a new room
        if (targetRoom != null)
        {
            StorePreviousRoomPosition(newRoomName);

            StartCoroutine(ScreenBlank());

            // then move camera to new room
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetRoom.position.x, targetRoom.position.y, transform.position.z), cameraMovementSpeed * Time.deltaTime);
            transform.position = new Vector3(targetRoom.position.x, targetRoom.position.y, transform.position.z);
        }
    }


    public void EnterNewRoom(Transform newRoom)
    {
        // get the transform position of the new room entered by the player
        targetRoom = newRoom;

        // activate the starting room collider
        GameController.gameController.roomOneRoomActivator.enabled = true;

        HidePreviousRoomName();
    }


    public void DisplayRoomName(Transform newRoom)
    {
        // get the new room position
        newRoomName = newRoom;

        // calculate the array position of the room name
        float arrayPosition = (Mathf.Abs(newRoomName.position.y) / roomHeight) * arrayModifier + (Mathf.Abs(newRoomName.position.x) / roomWidth);

        //Debug.Log(Mathf.Abs(newRoomName.position.x) + ", " + Mathf.Abs(newRoomName.position.y) + ": " + arrayPosition);

        // show the room name
        RoomNameController.roomNameController.roomName[(int)arrayPosition].gameObject.SetActive(true);
    }


    private void HidePreviousRoomName()
    {
        // calculate the array position of the previous room name
        float arrayPosition = (Mathf.Abs(previousRoomName.position.y) / roomHeight) * arrayModifier + (Mathf.Abs(previousRoomName.position.x) / roomWidth);
        
        // hide the room name
        RoomNameController.roomNameController.roomName[(int)arrayPosition].gameObject.SetActive(false);
    }


    IEnumerator ScreenBlank()
    {
        blankingPanel.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        targetRoom = null;

        blankingPanel.gameObject.SetActive(false);
    }


} // end of class
