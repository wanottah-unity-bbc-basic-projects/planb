
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


    public void ActivateDestructableObjects(int arrayPosition)
    {
        for (int destructableObject = 0; destructableObject < destuctableObjects[arrayPosition].transform.childCount; destructableObject++)
        {
            destuctableObjects[arrayPosition].transform.GetChild(destructableObject).gameObject.SetActive(true);
        }
    }


} // end of class
