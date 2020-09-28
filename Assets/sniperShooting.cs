using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Photon.Pun;
using UnityEngine.UI;



public class sniperShooting : MonoBehaviour
{
    public Transform firePoint;

	public GameObject bulletSniper, fakeBulletPref;
	public GameObject bullet, fakeBullet;
	
	public float bulletForce = 10f;
	
	public float bulletPos, playerPos;
	private float rotateCheck, playerRotate, enemyRotate;
	private float angle;
	private float nextTimeOfFire = 0;
	  
	  public int click;
	   private PhotonView photonView;
	   public GameObject play;
	   public string name;
	   
	   public AudioClip sniperSound, sniperEmpty;
	   
	  
	   public int bulletsSniper = 6;
		
		public int fullbulletsSniper;
		
	   
	     private Animator anim;
		
		
	
	public bool isReloadingSniper, isWalkingWithSniper;
	private float time=2.5f;
	
	
	public Text bulletsAmount, reloadSec;
	public GameObject reloadText;
	
	public ShakeCam shake;
	public float camShakeAmt = 0.1f;
	
	private Transform enemy;
	GameObject[] enemies;
	GameObject closest;
	public string nearest;
	 private Rigidbody2D rigidBody;
	 public string sniperName;
	 

    void Start(){
		
	photonView = GetComponent<PhotonView>();
		//if(photonView.IsMine){
		//GameObject fire = this.gameObject.transform.GetChild(2).gameObject;
		//fire.SetActive(true);	
		//}
		//else{
			//GameObject fire = this.gameObject.transform.GetChild(2).gameObject;
			//fire.SetActive(false);
		//}
		sniperName = "sniperRifle" + gameObject.name;
	
	
		
		
	}
	[PunRPC]
	public void turnSniper(){
		if(GameObject.FindGameObjectWithTag("Enemy")!=null){
			enemies =  GameObject.FindGameObjectsWithTag("Enemy");
			nearest = FindClosest().name;
			enemy = GameObject.Find(nearest).transform;
			
			
			if(GameObject.Find(nearest).transform.parent.gameObject.GetComponent<Renderer>().isVisible==true){
				
			Vector3 direction = enemy.position - transform.position;
			angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
			if(GameObject.Find(sniperName)!=null){
			this.transform.rotation = Quaternion.Euler(0,0,angle);
			}
			
						
			}
			if(GameObject.Find(nearest).transform.parent.gameObject.GetComponent<SpriteRenderer>().isVisible==false){
				
				
			}
			
		}
		else{
			
			//click=0;
			if(GameObject.Find(sniperName)!=null){
			//	GameObject.Find(sniperName).GetComponent<Animator>().SetBool("isShootingSniper", false);
			}
		}
	}
    void FixedUpdate()
    {
		
		
		
		//if(!photonView.IsMine) return;
		if(bullet!=null){
    	bulletPos = bullet.transform.position.x; 
		}
		//GameObject player = GameObject.FindGameObjectWithTag("Player");
		//GameObject player = GameObject.Find("player");
		//GameObject player = GameObject.Find(photonView.Owner.NickName);
		//playerPos = player.transform.position.x;
		
		if(click==1){
			
			photonView.RPC("turnSniper", RpcTarget.AllBuffered,null);
			
			
		 if(Time.time >= nextTimeOfFire)
            {
		
		
		Shoot();
		
		if(GameObject.Find(sniperName)!=null){
			nextTimeOfFire = Time.time + 1f;
			if(isReloadingSniper==false){
			//StartCoroutine( shake.Shake(.0f+0.20f, 0f+0.20f));
			
			}
			else{
			GameObject.Find(sniperName).GetComponent<Animator>().SetBool("isShootingSniper", false);	
			}
			if(fullbulletsSniper==0 && bulletsSniper==0){
				GameObject.Find(sniperName).GetComponent<Animator>().SetBool("isShootingSniper", false);
				
			
			}
			else{
		
			
			}
			
			
			
			
			
			
					
		
		}
		else{
			//GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
		}
		}
		
		
		
    }
	}
	
	GameObject FindClosest(){
	float distance = Mathf.Infinity;
	Vector3 position = transform.position;
	if(GameObject.FindGameObjectWithTag("Enemy")!=null){
	foreach (GameObject go in enemies){
		Vector3 diff = go.transform.position - position;
		float curDistance = diff.sqrMagnitude;
		if(curDistance<distance){
			closest = go;
			distance = curDistance;
		}
	}
	}
	
	return closest;
	}
	
