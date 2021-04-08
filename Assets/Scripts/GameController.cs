using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviourPun
{
    public Transform[] SpawnPoint = null;
    private void Awake()
    {
        int i =PhotonNetwork.CurrentRoom.PlayerCount - 1;
        PhotonNetwork.Instantiate("Player", SpawnPoint[i].position, SpawnPoint[i].rotation);
    }
}
