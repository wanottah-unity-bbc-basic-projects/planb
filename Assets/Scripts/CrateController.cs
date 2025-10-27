
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

public class CrateController : MonoBehaviour
{
    // reference to destroyed particle effect
    public GameObject destroyedParticles;


    public bool shouldDropItem;

    public GameObject[] droppableItems;

    public float dropPercentage;

    // score value
    public int cratePoints;



    // initialise health bonus and score
    private void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        cratePoints = 5;
    }


    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.CompareTag("Player"))
        {
            ScoreController._scoreControllerInstance.AddPoints(cratePoints);

            Destroy(gameObject);

            Instantiate(destroyedParticles, transform.position, transform.rotation);


            DropItem();
        }

        if (collidingObject.CompareTag("Player Bullet"))
        {
            Destroy(gameObject);

            Instantiate(destroyedParticles, transform.position, transform.rotation);
        }
    }


    private void DropItem()
    {
        if (shouldDropItem)
        {
            float dropChance = Random.Range(0f, 100f);

            if (dropChance < dropPercentage)
            {
                // select random item to drop
                int randomItem = Random.Range(0, droppableItems.Length);

                Instantiate(droppableItems[randomItem], transform.position, transform.rotation);
            }
        }
    }


} // end of class
