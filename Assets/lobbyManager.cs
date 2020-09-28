using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class lobbyManager : MonoBehaviourPunCallbacks
{
    public Button createBtn, joinBtn;
	[SerializeField]
	private Text nameRoom;
	public GameObject listPref;
	public Transform listView;
	void Awake(){
			
	}
    private void Start()
    {
		
      PhotonNetwork.LocalPlayer.NickName = "Player" + Random.Range(1, 100); 
	  
	  PhotonNetwork.AutomaticallySyncScene = true;
		PhotonNetwork.GameVersion = "1";
	PhotonNetwork.ConnectUsingSettings();	

    }

    // Update is called once per frame
    void Update()
    {
      if(Application.internetReachability != NetworkReachability.NotReachable)
        {
         createBtn.interactable = true;
		joinBtn.interactable = true;
        } 
	
    }
	public override void OnRoomListUpdate(List<RoomInfo> roomList){
	GameObject list = Instantiate(listPref, listView);	
	}
	public override void OnConnectedToMaster(){
		
	}
	public void OnCreatedRoom(){
	PhotonNetwork.JoinLobby();
	}
	
	public void CreateRoom(){
		PhotonNetwork.OfflineMode = false;
		PhotonNetwork.CreateRoom(nameRoom.text, new Photon.Realtime.RoomOptions {MaxPlayers = 2});
		GameObject list = Instantiate(listPref, listView);
	
		
	}
	
	public void JoinRoom(){
		PhotonNetwork.OfflineMode = false;
		PhotonNetwork.JoinRandomRoom();
		
	}
	public override void OnJoinedRoom(){
		//PhotonNetwork.LoadLevel("Game");
	}
	public void SingleGame(){
		SceneManager.LoadScene("Game");
		PhotonNetwork.OfflineMode = true;
		PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions {MaxPlayers = 1});
		
	}
}
