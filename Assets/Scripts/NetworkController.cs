using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NetworkController : MonoBehaviourPunCallbacks
{
    public Text txtStatus = null;
    public GameObject btnStart = null;
    public byte MaxPlayers = 6;

    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        btnStart.SetActive(false);
        Status("Connecting To Server");
    }

    public override void OnConnectedToMaster() {
        base.OnConnectedToMaster();

        PhotonNetwork.AutomaticallySyncScene = true;
        btnStart.SetActive(true);
        Status("Connected to " + PhotonNetwork.ServerAddress);

    }

    public void btnStart_Click(){
        string roomName = "Room1";
        Photon.Realtime.RoomOptions opts= new Photon.Realtime.RoomOptions();
        opts.IsOpen=true;
        opts.IsVisible=true;
        opts.MaxPlayers=MaxPlayers;

        PhotonNetwork.JoinOrCreateRoom(roomName, opts, Photon.Realtime.TypedLobby.Default);
        btnStart.SetActive(false);
        Status("Joining Room "+roomName);
    }

    public override void OnJoinedRoom(){
        base.OnJoinedRoom();
        SceneManager.LoadScene("Levels");
    }
    
    private void Status(string msg)
    {
        Debug.Log(msg);
        txtStatus.text=msg;
    }
}
