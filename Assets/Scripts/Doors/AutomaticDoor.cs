
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// created 2020-08-20
//
// modified 2020-08-20
//

public class AutomaticDoor : MonoBehaviour
{
    [SerializeField] private GameObject automaticDoor;

    private DoorInterface doorInterface;



    private void Awake()
    {
        doorInterface = automaticDoor.GetComponent<DoorInterface>();
    }


    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.CompareTag("Player"))
        {
            doorInterface.OpenDoor();
        }
    }


    private void OnTriggerExit2D(Collider2D collidingObject)
    {
        if (collidingObject.CompareTag("Player"))
        {
            doorInterface.CloseDoor();
        }
    }


} // end of class
