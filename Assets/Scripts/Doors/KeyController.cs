
using System;
using System.Collections.Generic;
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
// modified 2020-08-19
//

public class KeyController : MonoBehaviour
{
    public static KeyController _keyControllerInstance;


    // player's maximum keys
    private int maximumKeys;

    // player's starting keys
    private int startingKeys;
    
    
    public event EventHandler OnKeysChanged;

    private List<SecurityKeyType.SecurityKeys> keyList;

    // player's current key count
    private int securityKey01;
    private int securityKey02;
    private int securityKey03;
    private int securityKey04;
    private int securityKey05;
    private int securityKey06;
    private int securityKey07;
    private int securityKey08;



    private void Awake()
    {
        _keyControllerInstance = this;

        keyList = new List<SecurityKeyType.SecurityKeys>();
    }


    private void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        maximumKeys = 16;

        startingKeys = 8;

        InitialiseKeys(startingKeys, "Security Key 01");
        InitialiseKeys(startingKeys, "Security Key 02");
        InitialiseKeys(startingKeys, "Security Key 03");
        InitialiseKeys(startingKeys, "Security Key 04");
        InitialiseKeys(startingKeys, "Security Key 05");
        InitialiseKeys(startingKeys, "Security Key 06");
        InitialiseKeys(startingKeys, "Security Key 07");
        InitialiseKeys(startingKeys, "Security Key 08");

        UpdateKeyValueText();
    }


    private void InitialiseKeys(int numberOfKeys, string securityKey)
    {
        for (int keyInventory = 0; keyInventory < numberOfKeys; keyInventory++)
        {
            switch (securityKey)
            {
                case "Security Key 01": AddKey(securityKey, SecurityKeyType.SecurityKeys.BlackSecurityKey01); break;

                case "Security Key 02": AddKey(securityKey, SecurityKeyType.SecurityKeys.OrangeSecurityKey02); break;

                case "Security Key 03": AddKey(securityKey, SecurityKeyType.SecurityKeys.CyanSecurityKey03); break;

                case "Security Key 04": AddKey(securityKey, SecurityKeyType.SecurityKeys.PurpleSecurityKey04); break;

                case "Security Key 05": AddKey(securityKey, SecurityKeyType.SecurityKeys.YellowSecurityKey05); break;

                case "Security Key 06": AddKey(securityKey, SecurityKeyType.SecurityKeys.BlueSecurityKey06); break;

                case "Security Key 07": AddKey(securityKey, SecurityKeyType.SecurityKeys.GreenSecurityKey07); break;

                case "Security Key 08": AddKey(securityKey, SecurityKeyType.SecurityKeys.RedSecurityKey08); break;
            }
        }
    }


    public List<SecurityKeyType.SecurityKeys> GetKeyList()
    {
        return keyList;
    }


    public bool ContainsKey(SecurityKeyType.SecurityKeys keyType)
    {
        return keyList.Contains(keyType);
    }


    public void UseKey(string key, SecurityKeyType.SecurityKeys securityKey)
    {
        switch (key)
        {
            case "Security Key 01": securityKey01--; break;

            case "Security Key 02": securityKey02--; break;

            case "Security Key 03": securityKey03--; break;

            case "Security Key 04": securityKey04--; break;

            case "Security Key 05": securityKey05--; break;

            case "Security Key 06": securityKey06--; break;

            case "Security Key 07": securityKey07--; break;

            case "Security Key 08": securityKey08--; break;
        }


        if (securityKey01 < 0) { securityKey01 = 0; } else { RemoveKey(securityKey); }

        if (securityKey02 < 0) { securityKey02 = 0; } else { RemoveKey(securityKey); }

        if (securityKey03 < 0) { securityKey03 = 0; } else { RemoveKey(securityKey); }

        if (securityKey04 < 0) { securityKey04 = 0; } else { RemoveKey(securityKey); }

        if (securityKey05 < 0) { securityKey05 = 0; } else { RemoveKey(securityKey); }

        if (securityKey06 < 0) { securityKey06 = 0; } else { RemoveKey(securityKey); }

        if (securityKey07 < 0) { securityKey07 = 0; } else { RemoveKey(securityKey); }

        if (securityKey08 < 0) { securityKey08 = 0; } else { RemoveKey(securityKey); }

        UpdateKeyValueText();
    }


    public void AddKey(string key, SecurityKeyType.SecurityKeys securityKey)
    {
        switch (key)
        {
            case "Security Key 01": securityKey01++; break;

            case "Security Key 02": securityKey02++; break;

            case "Security Key 03": securityKey03++; break;

            case "Security Key 04": securityKey04++; break;

            case "Security Key 05": securityKey05++; break;

            case "Security Key 06": securityKey06++; break;

            case "Security Key 07": securityKey07++; break;

            case "Security Key 08": securityKey08++; break;
        }

        

        if (securityKey01 > maximumKeys) { securityKey01 = maximumKeys; } else { AddKeyToInventory(securityKey); }

        if (securityKey02 > maximumKeys) { securityKey02 = maximumKeys; } else { AddKeyToInventory(securityKey); }

        if (securityKey03 > maximumKeys) { securityKey03 = maximumKeys; } else { AddKeyToInventory(securityKey); }

        if (securityKey04 > maximumKeys) { securityKey04 = maximumKeys; } else { AddKeyToInventory(securityKey); }

        if (securityKey05 > maximumKeys) { securityKey05 = maximumKeys; } else { AddKeyToInventory(securityKey); }

        if (securityKey06 > maximumKeys) { securityKey06 = maximumKeys; } else { AddKeyToInventory(securityKey); }

        if (securityKey07 > maximumKeys) { securityKey07 = maximumKeys; } else { AddKeyToInventory(securityKey); }

        if (securityKey08 > maximumKeys) { securityKey08 = maximumKeys; } else { AddKeyToInventory(securityKey); }

        UpdateKeyValueText();
    }


    private void AddKeyToInventory(SecurityKeyType.SecurityKeys securityKey)
    {
        keyList.Add(securityKey);

        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }


    private void RemoveKey(SecurityKeyType.SecurityKeys keyType)
    {
        keyList.Remove(keyType);

        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }


    private void UpdateKeyValueText()
    {
        HudController._hudControllerInstance.key1ValueText.text = FormatKeys(securityKey01);

        HudController._hudControllerInstance.key2ValueText.text = FormatKeys(securityKey02);

        HudController._hudControllerInstance.key3ValueText.text = FormatKeys(securityKey03);

        HudController._hudControllerInstance.key4ValueText.text = FormatKeys(securityKey04);

        HudController._hudControllerInstance.key5ValueText.text = FormatKeys(securityKey05);

        HudController._hudControllerInstance.key6ValueText.text = FormatKeys(securityKey06);

        HudController._hudControllerInstance.key7ValueText.text = FormatKeys(securityKey07);

        HudController._hudControllerInstance.key8ValueText.text = FormatKeys(securityKey08);
    }


    private string FormatKeys(int key)
    {
        string keyText = "";


        if (key < 0) { key = 0; }

        if (key == 0 || key >= 1 && key <= 9) { keyText = "0"; }

        if (key >= 10 && key <= 99) { keyText = ""; }


        keyText += key.ToString();
        
        return keyText;
    }


} // end of class
