
using System.Collections;
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.03
//

public class RoomNameController : MonoBehaviour
{
    public static RoomNameController roomNameController;


    public Transform[] roomName;


    private const int NUMBER_OF_ROOMS = 80;




    private void Awake()
    {
        roomNameController = this;
    }


} // end of class
