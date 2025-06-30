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
// modified 2020-08-18
//

public class SecurityKeyType : MonoBehaviour 
{
    [SerializeField] private SecurityKeys securityKey;



    public enum SecurityKeys 
    {
        BlackSecurityKey01,
        OrangeSecurityKey02,
        CyanSecurityKey03,
        PurpleSecurityKey04,
        YellowSecurityKey05,
        BlueSecurityKey06,
        GreenSecurityKey07,
        RedSecurityKey08,
        SecurityKey09
    }


    public SecurityKeys GetSecurityKey() 
    {
        return securityKey;
    }


} // end of class