	void Update(){
		
		
			
		sniperReload();
		
		
		 rigidBody = GetComponent<Rigidbody2D>();
		double timeSec = System.Math.Round(time, 2);
		reloadSec.text = "Reloading " + timeSec + "sec.";
		
		
		if(GameObject.FindGameObjectWithTag("Enemy")!=null){
			
			
		}
		
		
	
		
		
		
	}
	
	
	
	
	
	private void Shoot(){
		
	
		fullbulletsSniper=PlayerPrefs.GetInt("bulletsSniper");
		if(GameObject.Find(sniperName)!=null){
		if(isReloadingSniper==false){
		if(fullbulletsSniper==0 && bulletsSniper==0){
			
		}
		else{
		GameObject.Find(sniperName).GetComponent<Animator>().SetBool("isShootingSniper", true);
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		fakeBullet = Instantiate(fakeBulletPref, firePoint.position, firePoint.rotation);
		fakeBullet.name = "bulletSniper";
		Rigidbody2D rb = fakeBullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.right * 50f, ForceMode2D.Impulse);
		photonView.RPC("sniperShoot", RpcTarget.Others);
		
	
		StartCoroutine( shake.Shake(.0f+0.15f, 0f+0.15f));
		
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = sniperSound;
		audio.PlayOneShot(sniperSound);
		
		
		//Destroy(bullet, 1f);
		
			
		
		bulletsSniper--;
		
		
		
		}
		}
		}
		
		
		
			
	}
	[PunRPC]
	public void sniperShoot(){
		GameObject.Find(sniperName).GetComponent<Animator>().SetBool("isShootingSniper", true);
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		bullet = PhotonNetwork.Instantiate(bulletSniper.name, firePoint.position, firePoint.rotation);
		bullet.name = "bulletSniper";
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.right * 50f, ForceMode2D.Impulse);
		
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = sniperSound;
		audio.PlayOneShot(sniperSound);
	}
	public void OnButtonDown(){
		
		if(bulletsSniper>0 && GameObject.Find(sniperName)!=null){
           click=1;
		}
		  
			fullbulletsSniper=PlayerPrefs.GetInt("bulletsSniper");
		if(GameObject.Find(sniperName)!=null){
			
		if(fullbulletsSniper==0 && bulletsSniper==0){
			GameObject.Find(sniperName).GetComponent<Animator>().SetBool("isShootingSniper", false);	
			play = GameObject.Find("Sound");
			AudioSource audio = play.GetComponent<AudioSource>();
			audio.clip = sniperEmpty;
			audio.PlayOneShot(sniperEmpty);
		}
		
	
		}
		
	}
	public void OnButtonUp(){
		
           click=0;
		  
		  if(GameObject.Find(sniperName)!=null){
			  GameObject.Find(sniperName).GetComponent<Animator>().SetBool("isShootingSniper", false);	
		  }
		 
			
		
		  // GameObject.Find("Main Camera").GetComponent<CamFollow>().enabled = true;
				
	}
	
	void sniperReload(){
		
		
		fullbulletsSniper = PlayerPrefs.GetInt("bulletsSniper");
		
		if(GameObject.Find(sniperName)!=null){				
			bulletsAmount.text = "" + bulletsSniper + "/" + fullbulletsSniper;	

		if(bulletsSniper==0 && fullbulletsSniper>0){
			isReloadingSniper=true;
		}
		else{
			isReloadingSniper=false;
		}
		
        
		if(isReloadingSniper==true){
		//GameObject.Find("shotgun").GetComponent<Animator>().SetBool("isReloadingShotgun", true);
		
			reloadText.SetActive(true);
			if(PlayerPrefs.GetInt("sfx")==0){
		GameObject.Find(sniperName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = true;
			}
		gameObject.GetComponent<shooting>().enabled = false;
		gameObject.GetComponent<bazookaShooting>().enabled = false;
		gameObject.GetComponent<FreezeGunShooting>().enabled = false;
		
		time-=Time.deltaTime;
		if(time<0){
			bulletsSniper=6;
			fullbulletsSniper=PlayerPrefs.GetInt("bulletsSniper");
			fullbulletsSniper-=6;
			GameObject.Find(sniperName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = false;
			reloadText.SetActive(false);
			PlayerPrefs.SetInt("bulletsSniper",fullbulletsSniper);
			time=2.5f;
			
			
		}
		
		}
		else{
			gameObject.GetComponent<shooting>().enabled = true;
			gameObject.GetComponent<bazookaShooting>().enabled = true;
			gameObject.GetComponent<FreezeGunShooting>().enabled = true;
		//GameObject.Find("shotgun").GetComponent<Animator>().SetBool("isReloadingShotgun", false);
		
		}
		}
	}
	
	
	
	
	
}