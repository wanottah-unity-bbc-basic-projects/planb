
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Plan B [Bug Byte, 1987] v2023.09.14
//
// v2025.10.15
//

public class CameraController : MonoBehaviour
{
    public static CameraController _cameraControllerInstance;


    public Vector3 cameraPosition;



    private void Awake()
    {
        _cameraControllerInstance = this;
    }


    void Update()
    {
        MoveCamera();
    }


    private void MoveCamera()
    {
        if (cameraPosition != null)
        {
            transform.position = new Vector3(cameraPosition.x, cameraPosition.y, transform.position.z);
        }
    }


    public void NewCameraPosition(Vector3 newCameraPosition)
    {
        cameraPosition = 
            new Vector3(newCameraPosition.x, newCameraPosition.y + 2, transform.position.z);
    }


} // end of class
