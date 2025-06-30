/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// modified 2020-08-19
//

public class KeyDoor : MonoBehaviour 
{

    [SerializeField] private SecurityKeyType.SecurityKeys securityKey;

    private DoorAnims doorAnimations;



    private void Awake() 
    {
        doorAnimations = GetComponent<DoorAnims>();
    }


    public SecurityKeyType.SecurityKeys GetSecurityKey() 
    {
        return securityKey;
    }


    public void OpenDoor() 
    {
        doorAnimations.OpenDoor();
    }


    public void PlayOpenFailAnim() 
    {
        doorAnimations.PlayOpenFailAnim();
    }


    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.CompareTag("Player"))
        {
            KeyDoor keyDoor = GetComponent<KeyDoor>();

            if (keyDoor != null)
            {
                if (KeyController._keyControllerInstance.ContainsKey(GetSecurityKey()))
                {
                    // currently holding Key to open this door
                    if (gameObject.CompareTag("Security Key 01")) { KeyController._keyControllerInstance.UseKey("Security Key 01", GetSecurityKey()); }

                    if (gameObject.CompareTag("Security Key 02")) { KeyController._keyControllerInstance.UseKey("Security Key 02", GetSecurityKey()); }

                    if (gameObject.CompareTag("Security Key 03")) { KeyController._keyControllerInstance.UseKey("Security Key 03", GetSecurityKey()); }

                    if (gameObject.CompareTag("Security Key 04")) { KeyController._keyControllerInstance.UseKey("Security Key 04", GetSecurityKey()); }

                    if (gameObject.CompareTag("Security Key 05")) { KeyController._keyControllerInstance.UseKey("Security Key 05", GetSecurityKey()); }

                    if (gameObject.CompareTag("Security Key 06")) { KeyController._keyControllerInstance.UseKey("Security Key 06", GetSecurityKey()); }

                    if (gameObject.CompareTag("Security Key 07")) { KeyController._keyControllerInstance.UseKey("Security Key 07", GetSecurityKey()); }

                    if (gameObject.CompareTag("Security Key 08")) { KeyController._keyControllerInstance.UseKey("Security Key 08", GetSecurityKey()); }

                    //keyDoor.OpenDoor();
                    Debug.Log("opening door");
                }

                else
                {
                    //keyDoor.PlayOpenFailAnim();
                    Debug.Log("access denied");
                }
            }
        }
    }


} // end of class
