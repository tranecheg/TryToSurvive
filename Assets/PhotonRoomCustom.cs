using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonRoomCustom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
   public static PhotonRoomCustom room;
   private PhotonView pv;
   public bool IsGameLoaded;
   public int currentScene;
   public GameObject lobby, roomGO, playerListingPref, startButton;
   public Transform playersPanel;
   
   Player[] photonPlayers;
   public int playersInRoom, myNumberInRoom, playersInGame;
   
   private void Awake(){
	   if(PhotonRoomCustom.room ==null){
		   PhotonRoomCustom.room = this;
	   }
	   else{
		 if(PhotonRoomCustom.room!=this){
			 Destroy(PhotonRoomCustom.room.gameObject);
			 PhotonRoomCustom.room = this;
		 }  
	   }
	//   DontDestroyOnLoad(this.gameObject);
   }
   void Start(){
	   startButton.GetComponent<Button>().interactable = true;
   }
   public void Update(){
	   if(PhotonNetwork.IsMasterClient && playersInRoom==2){
		   startButton.SetActive(true);
	   }
   }
   public override void OnJoinedRoom(){
	   base.OnJoinedRoom();
	   if(PhotonNetwork.OfflineMode == false){
	   lobby.SetActive(false);
	   roomGO.SetActive(true);
	   
	   
	   ClearPlayerListings();
	   ListPlayers();
	   photonPlayers = PhotonNetwork.PlayerList;
	   playersInRoom = photonPlayers.Length;
	   myNumberInRoom = playersInRoom;
	   }
   }
   void ClearPlayerListings(){
	   for(int i = playersPanel.childCount -1; i>=0; i--){
		   Destroy(playersPanel.GetChild(i).gameObject);
	   }
   }
   void ListPlayers(){
	   if(PhotonNetwork.InRoom){
		   foreach(Player player in PhotonNetwork.PlayerList){
			   GameObject tempListing = Instantiate(playerListingPref, playersPanel);
			   Text tempText = tempListing.transform.GetChild(0).GetComponent<Text>();
			   tempText.text = player.NickName;
		   }
	   }
   }
   public override void OnPlayerEnteredRoom(Player newPlayer){
	   ClearPlayerListings();
	   ListPlayers();
		base.OnPlayerEnteredRoom(newPlayer);
		photonPlayers = PhotonNetwork.PlayerList;
		playersInRoom++;	   
   }
    public override void OnPlayerLeftRoom(Player newPlayer){
	   ClearPlayerListings();
	   ListPlayers();
		base.OnPlayerLeftRoom(newPlayer);
		photonPlayers = PhotonNetwork.PlayerList;
		playersInRoom--;	   
   }
    public void StartGame(){
	   PhotonNetwork.LoadLevel("Game");
	   startButton.GetComponent<Button>().interactable = false;
   }
  
   
}
