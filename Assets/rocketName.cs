using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class rocketName : MonoBehaviour
{
    private float destroyTime = 2f;
	private PhotonView photonView;
	
	IEnumerator destroyBullet(){
		yield return new WaitForSeconds(destroyTime);
		//this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered);
	}
    void Start()
    {
		gameObject.name="bulletBazooka";
        this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered, null);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
	[PunRPC]
	public void Destroy(){
	Destroy(gameObject,1);	
	}
}
