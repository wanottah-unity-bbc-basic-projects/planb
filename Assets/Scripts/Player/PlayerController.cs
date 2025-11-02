
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.01
//

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;


    // reference to the player's 'Animator' component
    //public Animator playerAnimator;

    // reference to the player's 'Rigidbody' component
    private Rigidbody2D playerRigidbody;


    // reference to player bullet
    public GameObject playerBullet;

    // reference to player's weapon launcher
    public Transform weaponHolder;
    public Transform weaponLauncher;

    public Transform scanner;


    // how fast the player can move
    private float playerHorizontalSpeed;
    private float playerVerticalSpeed;
    private float playerSpeed;

    private Vector2 playerStartPosition;


    // direction the player is moving horizontally
    private float horizontalDirection;

    // direction the player is moving vertically
    private float verticalDirection;

    // shoot delay
    private float fireRate;
    private float shootDelay;

    //// knockback force
    //public float knockbackForce;

    //// length of time player will be knocked back for
    //public float knockbackDuration;

    //// number of times player is knocked back
    //public float knockbackCounter;

    //// direction from which player is knocked back
    //public bool leftKnockback;


    //// weapon launcher positions
    //private const float LAUNCHER_OFFSET = 2;
    //private const float PORT_ROTATION = 180f;
    //private const float STARBOARD_ROTATION = 0f;


    // player direction
    private const float FACING_LEFT = 1f;
    private const float FACING_RIGHT = -1f;

    private const float PLAYER_MOVE_SPEED = 2.5f;
    private const float PLAYER_FIRE_RATE = 0.4f;

    // player start position
    private const float PLAYER_START_POSITION_X = 255.5f;
    private const float PLAYER_START_POSITION_Y = -53.5f;



    private bool playerIsMoving;
    public bool playerIsFacingRight;
    private bool playerIsFiring;
    public bool playerIsDead;

    public bool playerHasLeftRoom;
    public int exit;

    public bool inPlay;




    private void Awake()
    {
        playerController = this;

        // get reference to player's rigidbody component
        playerRigidbody = GetComponent<Rigidbody2D>();
    }


    //void Start()
    //{
    //    Initialise();
    //}


    //void Update()
    //{
    //    GetKeyboardInput();

    //    MovePlayer();
    //}


    public void InitialisePlayer()
    {
        PositionPlayer();

        // set player's horizontal and vertical speed
        playerHorizontalSpeed = 12f;
        playerVerticalSpeed = 8f;

        //    fireRate = 0.1f;

        //    // set player to idle
        //    playerMoving = false;

        //    // set launcher direction
        //    PositionLauncher(-LAUNCHER_OFFSET, PORT_ROTATION);

        playerSpeed = PLAYER_MOVE_SPEED;

        //playerFireDirection = ANIMATION_PLAYER_IDLE;

        fireRate = PLAYER_FIRE_RATE;

        // reset player 1 start position
        //GameController.gameController.playerRespawning = true;


        playerIsFacingRight = true;
        playerIsMoving = false;
        playerIsFiring = false;
        playerIsDead = false;
        playerHasLeftRoom = false;

        exit = -1;

        //inPlay = false;
    }


    // move player with keyboard
    public void GetPlayerInput()
    {
        if (playerIsDead)
        {
            return;
        }

        PlayerControllerInput();

        MovePlayer();
    }

    private void PlayerControllerInput()
    { 
        // set player's horizontal move speed
        horizontalDirection = 0f;


        // move player left
        if (Input.GetKey(KeyCode.Z))
        {
            horizontalDirection = -playerHorizontalSpeed;

            // face player left
            transform.localScale = new Vector3(FACING_LEFT, 1f, 1f);

            scanner.transform.localScale = new Vector3(FACING_LEFT, 1f, 1f);
        }


        // move player right
        if (Input.GetKey(KeyCode.X))
        {
            horizontalDirection = playerHorizontalSpeed;

            // face player right
            transform.localScale = new Vector3(FACING_RIGHT, 1f, 1f);

            scanner.transform.localScale = new Vector3(FACING_RIGHT, 1f, 1f);
        }


        // move player up
        if (Input.GetKey(KeyCode.RightShift))
        {
            verticalDirection = playerVerticalSpeed;
        }

        // otherwise
        // move player down
        else
        {
            verticalDirection = -playerVerticalSpeed;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            // fire
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            // unlock door
        }
    }


    private void MovePlayer()
    {
        playerRigidbody.linearVelocity = new Vector2(horizontalDirection, verticalDirection);
    }


    public void EnterNewRoom(int exit)
    {
        // move player
        Vector2 newPlayerPosition;

        //if (GameController.gameController.playerRespawning)
        //{
        //    newPlayerPosition.x = playerSpawnPoint[exit].position.x;
        //    newPlayerPosition.y = playerSpawnPoint[exit].position.y;

        //    PositionPlayer(new Vector2(newPlayerPosition.x, newPlayerPosition.y));

        //    GameController.gameController.playerRespawning = false;
        //}

        //else
        //{
        //    int spawnPoint = GameController.gameController.GetOppositeExit(exit);

        //    newPlayerPosition.x = playerSpawnPoint[spawnPoint].position.x;
        //    newPlayerPosition.y = playerSpawnPoint[spawnPoint].position.y;
        //}

        //switch (exit)
        //{
        //    case RoomController.NORTH_EXIT: playerSector = NORTH_SECTOR; break;
        //    case RoomController.SOUTH_EXIT: playerSector = SOUTH_SECTOR; break;
        //    case RoomController.EAST_EXIT: playerSector = EAST_SECTOR; break;
        //    case RoomController.WEST_EXIT: playerSector = WEST_SECTOR; break;
        //}

        //PositionPlayer(new Vector2(newPlayerPosition.x, newPlayerPosition.y));
    }


    private void PositionPlayer() //(Vector2 position)
    {
        playerStartPosition = new Vector2(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y);

        transform.position = playerStartPosition;

        //playerSpriteRenderer.enabled = true;

        //playerAnimator.SetBool("playerStart", true);

        //yield return new WaitForSeconds(2.5f);

        //playerAnimator.SetBool("playerStart", false);

        //inPlay = true;
    }






















    //private void PositionLauncher(float launcherOffset, float launcherRotation)
    //{
    //    // set launcher direction
    //    weaponLauncher.position = new Vector3(transform.position.x + launcherOffset, weaponLauncher.position.y, 0f);

    //    weaponLauncher.eulerAngles = new Vector3(0f, 0f, launcherRotation);
    //}




    ////    if (!playerMoving)
    ////    {
    ////        // set player idle animation
    ////        playerAnimator.SetBool("Moving Left", false);

    ////        playerAnimator.SetBool("Moving Right", false);
    ////    }


    ////    if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X))
    ////    {
    ////        if (PlayerFuelController._playerFuelControllerInstance.playerCurrentFuel > 0)
    ////        {
    ////            playerMoving = true;
    ////        }
    ////    }

    ////    else
    ////    {
    ////        playerMoving = false;
    ////    }


    //    // see if player is moving left
    //    if (Input.GetKey(KeyCode.Z))
    //    {
    ////        // does player have fuel
    ////        if (PlayerFuelController._playerFuelControllerInstance.playerCurrentFuel > 0)
    ////        {
    //            // set player's direction to player's speed
    //            horizontalDirection = -playerSpeed;

    ////            // set launcher direction
    ////            PositionLauncher(-LAUNCHER_OFFSET, PORT_ROTATION);

    ////            // set animation depending on which way the player is moving
    ////            playerAnimator.SetBool("Moving Left", true);
    ////            playerAnimator.SetBool("Moving Right", false);

    ////            // consume fuel while moving
    ////            PlayerFuelController._playerFuelControllerInstance.FuelConsumption(1);
    ////        }
    //    }


    //    // see if player is moving right
    //    if (Input.GetKey(KeyCode.X))
    //    {
    ////        // does player have fuel
    ////        if (PlayerFuelController._playerFuelControllerInstance.playerCurrentFuel > 0)
    ////        {
    //            // set player's direction to player's speed
    //            horizontalDirection = playerSpeed;

    ////            // set launcher direction
    ////            PositionLauncher(LAUNCHER_OFFSET, STARBOARD_ROTATION);

    ////            // set animation depending on which way the player is moving
    ////            playerAnimator.SetBool("Moving Left", false);
    ////            playerAnimator.SetBool("Moving Right", true);

    ////            // consume fuel while moving
    ////            PlayerFuelController._playerFuelControllerInstance.FuelConsumption(1);
    ////        }
    //    }


    ////    // if player is not being knocked back
    ////    if (knockbackCounter <= 0)
    ////    {
    ////        // move player
    //        MovePlayerHorizontally();
    ////    }

    ////    // otherwise
    ////    else
    ////    {
    ////        // see from which direction player is being knocked back
    ////        if (leftKnockback)
    ////        {
    ////            // knock player to the right
    ////            horizontalDirection = knockbackForce;

    ////            MovePlayerHorizontally();
    ////        }


    ////        if (!leftKnockback)
    ////        {
    ////            // knock player to the left
    ////            horizontalDirection = -knockbackForce;

    ////            MovePlayerHorizontally();
    ////        }


    ////        // decrease knockback counter
    ////        knockbackCounter -= Time.deltaTime;
    ////    }



    //    // see if player is moving up
    //    if (Input.GetKey(KeyCode.Slash))
    //    {
    //        //        if (PlayerFuelController._playerFuelControllerInstance.playerCurrentFuel > 0)
    //        //        {
    //        verticalDirection = playerSpeed;

    //        MovePlayerUp();
    ////        }
    //    }

    //    // otherwise
    //    else
    //    {
    //        // move player down
    //        verticalDirection = -playerSpeed;

    //        MovePlayerDown();
    //    }


    ////    // see if player is firing
    ////    if (Input.GetKeyDown(KeyCode.Space))
    ////    {
    ////        // does player have ammo
    ////        if (PlayerWeaponController._playerWeaponControllerInstance.playerCurrentAmmo > 0)
    ////        {
    ////            FirePlayerBullet();
    ////        }
    ////    }

    ////    // continuous fire
    ////    if (Input.GetKey(KeyCode.Space))
    ////    {
    ////        if (PlayerWeaponController._playerWeaponControllerInstance.playerCurrentAmmo > 0)
    ////        {
    ////            if (PlayerWeaponController._playerWeaponControllerInstance.currentWeaponStatus > 0)
    ////            {
    ////                shootDelay -= Time.deltaTime;

    ////                if (shootDelay <= 0)
    ////                {
    ////                    FirePlayerBullet();

    ////                    PlayerWeaponController._playerWeaponControllerInstance.WeaponOverheat(10);
    ////                }
    ////            }
    ////        }
    ////    }

    ////    else
    ////    {
    ////        PlayerWeaponController._playerWeaponControllerInstance.WeaponCooldown(1);
    ////    }
    //}


    ////private void FirePlayerBullet()
    ////{
    ////    Instantiate(playerBullet, weaponLauncher.position, weaponLauncher.rotation);

    ////    shootDelay = fireRate;

    ////    PlayerWeaponController._playerWeaponControllerInstance.AmmoRoundsFired();
    ////}


} // end of class
