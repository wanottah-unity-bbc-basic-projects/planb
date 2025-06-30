
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Plan B Reloaded v0.0.0
/// Port of 'Plan B' for the BBC Model B by Andrew Foord - Copyright 1987
/// SpannerPickup.cs
/// Adapted from 'Learn to Code By Making a 2D Platformer in Unity'
/// by James Doyle
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 23/03/2019
/// </summary>

//
// modified 2020-08-10
//

public class CoinPickup : MonoBehaviour
{
    // reference to destroyed particle effect
    public GameObject destroyedParticles;


    // energy value
    public int coins;

    // score value
    public int coinsPickupPoints;

    public float collectDelay;

    private bool CanBeCollected;



    // initialise health bonus and score
    private void Start()
    {
        Initialise();
    }


    private void Update()
    {
        WaitToCollect();
    }


    private void Initialise()
    {
        coins = 1;

        coinsPickupPoints = 5;

        collectDelay = 15f;

        CanBeCollected = false;
    }


    private void WaitToCollect()
    {
        if (collectDelay > 0)
        {
            collectDelay -= Time.deltaTime;
        }

        if (collectDelay <= 0)
        {
            CanBeCollected = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (CanBeCollected)
        {
            if (collidingObject.CompareTag("Player"))
            {
                PlayerCoinController._playerCoinControllerInstance.AddCoins(coins);

                ScoreController._scoreControllerInstance.AddPoints(coinsPickupPoints);

                Instantiate(destroyedParticles, transform.position, transform.rotation);

                Destroy(gameObject);
            }
        }
    }


} // end of class
