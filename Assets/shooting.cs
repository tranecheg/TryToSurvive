
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Photon.Pun;
using UnityEngine.UI;



public class shooting : MonoBehaviourPun
{
    public Transform firePoint, firePoint1, firePoint2, firePoint3, firePoint4, firePoint5, firePoint6;

	public GameObject bulletPref, bulletShotgun, bulletAK;
	public GameObject fakeBulletPref;
	private GameObject bullet, bullet1, bullet2, bullet3, bullet4, bullet5, bullet6, fakeBullet;
	
	public float bulletForce = 10f;
	
	public float bulletPos, playerPos;
	public float rotateCheck, playerRotate, enemyRotate;
	private float angle;
	private float nextTimeOfFire = 0;
	  
	  public int click;
	   private PhotonView photonView;
	   public GameObject play;
	   public string name;
	   
	   public AudioClip pistolSound, shotgunSound, AKSound, shotgunEmpty, AKEmpty;
	   
	  
	   public int bulletsPistol =10;
	    private int bulletsShotgun =2;
		public int bulletsAK =30;
		
		public int fullbulletsShotgun, fullbulletsAK;
		
	   
	     private Animator anim;
		
		//[SerializeField] ModelImporterClipAnimation shotPistol;
	
	public bool turn, isReloadingPistol, isWalkingWithShotGun, isReloadingShotgun, isWalkingWithAK, isReloadingAK, isShootingPistol;
	private float time=1f;
	
	
	public Text bulletsAmount,bulletsAmount1, reloadSec;
	public GameObject reloadText;
	
	public ShakeCam shake;
	public float camShakeAmt = 0.1f;
	
	private Transform enemy;
	GameObject[] enemies;
	GameObject closest;
	public string nearest;
	 private Rigidbody2D rigidBody;
	 public string pistolName, shotgunName, AKName;
	 

