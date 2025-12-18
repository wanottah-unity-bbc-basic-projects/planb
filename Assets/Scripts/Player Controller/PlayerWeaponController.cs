
using UnityEngine;
using UnityEngine.InputSystem;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.15
//

public class PlayerWeaponController : MonoBehaviour
{
    // reference to player's weapon launcher
    public Transform weaponLauncher;

    public GameObject playerBullet;


    // maximum player ammo
    //private int playerMaximumAmmo;

    // current player ammo
    public int playerCurrentAmmo;

    // shoot delay
    private float fireRate = 0.25f;
    private float shootDelay;


    // maximum weapon temparature
    //public int maximumWeaponStatus;

    // current weapon temparature
    //public float currentWeaponStatus;




    private void Start()
    {
        //InitialisePlayerAmmo();
    }


    private void Update()
    {
        Shoot();
    }


    public void InitialisePlayerAmmo()
    {
        //playerMaximumAmmo = 200;

        //playerCurrentAmmo = playerMaximumAmmo;


        //fireRate = 0.25f;


        //Debug.Log("Player Ammo: " + playerCurrentAmmo);

        //maximumWeaponStatus = 100;

        //currentWeaponStatus = maximumWeaponStatus;

        //HudController._hudControllerInstance.ammoSlider.maxValue = playerMaximumAmmo;

        //HudController._hudControllerInstance.weaponSlider.maxValue = maximumWeaponStatus;

        //UpdateAmmoValueText();
    }


    // use ammo
    public void AmmoRoundsFired()
    {
        //playerCurrentAmmo--;

        //UpdateAmmoValueText();
    }


    public void WeaponCooldown(float cooldown)
    {
        //currentWeaponStatus += cooldown / 10;

        //if (currentWeaponStatus > maximumWeaponStatus)
        //{
        //    currentWeaponStatus = maximumWeaponStatus;
        //}
    }


    public void ReloadAmmo(int ammo)
    {
        //playerCurrentAmmo += ammo;

        //if (playerCurrentAmmo > playerMaximumAmmo)
        //{
        //    playerCurrentAmmo = playerMaximumAmmo;
        //}

        //UpdateAmmoValueText();
    }


    private void UpdateAmmoValueText()
    {
        //HudController._hudControllerInstance.ammoValueText.text = playerCurrentAmmo.ToString();

        //HudController._hudControllerInstance.ammoSlider.value = playerCurrentAmmo;
    }





    public void Shoot()
    {
        //if (playerCurrentAmmo > 0)
        //{

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            FirePlayerBullet();
        }

        if (Keyboard.current.spaceKey.isPressed)
        {
            shootDelay -= Time.deltaTime;

            if (shootDelay <= 0)
            {
                FirePlayerBullet();
            }
        }

        // }
    }


    private void FirePlayerBullet()
    {
        Instantiate(playerBullet, weaponLauncher.position, weaponLauncher.rotation);

        shootDelay = fireRate;

        //PlayerWeaponController.playerWeaponController.AmmoRoundsFired();
    }


    public void PositionLauncher(float launcherRotation)
    {
        // set launcher direction
        weaponLauncher.position = new Vector3(weaponLauncher.position.x, weaponLauncher.position.y, 0f);

        weaponLauncher.eulerAngles = new Vector3(0f, launcherRotation, 0f);
    }


} // end of class
