using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Photon.Pun;
using UnityEngine.UI;



public class bazookaShooting : MonoBehaviour
{
    public Transform firePoint;

	public GameObject bulletPref;
	public GameObject bullet;
	
	public float bulletForce = 10f;
	
	public float bulletPos, playerPos;
	private float rotateCheck, playerRotate, enemyRotate;
	private float angle;
	private float nextTimeOfFire = 0;
	  
	  public int click;
	   private PhotonView photonView;
	   public GameObject play;
	   public string name;
	   
	   public AudioClip bazookaSound, bazookaEmpty;
	   
	  
	   public int bulletsBazooka = 4;
		
		public int fullbulletsBazooka;
		
	   
	     private Animator anim;
		
		
	
	public bool isReloadingBazooka, isWalkingWithBazooka;
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
	 private string bazookaName;
	 

    void Start(){
		
	photonView = GetComponent<PhotonView>();
	bazookaName = "bazooka" + gameObject.name;
		
		
	}
    void FixedUpdate()
    {
		
		
		
		
		if(bullet!=null){
    	bulletPos = bullet.transform.position.x; 
		}
		if(click==1){
			if(GameObject.FindGameObjectWithTag("Enemy")!=null){
			enemies =  GameObject.FindGameObjectsWithTag("Enemy");
			nearest = FindClosest().name;
			enemy = GameObject.Find(nearest).transform;
			
			
			if(GameObject.Find(nearest).transform.parent.gameObject.GetComponent<Renderer>().isVisible==true){
				
			Vector3 direction = enemy.position - transform.position;
			angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
			if(GameObject.Find(bazookaName)!=null){
			this.transform.rotation = Quaternion.Euler(0,0,angle);
			}
			
						
			}
			if(GameObject.Find(nearest).transform.parent.gameObject.GetComponent<SpriteRenderer>().isVisible==false){
				
				
			}
			
		}
		else{
			
			if(GameObject.Find(bazookaName)!=null){
				
			}
		}
	
		 if(Time.time >= nextTimeOfFire)
            {
		
		
		Shoot();
		
		if(GameObject.Find(bazookaName)!=null){
			nextTimeOfFire = Time.time + 1f;
			
			if(fullbulletsBazooka==0 && bulletsBazooka==0){
				
				GameObject.Find(bazookaName).GetComponent<Animator>().SetBool("isShootingBazooka", false);
			
			}
			else{
		
			
			}
				
		
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
			
		bazookaReload();
		
		
		 rigidBody = GetComponent<Rigidbody2D>();
		double timeSec = System.Math.Round(time, 2);
		reloadSec.text = "Reloading " + timeSec + "sec.";
		
		
		if(GameObject.FindGameObjectWithTag("Enemy")!=null){
			
			
		}
	
		
	}
	
	
	
	
	
	private void Shoot(){
		
	
		fullbulletsBazooka=PlayerPrefs.GetInt("bulletsBazooka");
		if(GameObject.Find(bazookaName)!=null){
		if(isReloadingBazooka==false){
		if(fullbulletsBazooka==0 && bulletsBazooka==0){
			GameObject.Find(bazookaName).GetComponent<Animator>().SetBool("isShootingBazooka", false);	
		}
		else{
		
		bullet = PhotonNetwork.Instantiate(bulletPref.name, firePoint.position, firePoint.rotation);
		bullet.name = "bulletBazooka";
		GameObject.Find(bazookaName).GetComponent<Animator>().SetBool("isShootingBazooka", true);
		StartCoroutine( shake.Shake(.0f+0.15f, 0f+0.15f));
		
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = bazookaSound;
		audio.PlayOneShot(bazookaSound);
		
		photonView.RPC("soundBazooka", RpcTarget.Others);
		
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		bulletForce = 1f;
		rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
		
		
			
		
		bulletsBazooka--;
		
		}
		}
		}
		
		
		
			
	}
	[PunRPC]
	public void soundBazooka(){
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = bazookaSound;
		audio.PlayOneShot(bazookaSound);
	}
	public void OnButtonDown(){
		
           click=1;
		  
		  
			fullbulletsBazooka=PlayerPrefs.GetInt("bulletsBazooka");
		if(GameObject.Find(bazookaName)!=null){
			
		if(fullbulletsBazooka==0 && bulletsBazooka==0){
			GameObject.Find(bazookaName).GetComponent<Animator>().SetBool("isShootingBazooka", false);	
			play = GameObject.Find("Sound");
			AudioSource audio = play.GetComponent<AudioSource>();
			audio.clip = bazookaEmpty;
			audio.PlayOneShot(bazookaEmpty);
		}
		
	
		}
		
	}
	public void OnButtonUp(){
		
           click=0;
		  
		  if(GameObject.Find(bazookaName)!=null){
			  GameObject.Find(bazookaName).GetComponent<Animator>().SetBool("isShootingBazooka", false);	
		  }
		 				
	}
	
	void bazookaReload(){
		
		
		fullbulletsBazooka = PlayerPrefs.GetInt("bulletsBazooka");
		
		if(GameObject.Find(bazookaName)!=null){				
			bulletsAmount.text = "" + bulletsBazooka + "/" + fullbulletsBazooka;	

		if(bulletsBazooka==0 && fullbulletsBazooka>0){
			isReloadingBazooka=true;
		}
		else{
			isReloadingBazooka=false;
		}
		
        
		if(isReloadingBazooka==true){
		
		
			reloadText.SetActive(true);
			if(PlayerPrefs.GetInt("sfx")==0){
		GameObject.Find(bazookaName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = true;
			}
		gameObject.GetComponent<shooting>().enabled = false;
		gameObject.GetComponent<sniperShooting>().enabled = false;
		gameObject.GetComponent<FreezeGunShooting>().enabled = false;
		
		time-=Time.deltaTime;
		if(time<0){
			bulletsBazooka=4;
			fullbulletsBazooka=PlayerPrefs.GetInt("bulletsBazooka");
			fullbulletsBazooka-=4;
			GameObject.Find(bazookaName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = false;
			reloadText.SetActive(false);
			PlayerPrefs.SetInt("bulletsBazooka",fullbulletsBazooka);
			time=2.5f;
			
			
		}
		
		}
		else{
			gameObject.GetComponent<shooting>().enabled = true;
			gameObject.GetComponent<sniperShooting>().enabled = true;
			gameObject.GetComponent<FreezeGunShooting>().enabled = true;
		
		
		}
		}
	}
	
	
	
	
	
}