
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// modified 2020-08-10
//


public class FuelPickup : MonoBehaviour
{
    // reference to destroyed particle effect
    public GameObject destroyedParticles;


    // fuel value
    public int fuel;

    // score value
    public int fuelPickupPoints;

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
        fuel = 250;

        fuelPickupPoints = 5;

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
                PlayerFuelController._playerFuelControllerInstance.Refuel(fuel);

                ScoreController._scoreControllerInstance.AddPoints(fuelPickupPoints);

                Instantiate(destroyedParticles, transform.position, transform.rotation);

                Destroy(gameObject);
            }
        }
    }


} // end of class
