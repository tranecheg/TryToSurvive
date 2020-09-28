using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Photon.Pun;
using UnityEngine.UI;



public class FlameThroverShooting : MonoBehaviour
{
    public Transform firePoint;

	public GameObject bulletPref;
	public GameObject bullet;
	
	public float bulletForce = 10f;
	
	public float bulletPos, playerPos;
	public float rotateCheck, playerRotate, enemyRotate;
	private float angle;
	private float nextTimeOfFire = 0;
	  
	  public int click;
	   private PhotonView photonView;
	   public GameObject play;
	   public string name;
	   
	   public AudioClip flameThroverSound, flameThroverEmpty;
	   
	  
	   public int bulletsFlameThrover = 50;
		
		public int fullbulletsFlameThrover;
		
	   
	     private Animator anim;
		
		
	
	public bool isReloadingFlameThrover, isWalkingWithFlameThrover;
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
	  public string flameThroverName;
	 

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
	photonView = GetComponent<PhotonView>();	
	flameThroverName = "flameThrover" + gameObject.name;
	
		
		
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
    void FixedUpdate()
    {
		
		
		
		//if(!photonView.IsMine) return;
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
			if(GameObject.Find(flameThroverName)!=null){
			this.transform.rotation = Quaternion.Euler(0,0,angle);
			}
			
						
			}
			if(GameObject.Find(nearest).transform.parent.gameObject.GetComponent<SpriteRenderer>().isVisible==false){
				
				
			}
			
		}
		else{
			
			click=0;
			if(GameObject.Find(flameThroverName)!=null){
			GameObject.Find(flameThroverName).GetComponent<Animator>().SetBool("isShootingFlameThrover", false);
				GameObject.Find(flameThroverName).transform.GetChild(9).gameObject.SetActive(false);		
			}
		}
			
			
			
			
			
			
		 if(Time.time >= nextTimeOfFire)
            {
		
		
		Shoot();
		
		if(GameObject.Find(flameThroverName)!=null){
			nextTimeOfFire = Time.time + 0.5f;
			
			if(fullbulletsFlameThrover==0){
				GameObject.Find(flameThroverName).GetComponent<Animator>().SetBool("isShootingFlameThrover", false);
				GameObject.Find(flameThroverName).transform.GetChild(9).gameObject.SetActive(false);	
				
			
			}
			else{
		
			
			}
			
			
			
			
			
			
					
		
		}
		
		}
		
		
		
    }
	}
	
	
	
	void Update(){
		
		fullbulletsFlameThrover=PlayerPrefs.GetInt("bulletsFlameThrover");
			if(GameObject.Find(flameThroverName)!=null){
			bulletsAmount.text = "" + fullbulletsFlameThrover;
			}
		
		 rigidBody = GetComponent<Rigidbody2D>();
		
		
		
		if(GameObject.FindGameObjectWithTag("Enemy")!=null){
			
		
		
	
		
		
		
	}
	}
	
	
	
	
	private void Shoot(){
		
	
		fullbulletsFlameThrover=PlayerPrefs.GetInt("bulletsFlameThrover");
		if(GameObject.Find(flameThroverName)!=null){
	
		if(fullbulletsFlameThrover==0){
			
		}
		else{
		
		
		photonView.RPC("shotOn", RpcTarget.All);
		
		
				
		
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		//Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		//bulletForce = 50f;
		//rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
		//Destroy(bullet, 1f);
		
			
		
		fullbulletsFlameThrover--;
		PlayerPrefs.SetInt("bulletsFlameThrover", fullbulletsFlameThrover);
		
		
		
		}
		}
		}
		
	[PunRPC]
	public void shotOn(){
	gameObject.transform.GetChild(0).gameObject.transform.Find(flameThroverName).gameObject.GetComponent<Animator>().SetBool("isShootingFlameThrover", true);
	gameObject.transform.GetChild(0).gameObject.transform.Find(flameThroverName).gameObject.transform.GetChild(9).gameObject.SetActive(true);
	}
	
	[PunRPC]
	public void shotOff(){
	gameObject.transform.GetChild(0).gameObject.transform.Find(flameThroverName).gameObject.GetComponent<Animator>().SetBool("isShootingFlameThrover", false);
	gameObject.transform.GetChild(0).gameObject.transform.Find(flameThroverName).gameObject.transform.GetChild(9).gameObject.SetActive(false);
	}
		
			
	
	public void OnButtonDown(){
		
           click=1;
		  
		  
			fullbulletsFlameThrover=PlayerPrefs.GetInt("bulletsFlameThrover");
		if(GameObject.Find(flameThroverName)!=null){
			
		if(fullbulletsFlameThrover==0){
			GameObject.Find(flameThroverName).GetComponent<Animator>().SetBool("isShootingFlameThrover", false);	
			play = GameObject.Find("Sound");
			AudioSource audio = play.GetComponent<AudioSource>();
			audio.clip = flameThroverEmpty;
			audio.PlayOneShot(flameThroverEmpty);
		}
		
	
		}
		
	}
	public void OnButtonUp(){
		
           click=0;
		  
		  if(GameObject.Find(flameThroverName)!=null){
			//  GameObject.Find(flameThroverName).GetComponent<Animator>().SetBool("isShootingFlameThrover", false);
			photonView.RPC("shotOff", RpcTarget.All);			  
		  }
		 
			
		
		  // GameObject.Find("Main Camera").GetComponent<CamFollow>().enabled = true;
				
	}
	
	
	
	
	
	
	
	
	
}