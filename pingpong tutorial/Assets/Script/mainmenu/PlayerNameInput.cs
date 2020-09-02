using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private InputField nameInputField = null; //declare nameinput
    [SerializeField] private Button continueButton = null; // declare button 

    private const string PlayerPrefsNameKey = "PlayerName"; // constant name => second login = same name . Default：player name.

    private void Start() => SetUpInputField();

    private void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; } // If PlayerPrefs(local storage ) do not have name => return

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey); // if have name, get the local storage name ( saved name)

        nameInputField.text = defaultName; //set inputfield to player name 

        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name)
    {
        continueButton.interactable = !string.IsNullOrEmpty(name); //the button is enable if the name is not Empty
    }

    public void SavePlayerName()
    {
        String playerName = nameInputField.text; //get playername from text

        PhotonNetwork.NickName = playerName; // photon name = name

        PlayerPrefs.SetString(PlayerPrefsNameKey, playerName); // save name to local storage
    }
}
