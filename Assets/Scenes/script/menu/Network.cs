using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Network : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    public  void Connection(string name)
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LocalPlayer.NickName = name;
    }

    #region Pun Callbacks

    public override void OnConnectedToMaster()
    {
        // Try to join a random room
        Debug.Log("Connection OK");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        // Try to join a random room
        Debug.Log("Lobby OK");
        RoomOptions roomOptions = new RoomOptions() { IsVisible = false, IsOpen = true, MaxPlayers = 10 };
        PhotonNetwork.JoinOrCreateRoom("roomName", roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room OK = " + PhotonNetwork.CurrentRoom);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined OK");
        Debug.Log("Room OK = " + PhotonNetwork.CurrentRoom);
        StartGame();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Un nouveau joueur vient de se connecter : " + newPlayer.NickName);
        Debug.Log("Il y a " + PhotonNetwork.CurrentRoom.PlayerCount + " joueurs dans la room");
        StartGame();
    }
    
    #endregion

    private void StartGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("Jeux"); 
        }
    }


}
