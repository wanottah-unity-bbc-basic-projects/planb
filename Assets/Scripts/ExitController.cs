
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//
// created 2020-08-10
//
// modified 2020-08-15
//

public class ExitController : MonoBehaviour
{
    public Transform destinationSector;

    public PlayerSpawnController destinationSpawnPoint;



    private void MoveCameraToSector(Transform destinationSector)
    {
        //CameraController.cameraController.NewCameraPosition(
            //new Vector3(destinationSector.position.x, destinationSector.position.y, 0f));
    }



    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.CompareTag("Player"))
        {
            MoveCameraToSector(destinationSector);

            destinationSpawnPoint.MovePlayerToSpawnPoint();
        }
    }


} // end of class
