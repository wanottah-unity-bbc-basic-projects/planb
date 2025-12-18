
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.12
//

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;

    // reference to player's weapon controller script
    public PlayerWeaponController playerWeapon;

    // reference to the player's 'Rigidbody' component
    public Rigidbody2D playerRigidbody;









    // reference to move action
    public InputActionReference moveAction;

    // direction the player is moving horizontally
    private float horizontalDirection;

    // direction the player is moving vertically
    private float verticalDirection;

    private Vector2 moveDirection;

    // how fast the player can move
    private float playerSpeed;

    private Vector2 playerStartPosition;



    // reference to shoot action
    public InputActionReference shootAction;





    public Transform scanner;



    // weapon launcher positions
    //private const float LAUNCHER_OFFSET = 2;
    private const float PORT_ROTATION = 180f;
    private const float STARBOARD_ROTATION = 0f;


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


    private void Update()
    {
        GetKeyboardInput();
    }


    public void InitialisePlayer()
    {
        PositionPlayer();

        // set player's horizontal and vertical speed
        playerSpeed = 10f;
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

        moveDirection = moveAction.action.ReadValue<Vector2>();

        


        // move player left
        //if (Input.GetKey(KeyCode.Z))
        if (moveDirection.x < 0)
        {
            // set player's direction to player's speed
            horizontalDirection = -playerSpeed;

            SetPlayerDirection(PORT_ROTATION, FACING_LEFT);
        }


        // move player right
        //if (Input.GetKey(KeyCode.X))
        if (moveDirection.x > 0)
        {
            // set player's direction to player's speed
            horizontalDirection = playerSpeed;

            SetPlayerDirection(STARBOARD_ROTATION, FACING_RIGHT);
        }


        // move player up
        //if (Input.GetKey(KeyCode.RightShift))
        if (moveDirection.y > 0)
        {
            verticalDirection = playerSpeed;
        }

        // otherwise
        else
        {
            // move player down
            verticalDirection = -playerSpeed;
        }

        MovePlayer();


        // see if player can fire
        //if (shootAction.action.WasPressedThisFrame())
        //{
        //    playerWeaponController.Shoot();
        //}

        //if (shootAction.action.IsPressed())
        //{
        //    playerWeaponController.ShootContinuos();
        //}



        //if (Input.GetKeyDown(KeyCode.R))
        //if (playerControls.Player.Open.ReadValue<float>() > 0)
        //{
            // unlock door
            //Debug.Log("Door Open");
        //}
    }


    private void MovePlayer()
    {
        playerRigidbody.linearVelocity = new Vector2(horizontalDirection, verticalDirection);
    }


    private void PositionPlayer()
    {
        playerStartPosition = new Vector2(GameController.PLAYER_START_POSITION_X, GameController.PLAYER_START_POSITION_Y);

        transform.position = playerStartPosition;

        SetPlayerDirection(PORT_ROTATION, FACING_LEFT);
    }


    private void SetPlayerDirection(float rotation, float direction)
    {
        // face player left
        transform.localScale = new Vector3(direction, 1f, 1f);

        scanner.transform.localScale = new Vector3(direction, 1f, 1f);

        // set launcher direction
        playerWeapon.PositionLauncher(rotation);
    }


} // end of class
