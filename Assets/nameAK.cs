using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class nameAK : MonoBehaviour
{
     public int owner;
	public string name;
	 private PhotonView photonView;
    void Start()
    {
        gameObject.name = "AK";
		
		//name = PhotonNetwork.NickName;
		//name = GetComponent<PhotonView>().owner.NickName;
		owner = this.GetComponent<PhotonView>().ViewID-1000;
		if(this.GetComponent<PhotonView>().ViewID-1000>=1000){
			GameObject gm = PhotonView.Find(2001).gameObject;
			name = gm.name;
			gameObject.transform.SetParent (GameObject.Find(name).transform.GetChild(0), true);
		}
		else{
			GameObject gm = PhotonView.Find(1001).gameObject;
			name = gm.name;
			gameObject.transform.SetParent (GameObject.Find(name).transform.GetChild(0), true);
		}
		gameObject.SetActive(false);
		
		//gameObject.transform.SetParent (GameObject.Find(name).transform.GetChild(0), true);
		//owner = gameObject.transform.parent.transform.parent.GetComponent<PhotonView>().ViewID;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
