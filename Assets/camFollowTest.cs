using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class camFollowTest : MonoBehaviour
{
    private PhotonView pv;
    void Start()
    {
     pv = gameObject.GetComponent<PhotonView>(); 
	PlayerPrefs.SetInt("money", 20000);
	
	PlayerPrefs.SetInt("bulletsGrenade", 0);	 
    }

    // Update is called once per frame
    void Update()
    {
	if(PhotonNetwork.IsMasterClient && pv.IsMine){
       GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;
	   GameObject.Find("Main Camera1").GetComponent<Camera>().enabled = false;
	   GameObject.Find("Main Camera").transform.position = new Vector3(this.transform.position.x,  this.transform.position.y,-10f);
		GameObject.Find("Main Camera").transform.position = new Vector3(Mathf.Clamp(transform.position.x, -16f, 16f), Mathf.Clamp(transform.position.y, -20f, 20f), -10f);
	}
	if(!PhotonNetwork.IsMasterClient && pv.IsMine){
       GameObject.Find("Main Camera").GetComponent<Camera>().enabled = false;
	   GameObject.Find("Main Camera1").GetComponent<Camera>().enabled = true;
	   
	   GameObject.Find("Main Camera1").transform.position = new Vector3(this.transform.position.x,  this.transform.position.y,-10f);
		GameObject.Find("Main Camera1").transform.position = new Vector3(Mathf.Clamp(transform.position.x, -16f, 16f), Mathf.Clamp(transform.position.y, -20f, 20f), -10f);
	}
		
    }
}
