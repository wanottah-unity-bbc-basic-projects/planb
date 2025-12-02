
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
// modified 2020-08-09
//

public class PlayerFuelController : MonoBehaviour
{
    //public static PlayerFuelController _playerFuelControllerInstance;



    //// maximum player fuel
    //private int playerMaximumFuel;

    //// player's current fuel
    //[SerializeField] public float playerCurrentFuel;

    //// reference to level controller
    //[SerializeField]
    ////private LevelController levelController;



    //private void Awake()
    //{
    //    _playerFuelControllerInstance = this;
    //}


    //// initialise fuel
    //private void Start()
    //{
    //    Initialise();
    //}



    //private void Initialise()
    //{
    //    playerMaximumFuel = 1000;

    //    playerCurrentFuel = playerMaximumFuel;

    //    HudController._hudControllerInstance.fuelSlider.maxValue = playerMaximumFuel;

    //    UpdateFuelValueText();
    //}


    //// use fuel
    //public void FuelConsumption(float fuelUsed)
    //{
    //    playerCurrentFuel -= fuelUsed / 10;

    //    UpdateFuelValueText();
    //}


    //public void Refuel(int fuel)
    //{
    //    playerCurrentFuel += fuel;

    //    if (playerCurrentFuel > playerMaximumFuel)
    //    {
    //        playerCurrentFuel = playerMaximumFuel;
    //    }

    //    UpdateFuelValueText();
    //}


    //private void UpdateFuelValueText()
    //{
    //    float fuelPercentage = (playerCurrentFuel / playerMaximumFuel) * 100;

    //    HudController._hudControllerInstance.fuelValueText.text = ((int)fuelPercentage).ToString() + "%";

    //    HudController._hudControllerInstance.fuelSlider.value = playerCurrentFuel;


    //    // check if player is dead
    //    if (playerCurrentFuel <= 0)
    //    {
    //        // disable player controller
    //        //PlayerController._playerControllerInstance.gameObject.SetActive(false);

    //        // Display Game Over UI
    //        //gameOverUI.gameObject.SetActive(true);
    //    }
    //}


} // end of class
