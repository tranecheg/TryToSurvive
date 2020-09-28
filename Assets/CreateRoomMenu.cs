using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
	private Text nameRoom;
    public void OnClickCreateRoom(){
		if(!PhotonNetwork.IsConnected)
			return;
		RoomOptions options = new RoomOptions();
		options.MaxPlayers = 2;
		PhotonNetwork.JoinOrCreateRoom(nameRoom.text, options, TypedLobby.Default);
		
	}
	public override void OnCreatedRoom(){
		 Debug.Log("success", this);
	}
}
