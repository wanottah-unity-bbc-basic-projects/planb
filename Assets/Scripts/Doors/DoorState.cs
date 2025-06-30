
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// created 2020-08-20
//
// modified 2020-08-20
//

public class DoorState : MonoBehaviour, DoorInterface
{
    private bool doorIsOpen = false;



    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }


    public void CloseDoor()
    {
        gameObject.SetActive(true);
    }


    public void ToggleDoor()
    {
        doorIsOpen = !doorIsOpen;

        if (doorIsOpen)
        {
            OpenDoor();
        }

        else
        {
            CloseDoor();
        }
    }



} // end of class
