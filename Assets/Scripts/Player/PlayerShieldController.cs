
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

public class PlayerShieldController : MonoBehaviour
{
    //public static PlayerShieldController _playerShieldsControllerInstance;



    //// player's maximum health
    //private int playerMaximumShields;

    //// player's current health
    //[SerializeField] public float playerCurrentShields;



    //private void Awake()
    //{
    //    _playerShieldsControllerInstance = this;
    //}


    //private void Start()
    //{
    //    Initialise();
    //}


    //private void Initialise()
    //{
    //    playerMaximumShields = 100;

    //    playerCurrentShields = 0;

    //    HudController._hudControllerInstance.shieldsSlider.maxValue = playerMaximumShields;

    //    UpdateShieldsValueText();
    //}


    //public void DamageShields(float damage)
    //{
    //    playerCurrentShields -= damage;

    //    UpdateShieldsValueText();
    //}


    //public void RaiseShields(int shields)
    //{
    //    playerCurrentShields += shields;

    //    if (playerCurrentShields > playerMaximumShields)
    //    {
    //        playerCurrentShields = playerMaximumShields;
    //    }

    //    UpdateShieldsValueText();
    //}


    //private void UpdateShieldsValueText()
    //{
    //    float shieldsPercentage = (playerCurrentShields / playerMaximumShields) * 100;

    //    HudController._hudControllerInstance.shieldsValueText.text = ((int)shieldsPercentage).ToString() + "%";

    //    HudController._hudControllerInstance.shieldsSlider.value = playerCurrentShields;
    //}


} // end of class
