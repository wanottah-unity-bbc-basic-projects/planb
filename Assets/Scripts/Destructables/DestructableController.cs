
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Plan B 2020 Mk i
/// Port of 'Plan B' for the BBC Model B
/// by Andrew Foord - Copyright 1987
/// CrateController.cs
/// Adapted from 'Learn to Code By Making a 2D Platformer in Unity'
/// by James Doyle
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 26/03/2019
/// </summary>

//
// modified 2020-08-10
//

public class DestructableController : MonoBehaviour
{
    // reference to destroyed particle effect
    public GameObject destroyedParticles;



    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.CompareTag("Player Bullet"))
        {
            Instantiate(destroyedParticles, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }


} // end of class
