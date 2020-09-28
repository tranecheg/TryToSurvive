using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bulletsTurret : MonoBehaviour
{
   private float destroyTime = 2f;
	private PhotonView photonView;
	
	
    void Start()
    {
		gameObject.name="bulletTurret";
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
