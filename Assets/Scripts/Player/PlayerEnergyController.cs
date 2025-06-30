
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Plan B 2020 Mk i
/// Port of Plan B for the BBC Model B 
/// by Andrew Foord - Copyright 1987
/// PlayerHealthController.cs
/// Adapted from 'Learn to Code By Making a 2D Platformer in Unity'
/// by James Doyle
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 22/03/2019
/// </summary>

//
// modified 2020-08-10
//

public class PlayerEnergyController : MonoBehaviour
{
    public static PlayerEnergyController _playerEnergyControllerInstance;


    // reference to game over ui
    [SerializeField] private GameObject gameOverUI;

    // reference to destroyed particle effect
    public GameObject destroyedParticles;

    // reference to player transform
    public Transform player;



    // player's maximum health
    private int playerMaximumEnergy;

    // player's current health
    [SerializeField] private float playerCurrentEnergy;



    private void Awake()
    {
        _playerEnergyControllerInstance = this;
    }



    private void Start()
    {
        Initialise();
    }



    private void Initialise()
    {
        playerMaximumEnergy = 100;

        playerCurrentEnergy = playerMaximumEnergy;

        HudController._hudControllerInstance.energySlider.maxValue = playerMaximumEnergy;

        UpdateEnergyValueText();
    }


    public void DamagePlayer(float damage)
    {
        if (PlayerShieldController._playerShieldsControllerInstance.playerCurrentShields > 0)
        {
            PlayerShieldController._playerShieldsControllerInstance.DamageShields(damage);
        }

        else
        {
            playerCurrentEnergy -= damage;

            UpdateEnergyValueText();
        }
    }


    public void HealPlayer(int energy)
    {
        playerCurrentEnergy += energy;

        if (playerCurrentEnergy > playerMaximumEnergy)
        {
            playerCurrentEnergy = playerMaximumEnergy;
        }

        UpdateEnergyValueText();
    }


    private void UpdateEnergyValueText()
    {
        float energyPercentage = (playerCurrentEnergy / playerMaximumEnergy) * 100;

        HudController._hudControllerInstance.energyValueText.text = ((int)energyPercentage).ToString() + "%";

        HudController._hudControllerInstance.energySlider.value = playerCurrentEnergy;


        // check if player is dead
        if (playerCurrentEnergy <= 0)
        {
            // disable player controller
            PlayerController._playerControllerInstance.gameObject.SetActive(false);

            Instantiate(destroyedParticles, player.position, player.rotation);

            // Display Game Over UI
            //gameOverUI.gameObject.SetActive(true);
        }
    }


} // end of class
