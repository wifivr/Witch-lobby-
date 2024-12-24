using BepInEx;
using UnityEngine;
using Photon.Pun;
using System;

[BepInPlugin("com.yourname.gorillatag.lobbylogger", "Lobby Logger", "1.0.0")]
public class LobbyLogger : BaseUnityPlugin
{
    private GUIStyle guiStyle = new GUIStyle(); // Style for the text
    private string currentLobbyCode = "Not connected"; // Store the current lobby code

    void OnEnable()
    {
        // Hooking the event for when Gorilla Tag is loaded
        Utilla.Events.GameInitialized += OnGameInitialized;
    }

    void OnDisable()
    {
        // Unhooking the event
        Utilla.Events.GameInitialized -= OnGameInitialized;
    }

    void OnGameInitialized(object sender, EventArgs e)
    {
        // Additional initialization if needed
    }

    void Update()
    {
        // Update the current lobby code if connected
        if (PhotonNetwork.InRoom)
        {
            currentLobbyCode = PhotonNetwork.CurrentRoom.Name;
        }
        else
        {
            currentLobbyCode = "Not connected";
        }
    }

    void OnGUI()
    {
        guiStyle.fontSize = 24; // Change the font size
        guiStyle.normal.textColor = Color.white; // Change the font color

        // Display the current lobby code on the screen
        GUI.Label(new Rect(10, 10, 300, 50), $"Room Code: {currentLobbyCode}", guiStyle);
    }
}
