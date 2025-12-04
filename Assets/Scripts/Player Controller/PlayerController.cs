
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.04
//

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;


    // reference to the player's 'Rigidbody' component
    public Rigidbody2D playerRigidbody;

    // reference to player bullet
    public PlayerBulletController playerBullet;

    // reference to player's weapon launcher
    public Transform weaponLauncher;

    public Transform scanner;


    // how fast the player can move
    private float playerSpeed;

    private Vector2 playerStartPosition;


    // direction the player is moving horizontally
    private float horizontalDirection;

    // direction the player is moving vertically
    private float verticalDirection;

    // shoot delay
    private float fireRate;
    private float shootDelay;


    // weapon launcher positions
    //private const float LAUNCHER_OFFSET = 2;
    private const float PORT_ROTATION = 0f;
    private const float STARBOARD_ROTATION = 180f;


    // player direction
    private const float FACING_LEFT = -1f;
    private const float FACING_RIGHT = 1f;

    //private const float PLAYER_MOVE_SPEED = 2.5f;
    //private const float PLAYER_FIRE_RATE = 0.4f;


    //private bool playerIsMoving;
    //public bool playerIsFacingRight;
    //public bool playerFacingLeft;
    //private bool playerIsFiring;
    //public bool playerIsDead;

    //public bool playerHasLeftRoom;
    //public int exit;

    //public bool inPlay;




    private void Awake()
    {
        playerController = this;
    }


    private void Start()
    {
        //InitialisePlayer();
    }


    private void Update()
    {
        GetKeyboardInput();
    }


    public void InitialisePlayer()
    {
        PositionPlayer();

        // set player's horizontal and vertical speed
        playerSpeed = 10f;

        fireRate = 0.25f;

        // set launcher direction
        PositionLauncher(PORT_ROTATION);

        playerBullet.bulletDirection = new Vector2(FACING_LEFT, 0f);

        //PlayerWeaponController.playerWeaponController.InitialisePlayerAmmo();
    }


    // move player with keyboard
    public void GetKeyboardInput()
    {
        //if (playerIsDead)
        //{
        //    return;
        //}


        // set player's horizontal move speed
        horizontalDirection = 0f;


        // move player left
        if (Input.GetKey(KeyCode.Z))
        {
            // set player's direction to player's speed
            horizontalDirection = -playerSpeed;

            // set launcher direction
            PositionLauncher(PORT_ROTATION);

            playerBullet.bulletDirection = new Vector2(FACING_LEFT, 0f);

            // face player left
            transform.localScale = new Vector3(FACING_LEFT, 1f, 1f);

            scanner.transform.localScale = new Vector3(FACING_LEFT, 1f, 1f);
        }


        // move player right
        if (Input.GetKey(KeyCode.X))
        {
            // set player's direction to player's speed
            horizontalDirection = playerSpeed;

            // set launcher direction
            PositionLauncher(STARBOARD_ROTATION);

            playerBullet.bulletDirection = new Vector2(FACING_RIGHT, 0f);

            // face player right
            transform.localScale = new Vector3(FACING_RIGHT, 1f, 1f);

            scanner.transform.localScale = new Vector3(FACING_RIGHT, 1f, 1f);
        }

        MovePlayerHorizontally();


        // move player up
        if (Input.GetKey(KeyCode.RightShift))
        {
            verticalDirection = playerSpeed;

            MovePlayerUp();
        }

        // otherwise
        else
        {
            // move player down
            verticalDirection = -playerSpeed;

            MovePlayerDown();
        }


        // see if player can fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // does player have ammo
            //if (PlayerWeaponController.playerWeaponController.playerCurrentAmmo > 0)
            //{
                FirePlayerBullet();
            //}
        }

        // continuous fire
        if (Input.GetKey(KeyCode.Space))
        {
            //if (PlayerWeaponController.playerWeaponController.playerCurrentAmmo > 0)
            //{
            //if (PlayerWeaponController.playerWeaponController.currentWeaponStatus > 0)
            //{
            shootDelay -= Time.deltaTime;

            if (shootDelay <= 0)
            {
                FirePlayerBullet();

                //PlayerWeaponController.playerWeaponController.WeaponOverheat(10);

                shootDelay = fireRate;
            }
            //}
            //}
        }

        //else
        //{
            //PlayerWeaponController.playerWeaponController.WeaponCooldown(1);
        //}


        if (Input.GetKeyDown(KeyCode.R))
        {
            // unlock door
        }
    }


    private void FirePlayerBullet()
    {
        Instantiate(playerBullet, weaponLauncher.position, weaponLauncher.rotation);

        shootDelay = fireRate;

        //PlayerWeaponController.playerWeaponController.AmmoRoundsFired();
    }


    private void MovePlayerHorizontally()
    {
        playerRigidbody.linearVelocity = new Vector2(horizontalDirection, playerRigidbody.linearVelocity.y);
    }


    private void MovePlayerUp()
    {
        playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, verticalDirection);
    }


    private void MovePlayerDown()
    {
        playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, verticalDirection);
    }


    private void PositionPlayer()
    {
        playerStartPosition = new Vector2(GameController.PLAYER_START_POSITION_X, GameController.PLAYER_START_POSITION_Y);

        transform.position = playerStartPosition;

        // face player left
        transform.localScale = new Vector3(FACING_LEFT, 1f, 1f);

        scanner.transform.localScale = new Vector3(FACING_LEFT, 1f, 1f);
    }


    //private void PositionLauncher()  //float launcherOffset, float launcherRotation)
    private void PositionLauncher(float launcherRotation)
    {
        // set launcher direction
        weaponLauncher.position = new Vector3(weaponLauncher.position.x, weaponLauncher.position.y, 0f);

        weaponLauncher.eulerAngles = new Vector3(0f, 0f, launcherRotation);
    }


} // end of class
