using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;


public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    
    public GameObject cancelButton;
    public GameObject battleButton;

    private void Awake()
    {
        lobby = this; //Creates the singelton, lives within the main menu scene
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connects to the photon master server.
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server!");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);
    }

    public void OnBattleButtonClicked()
    {
        Debug.Log("Join button was clicked");
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a random game but failed. There must be no open games available");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Trying to create a new room");
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = 2};
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
        GameSetup.spawnCounter++; //yes!!!!! SER TILL ATT DE BLIR OLIKA SPAWNS.
        
    }
    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed, there must already be a room with the same name");
        CreateRoom();
    }

    public void OnCancelButtonClicked()
    {
        Debug.Log("The cancel button was clicked");
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

}
