
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.16
//

public class EnemyController : MonoBehaviour
{
    // reference to the enemy's 'Rigidbody' component
    public Rigidbody2D enemyRigidbody;

    //// reference to the enemy's 'Animator' component
    //public Animator enemyAnimator;

    // reference to enemy's sprite renderer component
    public SpriteRenderer enemySprite;

    //// reference to enemy death particle effect
    //public GameObject enemyDeathParticles;

    //public GameObject enemyBullet;

    //public Transform weaponLauncher;


    // enemy health
    public int enemyHealth;

    // enemy movement speed
    private float enemySpeed;

    //// player damage
    //public static int playerDamage;

    // delay for enemy movement
    //private float movementDelayTime;
    //public float delayTime;

    //// Enemy patrol movement
    ////private Vector3 moveVector;


    //#region ATTACK

    //public bool shouldAttack;

    //public float attackRange;

    //private Vector3 attackDirection;

    //#endregion


    //#region PATROL

    //public bool shouldRandomPatrol;

    public float randomPatrolDuration;

    public float randomPatrolPauseDuration;

    private float randomPatrolCounter;

    private float randomPatrolPauseCounter;

    private Vector3 randomPatrolDirection;

    //#endregion


    //#region SHOOT

    //public bool shouldShoot;

    //public float shootRange;

    //public float fireRate;

    //private float fireCounter;

    //#endregion



    private void Start()
    {
        Initialise();
    }


    private void Update()
    {
        //EnemyState();
    }


    private void Initialise()
    {
        //    //enemyHealth = 100;
        enemyHealth = 1;

     // set enemy's horizontal and vertical speed
        enemySpeed = 8f;

        //    // player damage
        //    playerDamage = 1;


        //    // initalise random patrol
        //    if (shouldRandomPatrol)
        //    {
        //randomPatrolPauseCounter = Random.Range(randomPatrolPauseDuration * .75f, randomPatrolPauseDuration * 1.25f);
        randomPatrolPauseCounter = Random.Range(0.75f, 1.25f);
        //    }
    }


    private void EnemyState()
    {
        if (enemySprite.isVisible)
        {
            //if (shouldAttack)
            //{
            //    AttackPlayer();
            //}

            //if (shouldRandomPatrol)
            //{
                RandomPatrol();
            //}

            //if (shouldShoot)
            //{
            //    ShootPlayer();
            //}

            MoveEnemy();
        }
    }



    //private void AttackPlayer()
    //{
    //    //attackDirection = Vector3.zero;

    //    //// if player is in range
    //    //if (Vector3.Distance(transform.position, PlayerController._playerControllerInstance.transform.position) <= attackRange)
    //    //{
    //    //    // set attack direction toward player
    //    //    attackDirection = PlayerController._playerControllerInstance.transform.position - transform.position;
    //    //}

    //    //// otherwise . . .
    //    //else
    //    //{
    //    //    RandomPatrol();
    //    //}
    //}


    private void RandomPatrol()
    {
        //    if (shouldRandomPatrol)
        //    {
        if (randomPatrolCounter > 0)
        {
            randomPatrolCounter -= Time.deltaTime;

            // random patrol
            //attackDirection = randomPatrolDirection;

            if (randomPatrolCounter <= 0)
            {
                //randomPatrolPauseCounter = Random.Range(randomPatrolPauseDuration * .75f, randomPatrolPauseDuration * 1.25f);
                randomPatrolPauseCounter = Random.Range(0.75f, 1.25f);
            }
        }

        if (randomPatrolPauseCounter > 0)
        {
            randomPatrolPauseCounter -= Time.deltaTime;

            if (randomPatrolPauseCounter <= 0)
            {
                //randomPatrolCounter = Random.Range(randomPatrolDuration * .75f, randomPatrolDuration * 1.25f);
                randomPatrolCounter = Random.Range(0.75f, 1.25f);

                SelectRandomPatrolDirection();
            }
        }
        //    }
    }


    // select a random patrol direction
    private void SelectRandomPatrolDirection()
    {
        randomPatrolDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }


    // move enemy
    private void MoveEnemy()
    {
        //attackDirection.Normalize();

        //enemyRigidbody.linearVelocity = attackDirection * enemySpeed;
        enemyRigidbody.linearVelocity = randomPatrolDirection * enemySpeed;
    }


    //private void ShootPlayer()
    //{
    //    //// and player is within firing range
    //    //if (Vector3.Distance(transform.position, PlayerController._playerControllerInstance.transform.position) <= shootRange)
    //    //{
    //    //    //float fireAngle = Mathf.Atan2((PlayerController._playerControllerInstance.transform.position.y - transform.position.y),
    //    //    //(PlayerController._playerControllerInstance.transform.position.x - transform.position.x)) * Mathf.Rad2Deg;

    //    //    //fireDirection.rotation = Quaternion.Euler(0, 0, fireAngle);


    //    //    fireCounter -= Time.deltaTime;

    //    //    if (fireCounter <= 0)
    //    //    {
    //    //        fireCounter = fireRate;

    //    //        Instantiate(enemyBullet, weaponLauncher.position, weaponLauncher.rotation);
    //    //    }
    //    //}
    //}


    // damage enemy
    public void DamageEnemy(int damage)
    {
        enemyHealth -= damage;


        if (enemyHealth <= 0)
        {
            Destroy(gameObject);

    //        Instantiate(enemyDeathParticles, transform.position, transform.rotation);
        }
    }


} // end of class
