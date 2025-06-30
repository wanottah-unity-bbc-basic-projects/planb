
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Plan B Reloaded v0.0.0
/// Port of 'Plan B' for the BBC Model B by Andrew Foord - Copyright 1987
/// BackgroundTiles.cs
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 20/03/2019
/// Modifed: 15/01/2020
/// </summary>


namespace Wanottah
{
    public class BackgroundTiles : MonoBehaviour
    {
        // Array of background tiles
        public GameObject[] backgroundTiles;

        // Start position of background tiles
        public Vector3 tileStartPosition;

        // Size of tiles
        Vector2 tileSize;

        // Width of bachground tile grid
        public int backgroundWidth;

        // Height of background tile grid
        public int backgroundHeight;



        // Start is called before the first frame update
        private void Awake()
        {
            // Get tile size
            tileSize = backgroundTiles[0].GetComponent<Renderer>().bounds.size;


            // Loop through number of tile rows
            for (int tileColumns = 0; tileColumns < backgroundHeight; tileColumns++)
            {
                //Debug.Log(tileRows);
                // Loop through number of tile columns
                for (int tileRows = 0; tileRows < backgroundWidth; tileRows++)
                {
                    //Debug.Log(tileColumns);
                    // Select a random tile from the array
                    int randomTile = Random.Range(0, backgroundTiles.Length);

                    // Place background tile in scene
                    GameObject backgroundTile = Instantiate(backgroundTiles[randomTile],
                                                new Vector3(tileStartPosition.x + (tileRows * tileSize.x),
                                                tileStartPosition.y + (tileColumns * tileSize.y)),
                                                Quaternion.identity) as GameObject;

                    // Set the background tiles as children of the 'BackgroundTiles' game object
                    backgroundTile.transform.parent = GameObject.Find("Background Tiles").transform;
                }
            }
        }


    } // end of class


} // end of namespace
