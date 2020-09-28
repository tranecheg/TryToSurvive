using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
	public int spaw;
	private PhotonView photonView;

    void Start()
    {
		photonView = GetComponent<PhotonView>();	
       GameObject player = PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(Random.Range(-5f, 0f), Random.Range(-5f, 0f)), Quaternion.identity);
		player.name = "player";
		
	
	}

    // Update is called once per frame
    void Update()
    {
       
	}
	public override void OnPlayerEnteredRoom(Player newPlayer){
		
	}
	public override void OnLeftRoom()
	{
    SceneManager.LoadScene("Load");
	}
	
	
	
}
