using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LandMine : MonoBehaviour
{
    public GameObject explosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
	IEnumerator Explode(float time){
		yield return new WaitForSeconds(time);
		
		PhotonNetwork.Instantiate(explosion.name, transform.position, Quaternion.identity);
		gameObject.GetComponent<PhotonView>().RPC("destroyRocket", RpcTarget.All);
		
	}
	private void OnTriggerEnter2D(Collider2D target){
		if(target.tag =="Enemy"){
			StartCoroutine(Explode(0));
			
		}
	}
	[PunRPC]
	public void destroyRocket(){
		Destroy(gameObject);
	}
	
	
}
