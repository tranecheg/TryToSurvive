using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class singleGame : MonoBehaviourPunCallbacks
{
	public GameObject buttons, Lobby, LobbyController, RoomController, buttonStart;
	public string nameRoom;
	void Start(){
	PhotonNetwork.AutomaticallySyncScene = true;
		PhotonNetwork.GameVersion = "1";
		AudioListener.pause = false;
	//PhotonNetwork.ConnectUsingSettings();
	buttonStart.GetComponent<Button>().interactable = true;
	}
	public override void OnConnectedToMaster(){
	 
	 if(PlayerPrefs.GetString("nickName")==""){
	  PhotonNetwork.NickName = "Player" + Random.Range(0, 9999);
	   }
	else{
	 PhotonNetwork.NickName = PlayerPrefs.GetString("nickName");
	 
	 
}
	  
   }
   
   
	 public void SingleGame(){
	LobbyController.GetComponent<PhotonLobbyCastom>().enabled = false;
	   RoomController.GetComponent<PhotonRoomCustom>().enabled = false;
		   
	PhotonNetwork.OfflineMode = true;
	PhotonNetwork.CreateRoom("" + Random.Range(0, 9999), new Photon.Realtime.RoomOptions {MaxPlayers = 1});
	PhotonNetwork.LoadLevel("Game");
	buttonStart.GetComponent<Button>().interactable = false;
		
	}
	public void multiplayer(){
	   PhotonNetwork.OfflineMode = false;
	   buttons.SetActive(false);
	   Lobby.SetActive(true);
	   LobbyController.GetComponent<PhotonLobbyCastom>().enabled = true;
	   RoomController.GetComponent<PhotonRoomCustom>().enabled = true;
   }
}
