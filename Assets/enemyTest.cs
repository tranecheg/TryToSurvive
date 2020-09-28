using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class enemyTest : MonoBehaviourPunCallbacks
{
	public GameObject enemyPrefab;
	public int spaw;
	private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
		if(PhotonNetwork.IsMasterClient){
       photonView = GetComponent<PhotonView>();	
       GameObject enemy = PhotonNetwork.Instantiate(enemyPrefab.name, new Vector3(Random.Range(-1f, 1f), Random.Range(1f, -1f)), Quaternion.identity);
		enemy.name = "enemy"; 
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
