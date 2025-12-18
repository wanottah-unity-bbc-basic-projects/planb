
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.18
//

public class PlayerEnergyController : MonoBehaviour
{
    public static PlayerEnergyController playerEnergyController;


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
        playerEnergyController = this;
    }


    private void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        playerMaximumEnergy = 1; // 100;

        playerCurrentEnergy = playerMaximumEnergy;

        UIController.uiController.energySlider.maxValue = playerMaximumEnergy;

        UpdateEnergySlider();
    }


    public void DamagePlayer()
    {
        //    if (PlayerShieldController._playerShieldsControllerInstance.playerCurrentShields > 0)
        //    {
        //        PlayerShieldController._playerShieldsControllerInstance.DamageShields(damage);
        //    }

        //    else
        //    {
        //        playerCurrentEnergy -= damage;

        //        UpdateEnergyValueText();
        //    }


        playerCurrentEnergy--;

        UpdateEnergySlider();

            // check if player is dead
        if (playerCurrentEnergy <= 0)
        {
            
                    // disable player controller
            PlayerController.playerController.gameObject.SetActive(false);

            //        Instantiate(destroyedParticles, player.position, player.rotation);

            //        // Display Game Over UI
            //        //gameOverUI.gameObject.SetActive(true);
        }
    }


    public void HealPlayer(int energy)
    {
        playerCurrentEnergy += energy;

        if (playerCurrentEnergy > playerMaximumEnergy)
        {
            playerCurrentEnergy = playerMaximumEnergy;
        }

        UpdateEnergySlider();
    }


    private void UpdateEnergySlider()
    {
        float energyPercentage = (playerCurrentEnergy / playerMaximumEnergy) * 100;

        UIController.uiController.energyText.text = ((int)energyPercentage).ToString() + "%";

        UIController.uiController.energySlider.value = playerCurrentEnergy;
    }


} // end of class
