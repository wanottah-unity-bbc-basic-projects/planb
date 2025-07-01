
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// created 2020-08-04
//
// modified 2020-08-18
//

public class PlayerController : MonoBehaviour
{
    public static PlayerController _playerControllerInstance;


    // reference to the player's 'Animator' component
    public Animator playerAnimator;

    // reference to the player's 'Rigidbody' component
    private Rigidbody2D playerRigidbody;

    // reference to player bullet
    public GameObject playerBullet;

    // reference to player's weapon launcher
    public Transform weaponLauncher;


    // how fast the player can move
    private float playerSpeed;

    // direction the player is moving horizontally
    private float horizontalDirection;

    // direction the player is moving vertically
    private float verticalDirection;

    // shoot delay
    private float fireRate;
    private float shootDelay;

    // knockback force
    public float knockbackForce;

    // length of time player will be knocked back for
    public float knockbackDuration;

    // number of times player is knocked back
    public float knockbackCounter;

    // direction from which player is knocked back
    public bool leftKnockback;


    // weapon launcher positions
    private const float LAUNCHER_OFFSET = 2;
    private const float PORT_ROTATION = 180f;
    private const float STARBOARD_ROTATION = 0f;


    // if player is moving
    private bool playerMoving;



    private void Awake()
    {
        _playerControllerInstance = this;
    }


    void Start()
    {
        Initialise();
    }


    void Update()
    {
        GetKeyboardInput();
    }


    private void Initialise()
    {
        // get reference to player's rigidbody component
        playerRigidbody = GetComponent<Rigidbody2D>();

        // set player's horizontal and vertical speed
        playerSpeed = 12f;

        fireRate = 0.1f;

        // set player to idle
        playerMoving = false;

        // set launcher direction
        PositionLauncher(-LAUNCHER_OFFSET, PORT_ROTATION);
    }


    private void PositionLauncher(float launcherOffset, float launcherRotation)
    {
        // set launcher direction
        weaponLauncher.position = new Vector3(transform.position.x + launcherOffset, weaponLauncher.position.y, 0f);

        weaponLauncher.eulerAngles = new Vector3(0f, 0f, launcherRotation);
    }



    // move player with keyboard
    private void GetKeyboardInput()
    {
        // set player's move direction
        horizontalDirection = 0f;


        if (!playerMoving)
        {
            // set player idle animation
            playerAnimator.SetBool("Moving Left", false);

            playerAnimator.SetBool("Moving Right", false);
        }


        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X))
        {
            if (PlayerFuelController._playerFuelControllerInstance.playerCurrentFuel > 0)
            {
                playerMoving = true;
            }
        }

        else
        {
            playerMoving = false;
        }


        // see if player is moving left
        if (Input.GetKey(KeyCode.Z))
        {
            // does player have fuel
            if (PlayerFuelController._playerFuelControllerInstance.playerCurrentFuel > 0)
            {
                // set player's direction to player's speed
                horizontalDirection = -playerSpeed;

                // set launcher direction
                PositionLauncher(-LAUNCHER_OFFSET, PORT_ROTATION);

                // set animation depending on which way the player is moving
                playerAnimator.SetBool("Moving Left", true);
                playerAnimator.SetBool("Moving Right", false);

                // consume fuel while moving
                PlayerFuelController._playerFuelControllerInstance.FuelConsumption(1);
            }
        }


        // see if player is moving right
        if (Input.GetKey(KeyCode.X))
        {
            // does player have fuel
            if (PlayerFuelController._playerFuelControllerInstance.playerCurrentFuel > 0)
            {
                // set player's direction to player's speed
                horizontalDirection = playerSpeed;

                // set launcher direction
                PositionLauncher(LAUNCHER_OFFSET, STARBOARD_ROTATION);

                // set animation depending on which way the player is moving
                playerAnimator.SetBool("Moving Left", false);
                playerAnimator.SetBool("Moving Right", true);

                // consume fuel while moving
                PlayerFuelController._playerFuelControllerInstance.FuelConsumption(1);
            }
        }


        // if player is not being knocked back
        if (knockbackCounter <= 0)
        {
            // move player
            MovePlayerHorizontally();
        }

        // otherwise
        else
        {
            // see from which direction player is being knocked back
            if (leftKnockback)
            {
                // knock player to the right
                horizontalDirection = knockbackForce;

                MovePlayerHorizontally();
            }


            if (!leftKnockback)
            {
                // knock player to the left
                horizontalDirection = -knockbackForce;

                MovePlayerHorizontally();
            }


            // decrease knockback counter
            knockbackCounter -= Time.deltaTime;
        }



        // see if player is moving up
        if (Input.GetKey(KeyCode.Slash))
        {
            if (PlayerFuelController._playerFuelControllerInstance.playerCurrentFuel > 0)
            {
                verticalDirection = playerSpeed;

                MovePlayerUp();
            }
        }

        // otherwise
        else
        {
            // move player down
            verticalDirection = -playerSpeed;

            MovePlayerDown();
        }
        

        // see if player is firing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // does player have ammo
            if (PlayerWeaponController._playerWeaponControllerInstance.playerCurrentAmmo > 0)
            {
                FirePlayerBullet();
            }
        }

        // continuous fire
        if (Input.GetKey(KeyCode.Space))
        {
            if (PlayerWeaponController._playerWeaponControllerInstance.playerCurrentAmmo > 0)
            {
                if (PlayerWeaponController._playerWeaponControllerInstance.currentWeaponStatus > 0)
                {
                    shootDelay -= Time.deltaTime;

                    if (shootDelay <= 0)
                    {
                        FirePlayerBullet();

                        PlayerWeaponController._playerWeaponControllerInstance.WeaponOverheat(10);
                    }
                }
            }
        }

        else
        {
            PlayerWeaponController._playerWeaponControllerInstance.WeaponCooldown(1);
        }
    }


    private void FirePlayerBullet()
    {
        Instantiate(playerBullet, weaponLauncher.position, weaponLauncher.rotation);

        shootDelay = fireRate;

        PlayerWeaponController._playerWeaponControllerInstance.AmmoRoundsFired();
    }


    private void MovePlayerHorizontally()
    {
        playerRigidbody.linearVelocity = new Vector2(horizontalDirection, playerRigidbody.linearVelocity.y);
    }


    private void MovePlayerUp()
    {
        playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, verticalDirection);

        PlayerFuelController._playerFuelControllerInstance.FuelConsumption(1);
    }


    private void MovePlayerDown()
    {
        playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, verticalDirection);
    }


} // end of class
