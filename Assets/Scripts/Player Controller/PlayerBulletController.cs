
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.16
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





    //// reference to enemy health manager script
    ////public EnemyHealthManager enemyHealthBar;


    //// enemy points
    //private int enemyPoints1;

    // damage to enemy
    public int damageToEnemy;

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
        playerBulletSpeed = 16f;



        //    //enemyHealthManager = FindObjectOfType<EnemyHealthManager>();
        //    //enemyHealthBar = GetComponent<EnemyHealthManager>();

        damageToEnemy = 1;

        //enemyPoints1 = 1;


        

        




    //    //maximumMissiles = 200;

    //    //pickupMissiles = 50;

    //    //missileCount = maximumMissiles;
    //    //}


    //    // Update ammo display

    //    // Update ammo count
    //    //missileCounter.text = "" + missileCount;
    }


    private void MoveBullet()
    {
        playerBulletRigidbody.linearVelocity = transform.right * playerBulletSpeed;
    }


    //// restore ammo
    //public void MissilePickup()
    //{
    //    //missileCount = pickupMissiles;
    //}


    private void OnTriggerEnter2D(Collider2D objectCollidedWith)
    {
            // bullet hit enemy 1
            if (objectCollidedWith.CompareTag("Enemy 1"))
            {
        //        Debug.Log("hit enemy");
        //        // kill the enemy
        //        //Instantiate(enemyDeadParticles, collidingObject.transform.position, collidingObject.transform.rotation);

        //        //Destroy(collidingObject.gameObject);
                objectCollidedWith.GetComponent<EnemyController>().DamageEnemy(damageToEnemy);

        //        // Update score
        //        //ScoreManager.AddPoints(enemyPoints01);

        //        //collidingObject.GetComponent<EnemyHealthManager>().DamageEnemy(playerMissileHitPoints);
        //        //enemyHealthBar.DamageEnemy(playerMissileHitPoints);
            }



        // bullet hit destructable
        if (objectCollidedWith.CompareTag("Destructable"))
        {
            // disable destructable
            objectCollidedWith.gameObject.SetActive(false);
        }


        // bullet hit ammo pickup
        if (objectCollidedWith.CompareTag("Ammo Pickup"))
        {
            // destroy ammo pickup
            Destroy(objectCollidedWith.gameObject);
        }


        // bullet hit spanner pickup
        if (objectCollidedWith.CompareTag("Spanner Pickup"))
        {
            // destroy spanner pickup
            Destroy(objectCollidedWith.gameObject);
        }


        // bullet hit oil drum pickup
        if (objectCollidedWith.CompareTag("Oil Drum Pickup"))
        {
            // destroy oil drum pickup
            Destroy(objectCollidedWith.gameObject);
        }


        // destroy player bullet
        Destroy(gameObject);
    }


    // when the player bullet goes off screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


} // end of class
