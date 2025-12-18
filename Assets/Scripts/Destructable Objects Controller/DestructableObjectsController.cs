
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.17
//

public class DestructableObjectsController : MonoBehaviour
{
    public static DestructableObjectsController destructableObjectsController;


    public Transform[] destructableObjects;


    private const int NUMBER_OF_ROOMS = 80;




    private void Awake()
    {
        destructableObjectsController = this;
    }


    public void ActivateDestructableObjects(int arrayPosition)
    {
        for (int destructableObject = 0; destructableObject < destructableObjects[arrayPosition].transform.childCount; destructableObject++)
        {
            destructableObjects[arrayPosition].transform.GetChild(destructableObject).gameObject.SetActive(true);
        }
    }


} // end of class
