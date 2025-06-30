
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// modified 2020-08-10
//

public class AmmoPickup : MonoBehaviour
{
    // reference to destroyed particle effect
    public GameObject destroyedParticles;


    // ammo value
    public int ammo;

    // score value
    public int ammoPickupPoints;

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
        ammo = 50;

        ammoPickupPoints = 5;

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
                PlayerWeaponController._playerWeaponControllerInstance.ReloadAmmo(ammo);

                ScoreController._scoreControllerInstance.AddPoints(ammoPickupPoints);

                Instantiate(destroyedParticles, transform.position, transform.rotation);

                Destroy(gameObject);
            }
        }
    }


} // end of class
