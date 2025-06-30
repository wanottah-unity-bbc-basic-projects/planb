using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// modified 2020-08-18
//

public class DoorAnims : MonoBehaviour 
{

    private Animator doorAnimator;



    private void Awake() 
    {
        doorAnimator = GetComponent<Animator>();
    }


    public void OpenDoor() 
    {
        doorAnimator.SetBool("Open", true);
    }


    public void CloseDoor() 
    {
        doorAnimator.SetBool("Open", false);
    }


    public void PlayOpenFailAnim() 
    {
        doorAnimator.SetTrigger("OpenFail");
    }


} // end of class
