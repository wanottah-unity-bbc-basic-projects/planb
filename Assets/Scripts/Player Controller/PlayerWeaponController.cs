
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.23
//

public class PlayerWeaponController : MonoBehaviour
{
    public static PlayerWeaponController playerWeaponController;



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
        playerWeaponController = this;
    }


    private void Start()
    {
        InitialisePlayerAmmo();
    }


    public void InitialisePlayerAmmo()
    {
        playerMaximumAmmo = 200;

        playerCurrentAmmo = playerMaximumAmmo;

        Debug.Log("Player Ammo: " + playerCurrentAmmo);

        //maximumWeaponStatus = 100;

        //currentWeaponStatus = maximumWeaponStatus;

        //HudController._hudControllerInstance.ammoSlider.maxValue = playerMaximumAmmo;

        //HudController._hudControllerInstance.weaponSlider.maxValue = maximumWeaponStatus;

        //UpdateAmmoValueText();
    }


    // use ammo
    public void AmmoRoundsFired()
    {
        playerCurrentAmmo--;

        //UpdateAmmoValueText();
    }


    public void WeaponCooldown(float cooldown)
    {
        currentWeaponStatus += cooldown / 10;

        if (currentWeaponStatus > maximumWeaponStatus)
        {
            currentWeaponStatus = maximumWeaponStatus;
        }
    }


    public void ReloadAmmo(int ammo)
    {
        playerCurrentAmmo += ammo;

        if (playerCurrentAmmo > playerMaximumAmmo)
        {
            playerCurrentAmmo = playerMaximumAmmo;
        }

        //UpdateAmmoValueText();
    }


    private void UpdateAmmoValueText()
    {
        //HudController._hudControllerInstance.ammoValueText.text = playerCurrentAmmo.ToString();

        //HudController._hudControllerInstance.ammoSlider.value = playerCurrentAmmo;
    }


} // end of class
