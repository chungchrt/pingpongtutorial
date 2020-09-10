using JetBrains.Annotations;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class Mainmenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject findOpponentPanel = null;
    [SerializeField] private GameObject waitingStatusPanel = null;
    [SerializeField] private TextMeshProUGUI waitingStatusText = null;

    private bool isConnecting = false;
    private const string GameVersion = "0.1"; //Pascal naming for const 
    private const int MaxPlayersPerRoom = 2; //!!!!!!!!!!!!!!!! 1 for single player , ,,

    private void Awake() => PhotonNetwork.AutomaticallySyncScene = true; // sync the scene between the players

    public void FindOpponent()
    {
        isConnecting = true; // when finding oppoenent its connected
        findOpponentPanel.SetActive(false); //close the find opponent panel
        waitingStatusPanel.SetActive(true);//enable waiting status panel
        waitingStatusText.text = "Searching......";//change the text to seraching..\

        if (PhotonNetwork.IsConnected) //if its connected (PN api)
        {
            PhotonNetwork.JoinRandomRoom(); //Joing a room PN function
        }
        else //if its not connected , assign gameversion then connect
        {
            PhotonNetwork.GameVersion = GameVersion; //Photon's GameVersion assign to Gameversion
            PhotonNetwork.ConnectUsingSettings(); //connect with photon setting
        }
    }
        
        public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        waitingStatusPanel.SetActive(false);
        findOpponentPanel.SetActive(true);

        Debug.Log($"Disconnected due to : {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No clients are waiting for an opponent , creating a new room"); //If join random room failed > create a room

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom }); //null = name , roomoptions list > set the max player
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Client successfully joined a room");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount; // Count the player
        if(playerCount != MaxPlayersPerRoom) // if the player count is not equal to Maxplayerperroom 
        {
            waitingStatusText.text = "Waiting for Opponent";
            Debug.Log("Player is waiting for an oppoent");
        }
        else // player count = MaxPlayerPerRoom
        {
            waitingStatusText.text = "Opponent Found";
            Debug.Log("Matching is ready to begin");
            if (MaxPlayersPerRoom == 1)
            { //single player setting , for debug
                PhotonNetwork.LoadLevel("photon_pingpong"); // Delete for multiplayer
            }

        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false; //if playercount == MaxPlayer then close the room 
            waitingStatusText.text = "Opponent Found";
            Debug.Log("Match is ready to begin");

            PhotonNetwork.LoadLevel("photon_pingpong");
        }
    }
}

