using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class grenade : MonoBehaviour
{
    private Vector2 targetPos;
	private float speed = 0f;
	public GameObject explosion;
	private Transform firePoint;
	
    void Start()
    {
        targetPos = GameObject.Find("Dir").transform.position;
		 firePoint = PhotonView.Find(1001).transform.GetChild(3);

    }
    void Update()
    {
   // this.GetComponent<PhotonView>().RPC("moveGrenade", RpcTarget.All);
	
	if(speed<2){
		speed+=.03f;
		gameObject.GetComponent<Rigidbody2D>().drag = speed;
	}
	else{
		StartCoroutine(Explode(1));
	}
	
	}
	[PunRPC]
	public void moveGrenade(){
	if(speed>0){
		  // speed-=Random.Range(.1f, .25f);
		  //gameObject.transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
	   }
	   else{
		   
	   }
	  if(speed<0){
		   speed=0;
		   if(PhotonNetwork.IsMasterClient){
			//PhotonNetwork.Destroy(gameObject);	
			}
			
		   //StartCoroutine(Explode(1));
		 
		   }
	   }	
	
	
	IEnumerator Explode(float time){
		yield return new WaitForSeconds(time);
		
		//PhotonNetwork.Destroy(gameObject);
		
		
		Destroy(gameObject);	
		
		Instantiate(explosion, transform.position, Quaternion.identity);
	}
	[PunRPC]
	public void Destroy(){
		
	//StartCoroutine(Explode(1));
	//Instantiate(explosion, transform.position, Quaternion.identity);	
	}
	private void OnTriggerEnter2D(Collider2D target){
		if(target.tag =="Enemy"){
			//StartCoroutine(Explode(0));
		}
	}
	
}
