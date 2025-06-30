
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Plan B 2020 Mk i
/// Port of 'Plan B' for the BBC Model B
/// by Andrew Foord - Copyright 1987
/// PlayerBulletController.cs
/// Adapted from 'Learn to Code By Making a 2D Platformer in Unity'
/// by James Doyle
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 26/03/2019
/// </summary>

//
// modified 2020-08-09
//

public class EnemyBulletController : MonoBehaviour
{
    // Maximum player ammo
    //private int maximumMissiles;

    // Number of pickup missiles
    //private int pickupMissiles;

    // Ammo counter
    //public static int missileCount;

    // enemy bullet speed
    private float enemyBulletSpeed;

    private Vector3 enemyBulletDirection;

    //public int playerDamage;


    // Reference to player's missile rigidbody components
    //private Rigidbody2D portMissileRigidbody;

    //private Rigidbody2D starboardMissileRigidbody;


    // Reference to enemy death particle effect
    //[SerializeField]
    //private GameObject enemyDeadParticles;

    // Reference to missile collision particle effect
    //[SerializeField]
    //private GameObject missileCollisionParticles;


    // Reference to enemy health manager script
    //public EnemyHealthManager enemyHealthBar;


    // Enemy points
    //public int enemyPoints01;

    // Missile hit points
    //public int playerMissileHitPoints;



    // Reference to health text
    //[SerializeField]
    //private Text missileCounter;

    /*
    // Reference to ammo controller
    [SerializeField]
    private AmmoController ammoController;*/



    private void Awake()
    {
        //portMissileRigidbody = GetComponent<Rigidbody2D>();

        //starboardMissileRigidbody = GetComponent<Rigidbody2D>();
    }


    // Initialise ammo
    private void Start()
    {
        Initialise();



        //enemyHealthManager = FindObjectOfType<EnemyHealthManager>();
        //enemyHealthBar = GetComponent<EnemyHealthManager>();






        //maximumMissiles = 200;

        //pickupMissiles = 50;

        //missileCount = maximumMissiles;
        //}


        // Update ammo display
        //private void Update()
        //{


        /*if (EnemyAttackController.enemyFacingLeft)
        {
            //portMissileRigidbody.velocity = new Vector2(-enemyBulletSpeed, portMissileRigidbody.velocity.y);
        }

        else
        {
            //starboardMissileRigidbody.velocity = new Vector2(enemyBulletSpeed, starboardMissileRigidbody.velocity.y);
        }*/

        // Update ammo count
        //missileCounter.text = "" + missileCount;
    }


    private void Update()
    {
        MoveEnemyBullet();
    }


    private void MoveEnemyBullet()
    {
        transform.position += enemyBulletDirection * enemyBulletSpeed * Time.deltaTime;
    }


    private void Initialise()
    {
        enemyBulletSpeed = 20f;

        //playerDamage = 50;

        // get player's direction
        enemyBulletDirection = PlayerController._playerControllerInstance.transform.position - transform.position;

        enemyBulletDirection.Normalize();
    }



    // destroy enemy bullet when it collides with another object
    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        // check if enemy bullet has hit player
        if (collidingObject.CompareTag("Player"))
        {
            PlayerEnergyController._playerEnergyControllerInstance.DamagePlayer(EnemyController.playerDamage);

            // Kill the enemy
            //Instantiate(enemyDeadParticles, collidingObject.transform.position, collidingObject.transform.rotation);

            //Destroy(collidingObject.gameObject);
            Destroy(gameObject);
        }

        // check if enemy bullet has hit ground
        /*if (collidingObject.CompareTag("Ground"))
        {
            Debug.Log("hit ground");

            Destroy(gameObject);
        }*/

    }


} // end of class
