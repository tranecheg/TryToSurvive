using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class PhotonLobbyCastom : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
   public static PhotonLobbyCastom lobby;
   public string roomName;
   public int roomSize;
   public GameObject roomListingPref, buttons, Lobby, settings, createRoom, joinRoom;
   public Transform roomsPanel;
   
   private void Awake(){
	   lobby = this;
   }
   void Start(){
PhotonNetwork.AutomaticallySyncScene = true;
		PhotonNetwork.GameVersion = "1";
	 PhotonNetwork.ConnectUsingSettings();
		


   }
   public override void OnConnectedToMaster(){
	   if(PlayerPrefs.GetString("nickName")==""){
	  PhotonNetwork.NickName = "Player" + Random.Range(0, 9999);
	   }
	else{
	 PhotonNetwork.NickName = PlayerPrefs.GetString("nickName");
	 
	 
}
			createRoom.GetComponent<Button>().interactable = true;
			 createRoom.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1f);
			 joinRoom.GetComponent<Button>().interactable = true;
			 joinRoom.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1f);	   
   }
   public override void OnRoomListUpdate(List<RoomInfo> roomList){
	   base.OnRoomListUpdate(roomList);
	   RemoveRoomListings();
	   foreach (RoomInfo room in roomList){
		   roomName = room.Name;
		   ListRoom(room);
	   }
   }
   void RemoveRoomListings(){
	   while(roomsPanel.childCount !=0){
		   Destroy(roomsPanel.GetChild(0).gameObject);
	   }
   }
  public void ListRoom(RoomInfo room){
	   if(room.IsOpen && room.IsVisible){
		   GameObject tempListing = Instantiate(roomListingPref, roomsPanel);
		   //RoomButton tempButton = tempListing.GetComponent<RoomButton>();
		   
		  // tempButton.roomName = roomName;
		  // tempButton.roomSize = 2;
		   //tempButton.SetRoom();
	   }
   }
   public void CreateRoom(){
	  

	   RoomOptions roomOps = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
	   roomName = "Game " + Random.Range(1, 1000);
	   PhotonNetwork.CreateRoom(roomName, roomOps);
   }
   public void OnRoomNameChanged(string nameIn){
	  // roomName = "test";
   }
   public void OnRoomSizeChanged(string sizeIn){
	   roomSize = int.Parse(sizeIn);
   }
   public void JoinLobbyOnClick(){
	   if(!PhotonNetwork.InLobby){
		   PhotonNetwork.JoinLobby();
	   }
   }
   public void multiplayer(){
	   PhotonNetwork.OfflineMode = false;
	   buttons.SetActive(false);
	   Lobby.SetActive(true);
   }
   
   public void JoinRoom(){
		PhotonNetwork.OfflineMode = false;
		PhotonNetwork.JoinRandomRoom();
		
	}
	public void openSettings(){
	buttons.SetActive(false);
	settings.SetActive(true);
	}
	 public void SingleGame(){
		
		PhotonNetwork.OfflineMode = true;
		PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions {MaxPlayers = 1});
		PhotonNetwork.LoadLevel("Game");
		
	}
   
}
