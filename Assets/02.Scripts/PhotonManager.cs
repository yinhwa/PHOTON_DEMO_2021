using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public const string version = "1.0"; //버전별로 접속할 수 있게하는 역할
    public string userName = "Zack";
    public byte maxPlayerCount = 4;

    void Awake()
    {
        //새로운 씬을 호출을 할 경우 자동으로 씬이 호출이 되는 기능
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        PhotonNetwork.NickName = userName;
        PhotonNetwork.GameVersion = version;

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected !!!");
        //랜덤 조인
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"Join Failed code={returnCode}, msg={message}");
    }

}