    void Start(){
		
	//	photonView = GetComponent<PhotonView>();
		//if(photonView.IsMine){
		//GameObject fire = this.gameObject.transform.GetChild(2).gameObject;
		//fire.SetActive(true);	
		//}
		//else{
			//GameObject fire = this.gameObject.transform.GetChild(2).gameObject;
			//fire.SetActive(false);
		//}
		bulletsPistol =10;
	photonView = GetComponent<PhotonView>();
	
	
	
	pistolName = "pistol" + gameObject.name;
	shotgunName = "shotgun" + gameObject.name;	
	AKName = "AK" + gameObject.name;
		
	}
	[PunRPC]
	public void newTest(){
		if(GameObject.FindGameObjectWithTag("Enemy")!=null){
			enemies =  GameObject.FindGameObjectsWithTag("Enemy");
			nearest = FindClosest().name;
			enemy = GameObject.Find(nearest).transform;
			
			
			if(GameObject.Find(nearest).transform.parent.gameObject.GetComponent<Renderer>().isVisible==true){
				
			Vector3 direction = enemy.position - transform.position;
			angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
			if(GameObject.Find(pistolName)!=null){
			this.transform.rotation = Quaternion.Euler(0,0,angle);
			}
			if(GameObject.Find(shotgunName)!=null){
			this.transform.rotation = Quaternion.Euler(0,0,angle);
			}
			if(GameObject.Find(AKName)!=null){
			this.transform.rotation = Quaternion.Euler(0,0,angle);
			}
			
						
			}
			if(GameObject.Find(nearest).transform.parent.gameObject.GetComponent<SpriteRenderer>().isVisible==false){
				
				
			}
			
		}
		
		else{
			enemyRotate=0;
			click=0;
			if(GameObject.Find(pistolName)!=null){
			
				GameObject.Find(pistolName).GetComponent<Animator>().SetBool("isShootingPistol", false);
			}
			if(GameObject.Find(AKName)!=null){
			GameObject.Find(AKName).GetComponent<Animator>().SetBool("isShootingAK",false);
			}
			if(GameObject.Find(shotgunName)!=null){
			GameObject.Find(shotgunName).GetComponent<Animator>().SetBool("isShootingShotgun",false);
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
			
			photonView.RPC("newTest", RpcTarget.AllBuffered,null);
			
			
			
		 if(Time.time >= nextTimeOfFire)
            {
		
		
		Shoot();
		
		
		if(GameObject.Find(shotgunName)!=null){
			nextTimeOfFire = Time.time + 0.8f;
			if(isReloadingShotgun==false){
			
			
			}
			else{
			GameObject.Find(shotgunName).GetComponent<Animator>().SetBool("isShootingShotgun", false);	
			}
			if(fullbulletsShotgun==0 && bulletsShotgun==0){
				GameObject.Find(shotgunName).GetComponent<Animator>().SetBool("isShootingShotgun", false);	
				
			
			}
			else{
		
			
			}
			
			
			
			
			
			
					
		}
		
		if(GameObject.Find(pistolName)!=null){
			nextTimeOfFire = Time.time + 0.35f;
			
			
			if(isReloadingPistol==false){
			StartCoroutine( shake.Shake(.1f, .1f));
				
			
		}
		else{
			GameObject.Find(pistolName).GetComponent<Animator>().SetBool("isShootingPistol", false);
		}
		}
		if(GameObject.Find(AKName)!=null){
			nextTimeOfFire = Time.time + 0.07f;
			if(isReloadingAK==false && bulletsAK>0){
			StartCoroutine( shake.Shake(.0f+0.08f, 0f+0.08f));
			}
		
		}
		}
		else{
			//GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
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
		
		
		
		
		pistolReload();
		if(GameObject.Find("pistol")!=null && bulletsPistol==1){
		//UnityEditor.AnimationClipSettings settings = UnityEditor.AnimationUtility.GetAnimationClipSettings(shotPistol);
		//shotPistol.loopTime = false;
		//AnimationUtility.SetAnimationClipSettings(shotPistol, settings);
	
		}
		if(GameObject.Find("pistol")!=null && bulletsPistol>1){
		//UnityEditor.AnimationClipSettings settings = UnityEditor.AnimationUtility.GetAnimationClipSettings(shotPistol);
		//settings.loopTime = true;
		//UnityEditor.AnimationUtility.SetAnimationClipSettings(shotPistol, settings);

		}			
		shotgunReload();
		AKReload();
		if(GameObject.Find(AKName)!=null && bulletsAK==0){
			GameObject.Find(AKName).GetComponent<Animator>().SetBool("isShootingAK", false);	
		
		}
		
		 rigidBody = GetComponent<Rigidbody2D>();
		double timeSec = System.Math.Round(time, 2);
		reloadSec.text = "Reloading " + timeSec + "sec.";
		
		
		
			
			
			
			
		}
		
		
	
		
		

	
	
	
	
	public void Shoot(){
		
	
		fullbulletsShotgun=PlayerPrefs.GetInt("bulletsShotgun");
		
		if(GameObject.Find(shotgunName)!=null){
		if(isReloadingShotgun==false){
		if(fullbulletsShotgun==0 && bulletsShotgun==0){
			
		}
		else{
		
		
		
		
		
		StartCoroutine( shake.Shake(.0f+0.15f, 0f+0.15f));
		GameObject.Find(shotgunName).GetComponent<Animator>().SetBool("isShootingShotgun", true);
		
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = shotgunSound;
		audio.PlayOneShot(shotgunSound);
		
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		fakeBullet = Instantiate(fakeBulletPref, firePoint.position, firePoint.rotation);
		fakeBullet.name = "bulletShotgun";
		Rigidbody2D rb = fakeBullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.right * 20f, ForceMode2D.Impulse);
		
		photonView.RPC("changeName0", RpcTarget.Others);
		
		firePoint1.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z+2, gameObject.transform.rotation.eulerAngles.z+4));
		fakeBullet = Instantiate(fakeBulletPref, firePoint1.position, firePoint1.rotation);
		fakeBullet.name = "bulletShotgun";
		Rigidbody2D rb1 = fakeBullet.GetComponent<Rigidbody2D>();
		rb1.AddForce(firePoint1.right * 20f, ForceMode2D.Impulse);
		photonView.RPC("changeName1", RpcTarget.Others);
		
		firePoint2.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z+2, gameObject.transform.rotation.eulerAngles.z+4));
		fakeBullet = Instantiate(fakeBulletPref, firePoint2.position, firePoint2.rotation);
		fakeBullet.name = "bulletShotgun";
		Rigidbody2D rb2 = fakeBullet.GetComponent<Rigidbody2D>();
		rb2.AddForce(firePoint2.right * 20f, ForceMode2D.Impulse);
		photonView.RPC("changeName2", RpcTarget.Others);
		
		firePoint3.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z+3, gameObject.transform.rotation.eulerAngles.z+6));
		fakeBullet = Instantiate(fakeBulletPref, firePoint3.position, firePoint3.rotation);
		fakeBullet.name = "bulletShotgun";
		Rigidbody2D rb3 = fakeBullet.GetComponent<Rigidbody2D>();
		rb3.AddForce(firePoint3.right * 20f, ForceMode2D.Impulse);
		photonView.RPC("changeName3", RpcTarget.Others);
		
		
		firePoint4.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-3, gameObject.transform.rotation.eulerAngles.z-6));
		fakeBullet = Instantiate(fakeBulletPref, firePoint4.position, firePoint4.rotation);
		fakeBullet.name = "bulletShotgun";
		Rigidbody2D rb4 = fakeBullet.GetComponent<Rigidbody2D>();
		rb4.AddForce(firePoint4.right * 20f, ForceMode2D.Impulse);
		photonView.RPC("changeName4", RpcTarget.Others);
		
		firePoint5.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-5, gameObject.transform.rotation.eulerAngles.z-10)); 
		fakeBullet = Instantiate(fakeBulletPref, firePoint5.position, firePoint5.rotation);
		fakeBullet.name = "bulletShotgun";
		Rigidbody2D rb5 = fakeBullet.GetComponent<Rigidbody2D>();
		rb5.AddForce(firePoint5.right * 20f, ForceMode2D.Impulse);
		photonView.RPC("changeName5", RpcTarget.Others);
		
		firePoint6.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z+5, gameObject.transform.rotation.eulerAngles.z+10));
		fakeBullet = Instantiate(fakeBulletPref, firePoint6.position, firePoint6.rotation);
		fakeBullet.name = "bulletShotgun";
		Rigidbody2D rb6 = fakeBullet.GetComponent<Rigidbody2D>();
		rb6.AddForce(firePoint6.right * 20f, ForceMode2D.Impulse);
		photonView.RPC("changeName6", RpcTarget.Others);
		
	//	Destroy(bullet6, 1f);
		
		
		
		//bulletsShotgun--;
		
		
		
		}
		}
		}
		
		
		
		
		if(GameObject.Find(pistolName)!=null){
		if(isReloadingPistol==false){
		
		GameObject.Find(pistolName).GetComponent<Animator>().SetBool("isShootingPistol", true);
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		fakeBullet = Instantiate(fakeBulletPref, firePoint.position, firePoint.rotation);
		fakeBullet.name = "bulletPistol";
		Rigidbody2D rb = fakeBullet.GetComponent<Rigidbody2D>();
		
		rb.AddForce(firePoint.right* 30f, ForceMode2D.Impulse);
		
		bulletsPistol--;
		
		photonView.RPC("pistolShoot", RpcTarget.Others);
		photonView.RPC("soundPistol", RpcTarget.AllBuffered);
		
		
		}
		}
		
		
		fullbulletsAK=PlayerPrefs.GetInt("bulletsAK");
		if(GameObject.Find(AKName)!=null){
		if(isReloadingAK==false){
		if(fullbulletsAK==0 && bulletsAK==0){
			
		}
		else{
		
		GameObject.Find(AKName).GetComponent<Animator>().SetBool("isShootingAK", true);
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		fakeBullet = Instantiate(fakeBulletPref, firePoint.position, firePoint.rotation);
		fakeBullet.name = "bulletAK";
		Rigidbody2D rb = fakeBullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.right* 40f, ForceMode2D.Impulse);
		photonView.RPC("AKShoot", RpcTarget.Others);
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = AKSound;
		audio.PlayOneShot(AKSound);
		
		bulletsAK--;
		
		
		
		
		//Destroy(bullet, 0.5f);
		
		
		
		}
		}
		}
		
			
	}
	[PunRPC]
	public void pistolShoot(){
		GameObject.Find(pistolName).GetComponent<Animator>().SetBool("isShootingPistol", true);
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		
		bullet = PhotonNetwork.Instantiate(bulletPref.name, firePoint.position, firePoint.rotation,0);
		bullet.name = "bulletPistol";
		
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.right* 30f, ForceMode2D.Impulse);
	}
	[PunRPC]
	public void AKShoot(){
		GameObject.Find(AKName).GetComponent<Animator>().SetBool("isShootingAK", true);
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		
		bullet = PhotonNetwork.Instantiate(bulletPref.name, firePoint.position, firePoint.rotation,0);
		bullet.name = "bulletAK";
		
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.right* 40f, ForceMode2D.Impulse);
		
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = AKSound;
		audio.PlayOneShot(AKSound);
	}
	
	[PunRPC]
	public void changeName0(){
		
		GameObject.Find(shotgunName).GetComponent<Animator>().SetBool("isShootingShotgun", true);
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		bullet = PhotonNetwork.Instantiate(bulletShotgun.name, firePoint.position, firePoint.rotation,0);
		bullet.name = "bulletShotgun";
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		
		rb.AddForce(firePoint.right * 20f, ForceMode2D.Impulse);
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = shotgunSound;
		audio.PlayOneShot(shotgunSound);
		
	}
	[PunRPC]
	public void changeName1(){
		
		firePoint1.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z+2, gameObject.transform.rotation.eulerAngles.z+4));
		bullet1 = PhotonNetwork.Instantiate(bulletShotgun.name, firePoint1.position, firePoint1.rotation,0);
		bullet1.name = "bulletShotgun1";
	
		Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
		rb1.AddForce(firePoint1.right * 20f, ForceMode2D.Impulse);
	}
	[PunRPC]
	public void changeName2(){
		firePoint2.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z+2, gameObject.transform.rotation.eulerAngles.z+4));
		bullet2 = PhotonNetwork.Instantiate(bulletShotgun.name, firePoint2.position, firePoint2.rotation,0);
		bullet2.name = "bulletShotgun2";
		
		Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
		rb2.AddForce(firePoint2.right * 20f, ForceMode2D.Impulse);
	}
	[PunRPC]
	public void changeName3(){
		firePoint3.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z+3, gameObject.transform.rotation.eulerAngles.z+6));
		bullet3 = PhotonNetwork.Instantiate(bulletShotgun.name, firePoint3.position, firePoint3.rotation,0);
		bullet3.name = "bulletShotgun3";
		
		Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
		rb3.AddForce(firePoint3.right * 20f, ForceMode2D.Impulse);
	}
	[PunRPC]
	public void changeName4(){
		firePoint4.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-3, gameObject.transform.rotation.eulerAngles.z-6));
		bullet4 = PhotonNetwork.Instantiate(bulletShotgun.name, firePoint4.position, firePoint4.rotation,0);
		bullet4.name = "bulletShotgun4";
		
		Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
		rb4.AddForce(firePoint4.right * 20f, ForceMode2D.Impulse);
	}
	[PunRPC]
	public void changeName5(){
		firePoint5.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-5, gameObject.transform.rotation.eulerAngles.z-10)); 
		bullet5 = PhotonNetwork.Instantiate(bulletShotgun.name, firePoint5.position, firePoint5.rotation,0);
		bullet5.name = "bulletShotgun5";
		
		Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
		rb5.AddForce(firePoint5.right * 20f, ForceMode2D.Impulse);
	}
	[PunRPC]
	public void changeName6(){
		firePoint6.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z+5, gameObject.transform.rotation.eulerAngles.z+10));
		bullet6 = PhotonNetwork.Instantiate(bulletShotgun.name, firePoint6.position, firePoint6.rotation,0);
		bullet6.name = "bulletShotgun6";
		Rigidbody2D rb6 = bullet6.GetComponent<Rigidbody2D>();
		rb6.AddForce(firePoint6.right * 20f, ForceMode2D.Impulse);
	}
	
	[PunRPC]
	public void soundPistol(){
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = pistolSound;
		audio.PlayOneShot(pistolSound);
		
		
		
		
			
	}

