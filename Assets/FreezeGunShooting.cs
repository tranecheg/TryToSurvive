using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Photon.Pun;
using UnityEngine.UI;



public class FreezeGunShooting : MonoBehaviour
{
    public Transform firePoint;

	public GameObject bulletPref, fakeBulletPref;
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
	   
	   public AudioClip freezeGunSound, freezeGunEmpty;
	   
	  
	   public int bulletsFreezeGun = 12;
		
		public int fullbulletsFreezeGun;
		
	   
	     private Animator anim;
		
		
	
	public bool isReloadingFreezeGun, isWalkingWithFreezeGun;
	private float time=2f;
	
	
	public Text bulletsAmount, reloadSec;
	public GameObject reloadText;
	
	public ShakeCam shake;
	public float camShakeAmt = 0.1f;
	
	private Transform enemy;
	GameObject[] enemies;
	GameObject closest;
	public string nearest;
	 private Rigidbody2D rigidBody;
	 
	 private string freezeGunName;

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
		
	freezeGunName = "freezeGun" + gameObject.name;
	
		
		
	}
	[PunRPC]
	public void turnFreezeGun(){
		if(GameObject.FindGameObjectWithTag("Enemy")!=null){
			enemies =  GameObject.FindGameObjectsWithTag("Enemy");
			nearest = FindClosest().name;
			enemy = GameObject.Find(nearest).transform;
			
			
			if(GameObject.Find(nearest).transform.parent.gameObject.GetComponent<Renderer>().isVisible==true){
				
			Vector3 direction = enemy.position - transform.position;
			angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
			if(GameObject.Find(freezeGunName)!=null){
			this.transform.rotation = Quaternion.Euler(0,0,angle);
			}
			
						
			}
			if(GameObject.Find(nearest).transform.parent.gameObject.GetComponent<SpriteRenderer>().isVisible==false){
				
				
			}
			
		}
		else{
			
			//click=0;
			if(GameObject.Find(freezeGunName)!=null){
				//GameObject.Find(freezeGunName).GetComponent<Animator>().SetBool("isShootingFreezeGun", false);
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
			
			photonView.RPC("turnFreezeGun", RpcTarget.AllBuffered,null);
			
			
			
		 if(Time.time >= nextTimeOfFire)
            {
		
		
		Shoot();
		
		if(GameObject.Find(freezeGunName)!=null){
			nextTimeOfFire = Time.time + 1f;
			if(isReloadingFreezeGun==false){
			//StartCoroutine( shake.Shake(.0f+0.20f, 0f+0.20f));
			
			}
			else{
			GameObject.Find(freezeGunName).GetComponent<Animator>().SetBool("isShootingFreezeGun", false);	
			}
			if(fullbulletsFreezeGun==0 && bulletsFreezeGun==0){
			GameObject.Find(freezeGunName).GetComponent<Animator>().SetBool("isShootingFreezeGun", false);	
				
			
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
		
		
			
		freezeGunReload();
		
		
		 rigidBody = GetComponent<Rigidbody2D>();
		double timeSec = System.Math.Round(time, 2);
		reloadSec.text = "Reloading " + timeSec + "sec.";
		
		
		if(GameObject.FindGameObjectWithTag("Enemy")!=null){
			
			
		
		
	
		
		
		
	}
	}
	
	
	
	
	
	private void Shoot(){
		
	
		fullbulletsFreezeGun=PlayerPrefs.GetInt("bulletsFreezeGun");
		if(GameObject.Find(freezeGunName)!=null){
		if(isReloadingFreezeGun==false){
		if(fullbulletsFreezeGun==0 && bulletsFreezeGun==0){
			
		}
		else{
		GameObject.Find(freezeGunName).GetComponent<Animator>().SetBool("isShootingFreezeGun", true);
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		fakeBullet = Instantiate(fakeBulletPref, firePoint.position, firePoint.rotation);
		fakeBullet.name = "bulletfreezeGun";
		Rigidbody2D rb = fakeBullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.right * 50f, ForceMode2D.Impulse);
		photonView.RPC("shootFreeze", RpcTarget.Others);
		
		StartCoroutine( shake.Shake(.0f+0.15f, 0f+0.15f));
		
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = freezeGunSound;
		audio.PlayOneShot(freezeGunSound);
		
		
		
	
		//Destroy(bullet, 1f);
		
			
		
		bulletsFreezeGun--;
		
		
		
		}
		}
		}
		
		
		
			
	}
	[PunRPC]
	public void shootFreeze(){
		GameObject.Find(freezeGunName).GetComponent<Animator>().SetBool("isShootingFreezeGun", true);
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		bullet = PhotonNetwork.Instantiate(bulletPref.name, firePoint.position, firePoint.rotation);
		bullet.name = "bulletfreezeGun";
				
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.right * 50f, ForceMode2D.Impulse);
		
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = freezeGunSound;
		audio.PlayOneShot(freezeGunSound);
	}
	public void OnButtonDown(){
		
			if(bulletsFreezeGun>0 && GameObject.Find(freezeGunName)!=null){
		  click=1;
			}
		  
			fullbulletsFreezeGun=PlayerPrefs.GetInt("bulletsFreezeGun");
		if(GameObject.Find(freezeGunName)!=null){
			
		if(fullbulletsFreezeGun==0 && bulletsFreezeGun==0){
			GameObject.Find(freezeGunName).GetComponent<Animator>().SetBool("isShootingFreezeGun", false);	
			play = GameObject.Find("Sound");
			AudioSource audio = play.GetComponent<AudioSource>();
			audio.clip = freezeGunEmpty;
			audio.PlayOneShot(freezeGunEmpty);
		}
		
	
		}
		
	}
	public void OnButtonUp(){
		
           click=0;
		  
		  if(GameObject.Find(freezeGunName)!=null){
			  GameObject.Find(freezeGunName).GetComponent<Animator>().SetBool("isShootingFreezeGun", false);	
		  }
		 
			
		
		  // GameObject.Find("Main Camera").GetComponent<CamFollow>().enabled = true;
				
	}
	
	void freezeGunReload(){
		
		
		fullbulletsFreezeGun = PlayerPrefs.GetInt("bulletsFreezeGun");
		
		if(GameObject.Find(freezeGunName)!=null){				
			bulletsAmount.text = "" + bulletsFreezeGun + "/" + fullbulletsFreezeGun;	

		if(bulletsFreezeGun==0 && fullbulletsFreezeGun>0){
			isReloadingFreezeGun=true;
		}
		else{
			isReloadingFreezeGun=false;
		}
		
        
		if(isReloadingFreezeGun==true){
		//GameObject.Find("shotgun").GetComponent<Animator>().SetBool("isReloadingShotgun", true);
		
			reloadText.SetActive(true);
			if(PlayerPrefs.GetInt("sfx")==0){
		GameObject.Find(freezeGunName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = true;
			}
		gameObject.GetComponent<shooting>().enabled = false;
		gameObject.GetComponent<bazookaShooting>().enabled = false;
		gameObject.GetComponent<sniperShooting>().enabled = false;
		
		time-=Time.deltaTime;
		if(time<0){
			bulletsFreezeGun=12;
			fullbulletsFreezeGun=PlayerPrefs.GetInt("bulletsFreezeGun");
			fullbulletsFreezeGun-=12;
			GameObject.Find(freezeGunName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = false;
			reloadText.SetActive(false);
			PlayerPrefs.SetInt("bulletsFreezeGun",fullbulletsFreezeGun);
			time=2f;
			
			
		}
		
		}
		else{
			gameObject.GetComponent<shooting>().enabled = true;
			gameObject.GetComponent<bazookaShooting>().enabled = true;
			gameObject.GetComponent<sniperShooting>().enabled = true;
		//GameObject.Find("shotgun").GetComponent<Animator>().SetBool("isReloadingShotgun", false);
		
		}
		}
	}
	
	
	
	
	
}