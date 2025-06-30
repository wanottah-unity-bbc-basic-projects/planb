
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Plan B Reloaded v0.0.0
/// Port of 'Plan B' for the BBC Model B by Andrew Foord - Copyright 1987
/// AmmoController.cs
/// Adapted from 'Learn to Code By Making a 2D Platformer in Unity'
/// by James Doyle
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 26/03/2019
/// </summary>

//
// modified 2020-08-10
//

public class PlayerWeaponController : MonoBehaviour
{
    public static PlayerWeaponController _playerWeaponControllerInstance;



    // maximum player ammo
    private int playerMaximumAmmo;

    // current player ammo
    public int playerCurrentAmmo;

    // maximum weapon temparature
    public int maximumWeaponStatus;

    // current weapon temparature
    public float currentWeaponStatus;



    private void Awake()
    {
        _playerWeaponControllerInstance = this;
    }


    // initialise ammo
    private void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        playerMaximumAmmo = 200;

        playerCurrentAmmo = playerMaximumAmmo;

        maximumWeaponStatus = 100;

        currentWeaponStatus = maximumWeaponStatus;

        HudController._hudControllerInstance.ammoSlider.maxValue = playerMaximumAmmo;

        HudController._hudControllerInstance.weaponSlider.maxValue = maximumWeaponStatus;

        UpdateWeaponTemparatureValueText();

        UpdateAmmoValueText();
    }


    // use ammo
    public void AmmoRoundsFired()
    {
        playerCurrentAmmo--;

        UpdateAmmoValueText();
    }


    public void WeaponOverheat(float overheat)
    {
        currentWeaponStatus -= overheat; // / 10;

        if (currentWeaponStatus < 0)
        {
            currentWeaponStatus = 0;
        }

        UpdateWeaponTemparatureValueText();
    }


    public void WeaponCooldown(float cooldown)
    {
        currentWeaponStatus += cooldown / 10;

        if (currentWeaponStatus > maximumWeaponStatus)
        {
            currentWeaponStatus = maximumWeaponStatus;
        }

        UpdateWeaponTemparatureValueText();
    }


    public void ReloadAmmo(int ammo)
    {
        playerCurrentAmmo += ammo;

        if (playerCurrentAmmo > playerMaximumAmmo)
        {
            playerCurrentAmmo = playerMaximumAmmo;
        }

        UpdateAmmoValueText();
    }


    private void UpdateWeaponTemparatureValueText()
    {
        float overheatPercentage = (currentWeaponStatus / maximumWeaponStatus) * 100;

        HudController._hudControllerInstance.weaponTemparatureValueText.text = ((int)overheatPercentage).ToString() + "%";

        HudController._hudControllerInstance.weaponSlider.value = currentWeaponStatus;
    }


    private void UpdateAmmoValueText()
    {
        HudController._hudControllerInstance.ammoValueText.text = playerCurrentAmmo.ToString();

        HudController._hudControllerInstance.ammoSlider.value = playerCurrentAmmo;
    }



} // end of class
