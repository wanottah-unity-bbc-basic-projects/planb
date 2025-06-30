
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Plan B Reloaded v0.0.0
/// Port of 'Plan B' for the BBC Model B by Andrew Foord - Copyright 1987
/// HudController.cs
/// Adapted from 'Learn to Code By Making a 2D Platformer in Unity'
/// by James Doyle
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 09/04/2019
/// </summary>

//
// modified 2020-08-09
//

public class HudController : MonoBehaviour
{
    public static HudController _hudControllerInstance;



    // reference to hud ui panel
    //public GameObject hudUI;

    // reference to score ui
    //public GameObject scoreUI;
    public Text highScoreText;
    public Text highScoreValueText;
    public Text scoreValueText;

    // reference to coins
    public Text coinsValueText;

    // reference to key ui
    public Text key1ValueText;
    public Text key2ValueText;
    public Text key3ValueText;
    public Text key4ValueText;
    public Text key5ValueText;
    public Text key6ValueText;
    public Text key7ValueText;
    public Text key8ValueText;

    // reference to room ui
    //public GameObject roomUI;
    //public Text roomText;

    // reference to health ui
    //public GameObject healthUI;
    public Slider energySlider;
    public Text energyValueText;

    // reference to shields ui
    //public GameObject shieldsUI;
    public Slider shieldsSlider;
    public Text shieldsValueText;

    // reference to fuel ui
    //public GameObject fuelUI;
    public Slider fuelSlider;
    public Text fuelValueText;

    // reference to ammo ui
    //public GameObject ammoUI;
    public Slider weaponSlider;
    public Text weaponTemparatureValueText;
    public Slider ammoSlider;
    public Text ammoValueText;

    // reference to timer ui
    //public GameObject timerUI;
    //public Text timerText;

    // reference to keys ui
    //public GameObject keysUI;
    //public Text securityKey1Text;
    //public Text securityKey2Text;
    //public Text securityKey3Text;
    //public Text securityKey4Text;
    //public Text securityKey5Text;
    //public Text securityKey6Text;
    //public Text securityKey7Text;
    //public Text securityKey8Text;



    private void Awake()
    {
        _hudControllerInstance = this;
    }


    public void EnableHud()
    {
        /*hudUI.SetActive(true);

        scoreUI.SetActive(true);

        roomUI.SetActive(true);

        ammoUI.SetActive(true);

        healthUI.SetActive(true);

        fuelUI.SetActive(true);

        timerUI.SetActive(true);

        shieldsUI.SetActive(true);

        keysUI.SetActive(true);*/
    }


    public void DisableHud()
    {
        /*hudUI.SetActive(false);

        scoreUI.SetActive(false);

        roomUI.SetActive(false);

        ammoUI.SetActive(false);

        healthUI.SetActive(false);

        fuelUI.SetActive(false);

        timerUI.SetActive(false);

        shieldsUI.SetActive(false);

        keysUI.SetActive(false);*/
    }



} // End of class
