using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class freezeBulletName : MonoBehaviour
{
    
	private PhotonView photonView;
	private string player1, player2;
	private bool delete = false;
	
	
    void Start()
    {
		if(PhotonNetwork.IsMasterClient && gameObject.GetComponent<PhotonView>().ViewID>2000){
			gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0f,0f);
		}
		if(!PhotonNetwork.IsMasterClient && gameObject.GetComponent<PhotonView>().ViewID<2000){
			gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0f,0f);
		}
		gameObject.name="bulletfreezeGun";
		photonView = this.GetComponent<PhotonView>();
		
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
		player1 = "" + PhotonView.Find(1001).gameObject.name;
		
				
		
		
		
      //this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered, null);
	 Destroy(gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
	
	
	void OnTriggerEnter2D(Collider2D hitInfo)
    {
		
		
		if(hitInfo.tag == "Enemy"){
		 Destroy(gameObject);
		
			
		}
	}
}
