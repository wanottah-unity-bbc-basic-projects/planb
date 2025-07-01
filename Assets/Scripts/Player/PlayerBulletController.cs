
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Plan B 2020 Mk i
/// Port of Plan B for the BBC Model B
/// by Andrew Foord - Copyright 1987
/// PlayerBulletController.cs
/// Adapted from 'Learn to Code By Making a 2D Platformer in Unity'
/// by James Doyle
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 26/03/2019
/// </summary>

//
// modified 2020-08-06
//


public class PlayerBulletController : MonoBehaviour
{
    // bullet impact effect
    public GameObject weaponCollisionParticles;

    // reference to player's missile rigidbody components
    private Rigidbody2D playerBulletRigidbody;




    // maximum player ammo
    //private int maximumMissiles;

    // number of pickup missiles
    //private int pickupMissiles;

    // ammo counter
    //public static int missileCount;

    // speed of bullet
    private float playerBulletSpeed;





    // reference to enemy health manager script
    //public EnemyHealthManager enemyHealthBar;


    // enemy points
    private int enemyPoints1;

    private int enemyDamage;

    // Missile hit points
    public int playerMissileHitPoints;



    // Reference to health text
    //[SerializeField]
    //private Text missileCounter;

    /*
    // Reference to ammo controller
    [SerializeField]
    private AmmoController ammoController;*/



    private void Awake()
    {
        playerBulletRigidbody = GetComponent<Rigidbody2D>();

        //starboardMissileRigidbody = GetComponent<Rigidbody2D>();
    }


    // Initialise ammo
    private void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        //enemyHealthManager = FindObjectOfType<EnemyHealthManager>();
        //enemyHealthBar = GetComponent<EnemyHealthManager>();

        #region ENEMY VALUES

        enemyDamage = 50;

        enemyPoints1 = 1;

        #endregion


        playerBulletSpeed = 20f;




        //maximumMissiles = 200;

        //pickupMissiles = 50;

        //missileCount = maximumMissiles;
        //}


        // Update ammo display
        //private void Update()
        //{


        /*if (PlayerController.playerFacingLeft)
        {
            playerBulletRigidbody.velocity = new Vector2(-playerBulletSpeed, playerBulletRigidbody.velocity.y);
        }

        else
        {
            playerBulletRigidbody.velocity = new Vector2(playerBulletSpeed, playerBulletRigidbody.velocity.y);
        }*/

        playerBulletRigidbody.linearVelocity = transform.right * playerBulletSpeed;

        // Update ammo count
        //missileCounter.text = "" + missileCount;
    }


    // restore ammo
    public void MissilePickup()
    {
        //missileCount = pickupMissiles;
    }


    // destroy player bullet when it collides with another object
    private void OnTriggerEnter2D(Collider2D objectCollidedWith)
    {
        // check if missile has hit enemy
        if (objectCollidedWith.CompareTag("Enemy 1"))
        {
            Debug.Log("hit enemy");
            // kill the enemy
            //Instantiate(enemyDeadParticles, collidingObject.transform.position, collidingObject.transform.rotation);

            //Destroy(collidingObject.gameObject);
            objectCollidedWith.GetComponent<EnemyController>().DamageEnemy(enemyDamage);

            // Update score
            //ScoreManager.AddPoints(enemyPoints01);

            //collidingObject.GetComponent<EnemyHealthManager>().DamageEnemy(playerMissileHitPoints);
            //enemyHealthBar.DamageEnemy(playerMissileHitPoints);
        }


        /*if (collidingObject.CompareTag("Small Crate"))
        {
            Destroy(collidingObject.gameObject);
        }


        // Check if missile has hit enemy
        if (collidingObject.CompareTag("Fuel Pickup"))
        {
            // Kill the enemy
            //Instantiate(enemyDeadParticles, collidingObject.transform.position, collidingObject.transform.rotation);

            //Destroy(collidingObject.gameObject);
        }


        // Check if missile has hit enemy
        if (collidingObject.CompareTag("Green Crate Pickup"))
        {
            // Kill the enemy
            //Instantiate(enemyDeadParticles, collidingObject.transform.position, collidingObject.transform.rotation);

            //Destroy(collidingObject.gameObject);
        }


        // Check if missile has hit enemy
        if (collidingObject.CompareTag("Ammo Pickup"))
        {
            // Kill the enemy
            //Instantiate(enemyDeadParticles, collidingObject.transform.position, collidingObject.transform.rotation);

            //Destroy(collidingObject.gameObject);
        }


        // Check if missile has hit enemy
        if (collidingObject.CompareTag("Spanner Pickup"))
        {
            // Kill the enemy
            //Instantiate(enemyDeadParticles, collidingObject.transform.position, collidingObject.transform.rotation);

            //Destroy(collidingObject.gameObject);
        }


        // Check if missile has hit enemy
        if (collidingObject.CompareTag("Oil Drum Pickup"))
        {
            // Kill the enemy
            //Instantiate(enemyDeadParticles, collidingObject.transform.position, collidingObject.transform.rotation);

            //Destroy(collidingObject.gameObject);
        }
        */

        // Destroy missile
        //Instantiate(missileCollisionParticles, transform.position, transform.rotation);

        // impact effect
        Instantiate(weaponCollisionParticles, transform.position, transform.rotation);

        Destroy(gameObject);
    }


} // end of class
