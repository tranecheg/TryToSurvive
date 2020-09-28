using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{
	public GameObject lobby, menu, settings, room;
    public void quitLobby(){
		PhotonNetwork.Disconnect ();
		lobby.SetActive(false);
		menu.SetActive(true);
		//PhotonNetwork.NetworkingPeer.State = ClientState.Disconnected;
	}
	public void quitSettings(){
		settings.SetActive(false);
		menu.SetActive(true);
	}
	public void quitRoom(){
		 PhotonNetwork.LeaveRoom();
		 PhotonNetwork.Disconnect ();
		 room.SetActive(false);
		 lobby.SetActive(true);
	}
	
	
}
