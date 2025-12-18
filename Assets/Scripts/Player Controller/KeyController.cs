
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.18
//

public class KeyController : MonoBehaviour
{
    public static KeyController keyController;


    //// reference to game over ui
    //[SerializeField] private GameObject gameOverUI;

    //// reference to destroyed particle effect
    //public GameObject destroyedParticles;

    //// reference to player transform
    //public Transform player;



    // player's maximum health
    private int playerMaximumEnergy;

    // player's current health
    private float playerCurrentEnergy;



    private void Awake()
    {
        keyController = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

    }


} // end of class
