using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class grenadeExplosion : MonoBehaviour
{
    private Vector2 center;
	public float radius = 5f;
	private float time = 0.5f;
	public ShakeCam shake;
	public GameObject mainCamera;
	public float camShakeAmt = 0.9f;
    void Start()
    {
        center  = transform.position;
		if(PhotonNetwork.IsMasterClient){
		shake = GameObject.Find("Camera").GetComponent<ShakeCam>();
		}
		if(!PhotonNetwork.IsMasterClient){
		shake = GameObject.Find("Camera (1)").GetComponent<ShakeCam>();
		}
    }

    // Update is called once per frame
    void Update()
    {
		if(PlayerPrefs.GetInt("sfx")==0){
			gameObject.GetComponent<AudioSource>().enabled = true;
		}
		else{
			gameObject.GetComponent<AudioSource>().enabled = false;
		}
		
       Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position, radius);
	  
	   
	   StartCoroutine( shake.Shake(.0f+0.3f, 0f+0.3f));
	   time-=Time.deltaTime;
	   if(time<0){
		   
			Destroy(gameObject);
		}
	else if(time>0.4){
		
		foreach(Collider2D col in enemyHit){
	if(col.tag=="Enemy"){
		Enemy zombie = col.transform.parent.gameObject.GetComponent<Enemy>();
		EnemyLevel3 zombie2 = col.transform.parent.gameObject.GetComponent<EnemyLevel3>();
		if(zombie!=null){
			zombie.TakeDamage(50);
			time-=Time.deltaTime;
		}
		if(zombie2!=null){
			zombie2.TakeDamage(50);
			time-=Time.deltaTime;
		}
		
	}
	}
	}
	if(time>0){
		
	}
		
	}
	
	private void OnDrawGizmosSelected(){
		
		
		Gizmos.color = Color.black;
		Gizmos.DrawSphere(transform.position, radius);	
		
	}
	
	
}