public void OnButtonDown(){
	
		
		photonView.RPC("ButtonDown", RpcTarget.AllBuffered , null);
		
	
}
public void OnButtonUp(){
	//if(this.GetComponent<PhotonView>().ViewID==1001){
		
		//photonView.RPC("ButtonUp", RpcTarget.All,null);
		photonView.RPC("ButtonUp", RpcTarget.AllBuffered,null);
		//ButtonUp();	
	//}
	//else{
	//	photonView.RPC("ButtonUp", RpcTarget.Others, null);	
	//}
}
	[PunRPC]
	public void ButtonDown(){
		
if(bulletsPistol>0 && GameObject.Find(pistolName)!=null){         
		 click=1;
}
if(bulletsShotgun>0 && GameObject.Find(shotgunName)!=null){
	click=1;
}
if(bulletsAK>0 && GameObject.Find(AKName)!=null){
	click=1;
}
		  fullbulletsAK=PlayerPrefs.GetInt("bulletsAK");
		if(GameObject.Find(AKName)!=null){
			GameObject.Find(AKName).GetComponent<Animator>().SetBool("isShootingAK", true);	
		
		
		if(fullbulletsAK==0 && bulletsAK==0){
			
			play = GameObject.Find("Sound");
			AudioSource audio = play.GetComponent<AudioSource>();
			audio.clip = AKEmpty;
			audio.PlayOneShot(AKEmpty);
		}
		
		
		 	}
			fullbulletsShotgun=PlayerPrefs.GetInt("bulletsShotgun");
		if(GameObject.Find(shotgunName)!=null){
			
		if(fullbulletsShotgun==0 && bulletsShotgun==0){
			GameObject.Find(shotgunName).GetComponent<Animator>().SetBool("isShootingShotgun", false);	
			play = GameObject.Find("Sound");
			AudioSource audio = play.GetComponent<AudioSource>();
			audio.clip = shotgunEmpty;
			audio.PlayOneShot(shotgunEmpty);
		}
		}
		
		}
		
		
	
	
	[PunRPC]
	public void ButtonUp(){
		
           click=0;
		  if(GameObject.Find(pistolName)!=null){
			  GameObject.Find(pistolName).GetComponent<Animator>().SetBool("isShootingPistol", false);
		  }
			if(GameObject.Find(AKName)!=null){
			 GameObject.Find(AKName).GetComponent<Animator>().SetBool("isShootingAK", false);
		  }
		  if(GameObject.Find(shotgunName)!=null){
			  GameObject.Find(shotgunName).GetComponent<Animator>().SetBool("isShootingShotgun", false);	
		  }
		 
			
		
		  // GameObject.Find("Main Camera").GetComponent<CamFollow>().enabled = true;
				
	}
	void pistolReload(){
		if(GameObject.Find(pistolName)!=null){
		bulletsAmount.text = "" + bulletsPistol + "/" + "∞";
		bulletsAmount1.text = "" + bulletsPistol + "/" + "∞";		
			
		if(bulletsPistol==0){
			isReloadingPistol=true;
			
		}
		else{
			isReloadingPistol=false;
		}
		
        if(isReloadingPistol==true){
			
		//GameObject.Find("pistol").GetComponent<Animator>().SetBool("isReloadingPistol", true);
		//GameObject.Find("pistol").transform.GetChild(0).gameObject.SetActive(true);
		reloadText.SetActive(true);
		gameObject.GetComponent<sniperShooting>().enabled = false;
	
		gameObject.GetComponent<bazookaShooting>().enabled = false;
		gameObject.GetComponent<FreezeGunShooting>().enabled = false;
		if(PlayerPrefs.GetInt("sfx")==0){
		GameObject.Find(pistolName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = true;
		}
		
		
		time-=Time.deltaTime;
		
		if(time<0){
			
			bulletsPistol=10;
			time=1;
			GameObject.Find(pistolName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = false;
			reloadText.SetActive(false);
			
		}
		
		}
		else{
			gameObject.GetComponent<sniperShooting>().enabled = true;
			gameObject.GetComponent<bazookaShooting>().enabled = true;
			gameObject.GetComponent<FreezeGunShooting>().enabled = true;
		//GameObject.Find("pistol").GetComponent<Animator>().SetBool("isReloadingPistol", false);
		
		
		}
		}
	}
	void shotgunReload(){
		
		
		fullbulletsShotgun = PlayerPrefs.GetInt("bulletsShotgun");
		
		if(GameObject.Find(shotgunName)!=null){				
			bulletsAmount.text = "" + bulletsShotgun + "/" + fullbulletsShotgun;
			bulletsAmount1.text = "" + bulletsShotgun + "/" + fullbulletsShotgun;			

		if(bulletsShotgun==0 && fullbulletsShotgun>0){
			isReloadingShotgun=true;
		}
		else{
			isReloadingShotgun=false;
		}
		
        
		if(isReloadingShotgun==true){
		//GameObject.Find("shotgun").GetComponent<Animator>().SetBool("isReloadingShotgun", true);
		
			reloadText.SetActive(true);
				gameObject.GetComponent<sniperShooting>().enabled = false;
				if(PlayerPrefs.GetInt("sfx")==0){
		GameObject.Find(shotgunName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = true;
				}
		
		time-=Time.deltaTime;
		if(time<0){
			bulletsShotgun=2;
			fullbulletsShotgun=PlayerPrefs.GetInt("bulletsShotgun");
			fullbulletsShotgun-=2;
			GameObject.Find(shotgunName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = false;
			reloadText.SetActive(false);
			PlayerPrefs.SetInt("bulletsShotgun",fullbulletsShotgun);
			time=1;
			
			
		}
		
		}
		else{
				gameObject.GetComponent<sniperShooting>().enabled = true;
		//GameObject.Find("shotgun").GetComponent<Animator>().SetBool("isReloadingShotgun", false);
		
		}
		}
	}
	void AKReload(){
		fullbulletsAK = PlayerPrefs.GetInt("bulletsAK");
		
		if(GameObject.Find(AKName)!=null){				
			bulletsAmount.text = "" + bulletsAK + "/" + fullbulletsAK;
			bulletsAmount1.text = "" + bulletsAK + "/" + fullbulletsAK;			

		if(bulletsAK==0 && fullbulletsAK>0){
			isReloadingAK=true;
		}
		else{
			isReloadingAK=false;
		}
		
        
		if(isReloadingAK==true){
		//GameObject.Find(AKName).GetComponent<Animator>().SetBool("isReloadingAK", true);
		reloadText.SetActive(true);
			gameObject.GetComponent<sniperShooting>().enabled = false;
			if(PlayerPrefs.GetInt("sfx")==0){
		GameObject.Find(AKName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = true;
			}
		
		
		time-=(Time.deltaTime*0.9f);
		if(time<0){
			bulletsAK=30;
			fullbulletsAK=PlayerPrefs.GetInt("bulletsAK");
			fullbulletsAK-=30;
			GameObject.Find(AKName).transform.GetChild(0).gameObject.GetComponent<AudioSource>().enabled = false;
			reloadText.SetActive(false);
			PlayerPrefs.SetInt("bulletsAK",fullbulletsAK);
			time=1;
			
			
		}
		
		}
		else{
				gameObject.GetComponent<sniperShooting>().enabled = true;
	//	GameObject.Find(AKName).GetComponent<Animator>().SetBool("isReloadingAK", false);
		
		}
		}
	}
	
	
	
	
}
