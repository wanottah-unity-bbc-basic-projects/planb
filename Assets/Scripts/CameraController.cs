
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.02
//

public class CameraController : MonoBehaviour
{
    public static CameraController cameraController;


    // speed at which the camera moves between rooms
    public float cameraMovementSpeed;

    // the room where the camera will move to
    public Transform targetRoom;

    public Transform blankingPanel;



    private void Awake()
    {
        cameraController = this;
    }


    void Update()
    {
        MoveCamera();
    }


    // move camera to new room when player enters it
    private void MoveCamera()
    {
        // if we have moved into a new room
        if (targetRoom != null)
        {
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
        GameController.gameController.roomActivator.enabled = true;
    }


    public void DisplayRoomName(Transform room)
    {
        Vector2 roomPosition = room.position;

        float arrayPosition = (Mathf.Abs(roomPosition.y) / 26) * 10 + (Mathf.Abs(roomPosition.x) / 40);

        Debug.Log(Mathf.Abs(roomPosition.x) + ", " + Mathf.Abs(roomPosition.y) + ": " + arrayPosition);
    }


    IEnumerator ScreenBlank()
    {
        blankingPanel.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        targetRoom = null;

        blankingPanel.gameObject.SetActive(false);
    }


} // end of class
