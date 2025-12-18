
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.18
//

public class AmmoController : MonoBehaviour
{
    public static AmmoController ammoController;



    // player's maximum ammo
    private int playerMaximumAmmo;

    // player's current ammo
    private float playerCurrentAmmo;



    private void Awake()
    {
        ammoController = this;
    }


    private void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        playerMaximumAmmo = 1; // 100;

        playerCurrentAmmo = playerMaximumAmmo;

        UIController.uiController.ammoSlider.maxValue = playerMaximumAmmo;

        UpdateAmmoSlider();
    }


    private void UpdateAmmoSlider()
    {
        float ammoPercentage = (playerCurrentAmmo / playerMaximumAmmo) * 100;

        UIController.uiController.ammoText.text = ((int)ammoPercentage).ToString() + "%";

        UIController.uiController.ammoSlider.value = playerCurrentAmmo;
    }


} // end of class
