
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.17
//

public class PickupObjectsController : MonoBehaviour
{
    public static PickupObjectsController pickupObjectsController;


    public Transform[] pickupObjects;


    private const int NUMBER_OF_ROOMS = 80;




    private void Awake()
    {
        pickupObjectsController = this;
    }


    public void ActivatePickupObjects(int arrayPosition)
    {
        for (int pickupObject = 0; pickupObject < pickupObjects[arrayPosition].transform.childCount; pickupObject++)
        {
            pickupObjects[arrayPosition].transform.GetChild(pickupObject).gameObject.SetActive(true);
        }
    }


} // end of class
