using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Photon.Pun;
using UnityEngine.UI;

public class bulletTest : MonoBehaviour
{
    
	private PhotonView photonView;
	private string player1, player2;
	private bool delete = false;
	
	
    void Start()
    {
		photonView = this.GetComponent<PhotonView>();
		
		if(!photonView.IsMine){
			gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0f,0f);
		}
		
		
		
		
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
		player1 = "" + PhotonView.Find(1001).gameObject.name;
		
				
		
		if(gameObject.GetComponent<PhotonView>().ViewID>2000 && PhotonView.Find(2001)!=null){
		player2 = "" + PhotonView.Find(2001).gameObject.name; 
		
		}
		if(gameObject.GetComponent<PhotonView>().ViewID<2000 && GameObject.Find(player1)!=null){
		Transform firePoint = GameObject.Find(player1).transform.GetChild(3);
		
		}
		
  
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
	
