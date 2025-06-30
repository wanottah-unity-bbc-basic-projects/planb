
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
// modified 2020-08-18
//

public class KeyPickup : MonoBehaviour
{
    // reference to destroyed particle effect
    public GameObject destroyedParticles;


    // score value
    public int keysPickupPoints;

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
        keysPickupPoints = 5;

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
                SecurityKeyType securityKey = GetComponent<SecurityKeyType>();

                if (gameObject.CompareTag("Security Key 01")) { KeyController._keyControllerInstance.AddKey("Security Key 01", securityKey.GetSecurityKey()); }

                if (gameObject.CompareTag("Security Key 02")) { KeyController._keyControllerInstance.AddKey("Security Key 02", securityKey.GetSecurityKey()); }

                if (gameObject.CompareTag("Security Key 03")) { KeyController._keyControllerInstance.AddKey("Security Key 03", securityKey.GetSecurityKey()); }

                if (gameObject.CompareTag("Security Key 04")) { KeyController._keyControllerInstance.AddKey("Security Key 04", securityKey.GetSecurityKey()); }

                if (gameObject.CompareTag("Security Key 05")) { KeyController._keyControllerInstance.AddKey("Security Key 05", securityKey.GetSecurityKey()); }

                if (gameObject.CompareTag("Security Key 06")) { KeyController._keyControllerInstance.AddKey("Security Key 06", securityKey.GetSecurityKey()); }

                if (gameObject.CompareTag("Security Key 07")) { KeyController._keyControllerInstance.AddKey("Security Key 07", securityKey.GetSecurityKey()); }

                if (gameObject.CompareTag("Security Key 08")) { KeyController._keyControllerInstance.AddKey("Security Key 08", securityKey.GetSecurityKey()); }


                ScoreController._scoreControllerInstance.AddPoints(keysPickupPoints);

                Instantiate(destroyedParticles, transform.position, transform.rotation);

                Destroy(gameObject);
            }
        }
    }


} // end of class
