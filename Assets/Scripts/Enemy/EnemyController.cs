
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Plan B Reloaded v0.0.0
/// Port of 'Plan B' for the BBC Model B by Andrew Foord - Copyright 1987
/// DoorController.cs
/// Adapted from 'Learn to Code By Making a 2D Platformer in Unity'
/// by James Doyle
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 20/04/2019
/// </summary>

//
// modified 2020-08-07
//

public class EnemyController : MonoBehaviour
{
    // reference to the enemy's 'Rigidbody' component
    private Rigidbody2D enemyRigidbody;

    // reference to the enemy's 'Animator' component
    public Animator enemyAnimator;

    // reference to enemy's sprite renderer component
    public SpriteRenderer enemySprite;

    // reference to enemy death particle effect
    public GameObject enemyDeathParticles;

    public GameObject enemyBullet;

    public Transform weaponLauncher;


    public int enemyHealth;

    // enemy movement speed
    private float enemySpeed;

    // player damage
    public static int playerDamage;

    // Delay for enemy movement
    //private float movementDelayTime;
    //public float delayTime;

    // Enemy patrol movement
    //private Vector3 moveVector;


    #region ATTACK

    public bool shouldAttack;

    public float attackRange;

    private Vector3 attackDirection;

    #endregion


    #region PATROL

    public bool shouldRandomPatrol;

    public float randomPatrolLength;

    public float randomPatrolPauseLength;

    private float randomPatrolCounter;

    private float randomPatrolPauseCounter;

    private Vector3 randomPatrolDirection;

    #endregion


    #region SHOOT

    public bool shouldShoot;

    public float shootRange;

    public float fireRate;

    private float fireCounter;

    #endregion


 
    void Start()
    {
        Initialise();
    }


     void Update()
    {
        EnemyState();
    }


    private void Initialise()
    {
        // get reference to player's rigidbody component
        enemyRigidbody = GetComponent<Rigidbody2D>();

        //enemyHealth = 100;

        // set enemy's horizontal and vertical speed
        enemySpeed = 8f;

        // player damage
        playerDamage = 1;


        // initalise random patrol
        if (shouldRandomPatrol)
        {
            randomPatrolPauseCounter = Random.Range(randomPatrolPauseLength * .75f, randomPatrolPauseLength * 1.25f);
        }
    }


    private void EnemyState()
    {
        if (enemySprite.isVisible)
        {
            if (shouldAttack)
            {
                AttackPlayer();
            }

            if (shouldRandomPatrol)
            {
                RandomPatrol();
            }

            if (shouldShoot)
            {
                ShootPlayer();
            }

            MoveEnemy();
        }
    }



    private void AttackPlayer()
    {
        attackDirection = Vector3.zero;

        // if player is in range
        if (Vector3.Distance(transform.position, PlayerController._playerControllerInstance.transform.position) <= attackRange)
        {
            // set attack direction toward player
            attackDirection = PlayerController._playerControllerInstance.transform.position - transform.position;
        }

        // otherwise . . .
        else
        {
            RandomPatrol();
        }
    }


    private void RandomPatrol()
    {
        if (shouldRandomPatrol)
        {
            if (randomPatrolCounter > 0)
            {
                randomPatrolCounter -= Time.deltaTime;

                // random patrol
                attackDirection = randomPatrolDirection;

                if (randomPatrolCounter <= 0)
                {
                    randomPatrolPauseCounter = Random.Range(randomPatrolPauseLength * .75f, randomPatrolPauseLength * 1.25f);
                }
            }

            if (randomPatrolPauseCounter > 0)
            {
                randomPatrolPauseCounter -= Time.deltaTime;

                if (randomPatrolPauseCounter <= 0)
                {
                    randomPatrolCounter = Random.Range(randomPatrolLength * .75f, randomPatrolLength * 1.25f);

                    SelectRandomPatrolDirection();
                }
            }
        }
    }


    // select a random patrol direction
    private void SelectRandomPatrolDirection()
    {
        randomPatrolDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }


    // Move enemy
    private void MoveEnemy()
    {
        attackDirection.Normalize();

        enemyRigidbody.linearVelocity = attackDirection * enemySpeed;
    }


    private void ShootPlayer()
    {
        // and player is within firing range
        if (Vector3.Distance(transform.position, PlayerController._playerControllerInstance.transform.position) <= shootRange)
        {
            //float fireAngle = Mathf.Atan2((PlayerController._playerControllerInstance.transform.position.y - transform.position.y),
            //(PlayerController._playerControllerInstance.transform.position.x - transform.position.x)) * Mathf.Rad2Deg;

            //fireDirection.rotation = Quaternion.Euler(0, 0, fireAngle);


            fireCounter -= Time.deltaTime;

            if (fireCounter <= 0)
            {
                fireCounter = fireRate;

                Instantiate(enemyBullet, weaponLauncher.position, weaponLauncher.rotation);
            }
        }
    }


    public void DamageEnemy(int damage)
    {
        enemyHealth -= damage;


        if (enemyHealth <= 0)
        {
            Destroy(gameObject);

            Instantiate(enemyDeathParticles, transform.position, transform.rotation);
        }
    }


} // end of class
