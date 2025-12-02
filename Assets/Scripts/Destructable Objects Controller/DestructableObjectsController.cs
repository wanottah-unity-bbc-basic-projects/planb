
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.22
//

public class DestructableObjectsController : MonoBehaviour
{
    public static DestructableObjectsController destructableObjectsController;


    public Transform[] destuctableObjects;


    private const int NUMBER_OF_ROOMS = 80;




    private void Awake()
    {
        destructableObjectsController = this;
    }


} // end of class
