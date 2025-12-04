
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.04
//



public class PlayerBulletController : MonoBehaviour
{
    // bullet impact effect
    //public GameObject weaponCollisionParticles;

    // reference to player's missile rigidbody components
    public Rigidbody2D playerBulletRigidbody;




    // maximum player ammo
    //private int maximumMissiles;

    //// number of pickup missiles
    ////private int pickupMissiles;

    //// ammo counter
    ////public static int missileCount;

    // speed of bullet
    private float playerBulletSpeed;

    // bullet direction
    [HideInInspector] public Vector2 bulletDirection;





    //// reference to enemy health manager script
    ////public EnemyHealthManager enemyHealthBar;


    //// enemy points
    //private int enemyPoints1;

    //private int enemyDamage;

    //// Missile hit points
    //public int playerMissileHitPoints;



    //// Reference to health text
    ////[SerializeField]
    ////private Text missileCounter;

    ///*
    //// Reference to ammo controller
    //[SerializeField]
    //private AmmoController ammoController;*/




    private void Start()
    {
        InitialiseAmmo();
    }


    private void Update()
    {
        MoveBullet();
    }


    private void InitialiseAmmo()
    {
    //    //enemyHealthManager = FindObjectOfType<EnemyHealthManager>();
    //    //enemyHealthBar = GetComponent<EnemyHealthManager>();

        #region ENEMY VALUES

        //enemyDamage = 50;

        //enemyPoints1 = 1;

        #endregion


        playerBulletSpeed = 16f;




    //    //maximumMissiles = 200;

    //    //pickupMissiles = 50;

    //    //missileCount = maximumMissiles;
    //    //}


    //    // Update ammo display
    //    //private void Update()
    //    //{


    //    /*if (PlayerController.playerFacingLeft)
    //    {
    //        playerBulletRigidbody.velocity = new Vector2(-playerBulletSpeed, playerBulletRigidbody.velocity.y);
    //    }

    //    else
    //    {
    //        playerBulletRigidbody.velocity = new Vector2(playerBulletSpeed, playerBulletRigidbody.velocity.y);
    //    }*/

        //playerBulletRigidbody.linearVelocity = transform.right * playerBulletSpeed;

    //    // Update ammo count
    //    //missileCounter.text = "" + missileCount;
    }


    private void MoveBullet()
    {
        playerBulletRigidbody.linearVelocity = bulletDirection * playerBulletSpeed;
    }


    //// restore ammo
    //public void MissilePickup()
    //{
    //    //missileCount = pickupMissiles;
    //}


    private void OnTriggerEnter2D(Collider2D objectCollidedWith)
    {
        //    // check if missile has hit enemy
        //    if (objectCollidedWith.CompareTag("Enemy 1"))
        //    {
        //        Debug.Log("hit enemy");
        //        // kill the enemy
        //        //Instantiate(enemyDeadParticles, collidingObject.transform.position, collidingObject.transform.rotation);

        //        //Destroy(collidingObject.gameObject);
        //        objectCollidedWith.GetComponent<EnemyController>().DamageEnemy(enemyDamage);

        //        // Update score
        //        //ScoreManager.AddPoints(enemyPoints01);

        //        //collidingObject.GetComponent<EnemyHealthManager>().DamageEnemy(playerMissileHitPoints);
        //        //enemyHealthBar.DamageEnemy(playerMissileHitPoints);
        //    }



        // bullet hit destructable
        if (objectCollidedWith.CompareTag("Destructable"))
        {
            objectCollidedWith.gameObject.SetActive(false);
        }


        // bullet hit ammo pickup
        if (objectCollidedWith.CompareTag("Ammo Pickup"))
        {
            Destroy(objectCollidedWith.gameObject);
        }


        // bullet hit spanner pickup
        if (objectCollidedWith.CompareTag("Spanner Pickup"))
        {
            Destroy(objectCollidedWith.gameObject);
        }


        // bullet hit oil drum pickup
        if (objectCollidedWith.CompareTag("Oil Drum Pickup"))
        {
            Destroy(objectCollidedWith.gameObject);
        }

        Destroy(gameObject);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


} // end of class
