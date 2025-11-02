
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

public class PlayerCoinController : MonoBehaviour
{
    //public static PlayerCoinController _playerCoinControllerInstance;



    //// player's current health
    //[SerializeField] private int playerCurrentCoins;



    //private void Awake()
    //{
    //    _playerCoinControllerInstance = this;
    //}


    //private void Start()
    //{
    //    Initialise();
    //}


    //private void Initialise()
    //{
    //    playerCurrentCoins = 0;

    //    UpdateCoinValueText();
    //}


    //public void UseCoins(int coins)
    //{
    //    if (PlayerShieldController._playerShieldsControllerInstance.playerCurrentShields > 0)
    //    {
    //        PlayerShieldController._playerShieldsControllerInstance.DamageShields(coins);
    //    }

    //    else
    //    {
    //        playerCurrentCoins -= coins;

    //        UpdateCoinValueText();
    //    }
    //}


    //public void AddCoins(int coins)
    //{
    //    playerCurrentCoins += coins;

    //    UpdateCoinValueText();
    //}


    //private void UpdateCoinValueText()
    //{
    //    HudController._hudControllerInstance.coinsValueText.text = playerCurrentCoins.ToString();
    //}


} // end of class
