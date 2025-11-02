
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.02
//

public class RoomController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        // if the player enters a new room
        if (collidingObject.CompareTag("Player"))
        {
            // move the camera to the new room
            CameraController.cameraController.EnterNewRoom(transform);

            // display the room name
            CameraController.cameraController.DisplayRoomName(transform);
        }
    }


} // end of class
