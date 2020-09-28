using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using UnityEngine.UI;

public class bulletsShotgun : MonoBehaviour
{
   
	private PhotonView photonView;
	private string player1, player2;
	private bool delete = false;
	public bool nameBullet, nameBullet1,nameBullet2, nameBullet3,nameBullet4,nameBullet5,nameBullet6  = false;
	
	void Awake(){
		
	}
    
	void Start()
    {
		if(PhotonNetwork.IsMasterClient && gameObject.GetComponent<PhotonView>().ViewID>2000){
			gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0f,0f);
		}
		if(!PhotonNetwork.IsMasterClient && gameObject.GetComponent<PhotonView>().ViewID<2000){
			gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0f,0f);
		}
		
		if(this.name == "bulletShotgun"){
			nameBullet=true;
		}
		if(this.name == "bulletShotgun1"){
			nameBullet1=true;
		}
		if(this.name == "bulletShotgun2"){
			nameBullet2=true;
		}
		if(this.name == "bulletShotgun3"){
			nameBullet3=true;
		}
		if(this.name == "bulletShotgun4"){
			nameBullet4=true;
		}
		if(this.name == "bulletShotgun5"){
			nameBullet5=true;
		}
		if(this.name == "bulletShotgun6"){
			nameBullet6=true;
		}
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
		photonView = gameObject.GetComponent<PhotonView>();
		
		player1 = "" + PhotonView.Find(1001).gameObject.name;
		if(gameObject.name=="bulletShotgun"){
			
			if(gameObject.GetComponent<PhotonView>().ViewID>2000 && PhotonView.Find(2001)!=null){
		player2 = "" + PhotonView.Find(2001).gameObject.name; 
		Transform firePoint = GameObject.Find(player2).transform.GetChild(3);
			
		}
		if(gameObject.GetComponent<PhotonView>().ViewID<2000 && GameObject.Find(player1)!=null){
		Transform firePoint = GameObject.Find(player1).transform.GetChild(3);
		
		}
		
		}
	
	 Destroy(gameObject,1);
    }
	void Update(){
		
		if(nameBullet == true){
		photonView.RPC("changeNameBullet", RpcTarget.All);
		nameBullet = false;		
		}
		if(nameBullet1 == true){
		photonView.RPC("changeNameBullet1", RpcTarget.All);
		nameBullet1 = false;		
		}
		if(nameBullet2 == true){
		photonView.RPC("changeNameBullet2", RpcTarget.All);
		nameBullet2 = false;		
		}
		if(nameBullet3 == true){
		photonView.RPC("changeNameBullet3", RpcTarget.All);
		nameBullet3 = false;		
		}
		if(nameBullet4 == true){
		photonView.RPC("changeNameBullet4", RpcTarget.All);
		nameBullet4 = false;		
		}
		if(nameBullet5 == true){
		photonView.RPC("changeNameBullet5", RpcTarget.All);
		nameBullet5 = false;		
		}
		if(nameBullet6 == true){
		photonView.RPC("changeNameBullet6", RpcTarget.All);
		nameBullet6 = false;		
		}
	}
	[PunRPC]
	public void changeNameBullet(){
		
		
		gameObject.name="bulletShotgun";	
		
	}
	[PunRPC]
	public void changeNameBullet1(){
		
		
		gameObject.name="bulletShotgun1";	
		
	}
	[PunRPC]
	public void changeNameBullet2(){
		
		
		gameObject.name="bulletShotgun2";	
		
	}
	[PunRPC]
	public void changeNameBullet3(){
		
		
		gameObject.name="bulletShotgun3";	
		
	}
	[PunRPC]
	public void changeNameBullet4(){
		
		
		gameObject.name="bulletShotgun4";	
		
	}
	[PunRPC]
	public void changeNameBullet5(){
		
		
		gameObject.name="bulletShotgun5";	
		
	}
	[PunRPC]
	public void changeNameBullet6(){
		
		
		gameObject.name="bulletShotgun6";	
		
	}
	

    // Update is called once per frame
    
   
		
    
	
	
	void OnTriggerEnter2D(Collider2D hitInfo)
    {
		
		
		if(hitInfo.tag == "Enemy"){
		Destroy(gameObject);
		
			
		}
	}
}
