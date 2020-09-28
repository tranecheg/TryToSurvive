using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class changeName : MonoBehaviour
{
    
	public string name;
	 private PhotonView photonView;
	 public string player;
	 public float id;
    void Start()
    {
		
	
		id = gameObject.GetComponent<PhotonView>().ViewID/1000;
		string num = id + "001";		
		player = "" + PhotonView.Find(int.Parse(num)).gameObject.name;
		
		
		
		
		
		
		if(gameObject.name=="shotgun(Clone)"){
       
		   gameObject.name = "shotgun" + player; 
		   gameObject.transform.localScale = new Vector3(0.52f, 0.52f, 1f);
		   gameObject.transform.rotation = Quaternion.Euler(0,0,0);
	   }
	   
		
		if(gameObject.name=="AK(Clone)"){
       
		   gameObject.name = "AK" + player;
			gameObject.transform.rotation = Quaternion.Euler(0,0,0);
			gameObject.transform.localScale = new Vector3(0.52f, 0.52f, 1f);			
	   }
		
		if(gameObject.name=="sniperRifle(Clone)"){
       
		   gameObject.name = "sniperRifle" + player;
		   gameObject.transform.rotation = Quaternion.Euler(0,0,0);
		   gameObject.transform.localScale = new Vector3(0.4933f, 0.4933f, 1f);
			
	   }
		
		if(gameObject.name=="FlameThrover(Clone)"){
       
		   gameObject.name = "flameThrover" + player;
			gameObject.transform.rotation = Quaternion.Euler(0,0,0);
			gameObject.transform.localScale = new Vector3(0.38f, 0.3733f, 1f);
	   
		}
		if(gameObject.name=="bazooka(Clone)"){
       
		   gameObject.name = "bazooka" + player;
			gameObject.transform.rotation = Quaternion.Euler(0,0,0);
			gameObject.transform.localScale = new Vector3(0.52f, 0.52f, 1f);			
	   }
		
		if(gameObject.name=="freezeGun(Clone)"){
       
		   gameObject.name = "freezeGun" + player; 
			gameObject.transform.rotation = Quaternion.Euler(0,0,0);
			gameObject.transform.localScale = new Vector3(0.4933f, 0.4933f, 1f);
		}
		
	
			
			gameObject.transform.SetParent (GameObject.Find(player).transform.GetChild(0), false);
			gameObject.SetActive(false);
		
    }

    // Update is called once per frame
    void Update()
    {
        
			
    }
}
