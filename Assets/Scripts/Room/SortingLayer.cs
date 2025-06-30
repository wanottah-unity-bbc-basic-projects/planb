
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Plan B Reloaded v0.0.0
/// Port of 'Plan B' for the BBC Model B by Andrew Foord - Copyright 1987
/// SortingLayer.cs
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 20/03/2019
/// </summary>

//
// modified 2020-08-09
//

public class SortingLayer : MonoBehaviour
{
    // the name of the layer
    public string layerName;

    // the name of the sorting layer
    public string sortingLayer;

    // the order position of the layer
    public int orderInLayer;


    void Start()
    {
        // get each of the transforms that are a child of the game object the script is attached to
        foreach (Transform transformChild in GetComponentsInChildren<Transform>())
        {
            // Set the transform layer name to the name specified
            transformChild.gameObject.layer = LayerMask.NameToLayer(layerName);
        }


        // get each of the sprites that are a child of the game object the script is attached to
        foreach (SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            // set the sprite sorting layer name to the name specified
            spriteRenderer.GetComponent<Renderer>().sortingLayerName = sortingLayer;

            // set the layer's order position
            spriteRenderer.GetComponent<Renderer>().sortingOrder = orderInLayer;
        }

    }


} // end of class
