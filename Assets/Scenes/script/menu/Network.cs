using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Network : MonoBehaviourPunCallbacks
{
    private string RoomName="default-room";

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    public  void Connection(string RoomName,string PlayerName)
    {
        this.RoomName = RoomName;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LocalPlayer.NickName = PlayerName;
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
        PhotonNetwork.JoinOrCreateRoom(RoomName, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room OK = " + PhotonNetwork.CurrentRoom);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined OK");
        Debug.Log("Room OK = " + PhotonNetwork.CurrentRoom);
        JoinTheRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Un nouveau joueur vient de se connecter : " + newPlayer.NickName);
        Debug.Log("Il y a " + PhotonNetwork.CurrentRoom.PlayerCount + " joueurs dans la room");
        JoinTheRoom();
    }
    
    #endregion

    private void JoinTheRoom()
    {
        SceneManager.LoadScene("Room");
    }

    [PunRPC]
    public void startGame()
    {
        SceneManager.LoadScene("Jeux");
    }
    public int GetNbPlayer()
    {
        return PhotonNetwork.CurrentRoom.PlayerCount;
    }
}
