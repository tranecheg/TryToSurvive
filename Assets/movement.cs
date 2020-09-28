using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour
{
    private float speedMove = 3.5f;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    public Joystick joystick;
	public GameObject joystickObject;
	public float joystickX;
	public float joystickY;
	public float joystickXY;
	
	
	public int health;
	public Text healthTxt;
	
	public int click;
	
	float padding = 0.3f;
	float time = 10f;
	float timeDeath = 1f;
	public static Vector3 Position;
	
	public GameObject zombie;
	
	private PhotonView photonView;
	public TextMeshPro NickNameText;
	public int spaw;
	public AudioClip moneySound, healthSound, speedSound;
	
	public GameObject playeDead;
	
	private bool isMoving = false;
	public float vel;
	
	public float timePos;
	public Vector3 currentPos, lastPos;

	private Vector3 priorFrameTransform;
	private string pistolName, shotgunName, AKName, sniperName, flameThroverName, bazookaName, freezeGunName;
	
	Vector3 syncPos = Vector3.zero;
    Quaternion syncRot = Quaternion.identity;
	
	void Start(){
		
	photonView = GetComponent<PhotonView>();
	
    rb = GetComponent<Rigidbody2D>();
	
	health=100;
	
	healthTxt.text = "" + health;
	

	
	NickNameText.SetText(photonView.Owner.NickName);
	if(photonView.IsMine){
		NickNameText.color = Color.green;
		gameObject.transform.GetChild(13).gameObject.SetActive(true);
		
	}
	
		gameObject.name = photonView.Owner.NickName; 
	  
	pistolName = "pistol" + gameObject.name;
	shotgunName = "shotgun" + gameObject.name;
	AKName = "AK" + gameObject.name;
	sniperName = "sniperRifle" + gameObject.name;
	flameThroverName = "flameThrover" + gameObject.name;
	bazookaName = "bazooka" + gameObject.name;
	freezeGunName = "freezeGun" + gameObject.name;
}

	
	void Update(){
		
		if(Time.timeScale == 0.025f){
			gameObject.transform.GetChild(13).gameObject.transform.GetChild(10).gameObject.SetActive(true);
		}
		else{
		gameObject.transform.GetChild(13).gameObject.transform.GetChild(10).gameObject.SetActive(false);	
		}
		
	
		 if(rb.IsSleeping()){
			isMoving = false;
						
		 }
		 else{
		 isMoving = true;
		 }
		if(!photonView.IsMine){
			healthTxt.enabled = false;
		}
		else{
			healthTxt.enabled = true;
		}
		healthTxt.text = "" + health;
		if(health <=0){
			timeDeath-=Time.deltaTime;
		if(timeDeath<1f && timeDeath>0.96f){
		healthTxt.enabled = false;
		Instantiate(playeDead, gameObject.transform.position, Quaternion.Euler(new Vector3(0 , 0, gameObject.transform.rotation.eulerAngles.z)));
		gameObject.tag = "Untagged";
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
		gameObject.transform.GetChild(12).gameObject.SetActive(false);
		
		
		GameObject.Find("Main Camera").transform.GetChild(0).gameObject.transform.GetChild(7).gameObject.SetActive(false);
		rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
		
		}
			//Destroy(gameObject);
		}
		else{
	healthTxt.enabled = true;
		
	gameObject.transform.GetChild(0).gameObject.SetActive(true);
	gameObject.transform.GetChild(12).gameObject.SetActive(true);
		
	
	rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			
		}
		
		if(GameObject.FindGameObjectWithTag("Enemy")==null){
			health=100;
			if(gameObject.tag=="Player"){
			}
			else{
				gameObject.tag = "Player";
			}
		}
		
		//rb.velocity = Vector2.zero;
		
		
			if(speedMove==6f){
			time-=Time.deltaTime;
			if(time<0){
			speedMove=3.5f;
			}
						
			}
			
			
			
			
			
	//transform.position = new Vector2(Mathf.Clamp(transform.position.x, -10f, 10f), Mathf.Clamp(transform.position.y, -10f, 10f));
		
	
}
[PunRPC]
public void testMove(){
			if(GameObject.Find(pistolName)!=null){
			//if(rb.IsSleeping()==true){
				if(isMoving==false && 	GameObject.Find(pistolName).GetComponent<Animator>().GetBool("isShootingPistol")==false){
					
				GameObject.Find(pistolName).GetComponent<Animator>().SetBool("isStaying", true);
				
			}
			else{
				GameObject.Find(pistolName).GetComponent<Animator>().SetBool("isStaying", false);
				
			}
			}
			if(GameObject.Find(shotgunName)!=null){
			
				if(isMoving==false && 	GameObject.Find(shotgunName).GetComponent<Animator>().GetBool("isShootingShotgun")==false){
				
				
				GameObject.Find(shotgunName).GetComponent<Animator>().SetBool("isStaying", true);
				
			}
			else{
				GameObject.Find(shotgunName).GetComponent<Animator>().SetBool("isStaying", false);
				
			}
			}
			if(GameObject.Find(AKName)!=null){
			if(isMoving==false && 	GameObject.Find(AKName).GetComponent<Animator>().GetBool("isShootingAK")==false){
				GameObject.Find(AKName).GetComponent<Animator>().SetBool("isStaying", true);
			}
			else{
				GameObject.Find(AKName).GetComponent<Animator>().SetBool("isStaying", false);
			}
			}
			
			if(GameObject.Find(sniperName)!=null){
			if(isMoving==false && 	GameObject.Find(sniperName).GetComponent<Animator>().GetBool("isShootingSniper")==false){
				GameObject.Find(sniperName).GetComponent<Animator>().SetBool("isStaying", true);
			}
			else{
				GameObject.Find(sniperName).GetComponent<Animator>().SetBool("isStaying", false);
			}
			}
			
			if(GameObject.Find(flameThroverName)!=null){
			if(isMoving==false && 	GameObject.Find(flameThroverName).GetComponent<Animator>().GetBool("isShootingFlameThrover")==false){
				GameObject.Find(flameThroverName).GetComponent<Animator>().SetBool("isStaying", true);
			}
			else{
				GameObject.Find(flameThroverName).GetComponent<Animator>().SetBool("isStaying", false);
			}
			}
			
			if(GameObject.Find(bazookaName)!=null){
			if(isMoving==false && 	GameObject.Find(bazookaName).GetComponent<Animator>().GetBool("isShootingBazooka")==false){
				GameObject.Find(bazookaName).GetComponent<Animator>().SetBool("isStaying", true);
			}
			else{
				GameObject.Find(bazookaName).GetComponent<Animator>().SetBool("isStaying", false);
			}
			}
			if(GameObject.Find(freezeGunName)!=null){
			if(isMoving==false && 	GameObject.Find(freezeGunName).GetComponent<Animator>().GetBool("isShootingFreezeGun")==false){
				GameObject.Find(freezeGunName).GetComponent<Animator>().SetBool("isStaying", true);
			}
			else{
				GameObject.Find(freezeGunName).GetComponent<Animator>().SetBool("isStaying", false);
			}
			}
			
	}
	
			

    public void FixedUpdate() {
		
		photonView.RPC("test", RpcTarget.All, null);
		//test();
		
		 photonView.RPC("testMove", RpcTarget.AllBuffered, null);
		
		

    }
	
	
	
	[PunRPC]
	public void test(){
	if(!photonView.IsMine) return;
		
		joystickObject = GameObject.FindWithTag("Joystick");
 
    if(joystickObject != null)
    {
        joystick = joystickObject.GetComponent<Joystick>();
    }
		
		 
        moveVector = Vector3.zero;
       moveVector.x = joystick.Horizontal * speedMove;
       moveVector.y = joystick.Vertical * speedMove;
		 
		 
		
		
		GameObject treshold = GameObject.Find("Background");
		GameObject image = GameObject.Find("Handle");
		if(image==null){
			
		}
		else{
			
			
			
		joystickX = image.transform.position.x - treshold.transform.position.x;
		joystickY = image.transform.position.y - 256f;
		
		
		if(joystickX!=0){
		  float heading = Mathf.Atan2(moveVector.y,moveVector.x);
	//	 isMoving=true;
		  
		  if(GameObject.Find(pistolName)!=null && GameObject.Find(pistolName).GetComponent<Animator>().GetBool("isShootingPistol")==false){
		   transform.rotation=Quaternion.Euler(0f,0f,heading*Mathf.Rad2Deg);
		  }
		  else if(GameObject.Find(AKName)!=null && GameObject.Find(AKName).GetComponent<Animator>().GetBool("isShootingAK")==false){
			 transform.rotation=Quaternion.Euler(0f,0f,heading*Mathf.Rad2Deg); 
		  }
		  else if(GameObject.Find(shotgunName)!=null && GameObject.Find(shotgunName).GetComponent<Animator>().GetBool("isShootingShotgun")==false){
			 transform.rotation=Quaternion.Euler(0f,0f,heading*Mathf.Rad2Deg); 
		  }
		  else if(GameObject.Find(sniperName)!=null && GameObject.Find(sniperName).GetComponent<Animator>().GetBool("isShootingSniper")==false){
			 transform.rotation=Quaternion.Euler(0f,0f,heading*Mathf.Rad2Deg); 
		  }
		  else if(GameObject.Find(bazookaName)!=null && GameObject.Find(bazookaName).GetComponent<Animator>().GetBool("isShootingBazooka")==false){
			 transform.rotation=Quaternion.Euler(0f,0f,heading*Mathf.Rad2Deg); 
		  }
		  else if(GameObject.Find(flameThroverName)!=null){
			 transform.rotation=Quaternion.Euler(0f,0f,heading*Mathf.Rad2Deg); 
		  }
		  else if(GameObject.Find(freezeGunName)!=null && GameObject.Find(freezeGunName).GetComponent<Animator>().GetBool("isShootingFreezeGun")==false){
			 transform.rotation=Quaternion.Euler(0f,0f,heading*Mathf.Rad2Deg); 
		  }
		  else{
			  
		  }
		  
			
		rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime); // move
		}
		else{
			//rb.Sleep();
	//	isMoving=false;
		}
	}
	
	}
	
	
	private void OnTriggerEnter2D(Collider2D col)
    {
		
		if(col.tag == "zombieAttack"){
			health-=PlayerPrefs.GetInt("stage")*100;
			
			//this.transform.GetChild(1).gameObject.SetActive(false);
			//rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
		}
		if(col.tag == "zombieAttack2"){
			health-=PlayerPrefs.GetInt("stage")*3;
			
		}
		if(col.tag == "zombieAttack3"){
			health-=PlayerPrefs.GetInt("stage")*4;
			
		}
		if(col.tag == "zombieAttack4"){
			health-=PlayerPrefs.GetInt("stage")*5;
			
		}
		if(col.tag == "zombieAttack5"){
			health-=PlayerPrefs.GetInt("stage")*6;
			
		}
		if(col.tag == "health"){
			GameObject play = GameObject.Find("SoundLoot");
			AudioSource audio = play.GetComponent<AudioSource>();
			audio.clip = healthSound;
			audio.PlayOneShot(healthSound);
			health=100;
			
		}
		if(col.tag == "money"){
			GameObject play = GameObject.Find("SoundLoot");
			AudioSource audio = play.GetComponent<AudioSource>();
			audio.clip = moneySound;
			audio.PlayOneShot(moneySound);
			int money = PlayerPrefs.GetInt("money");
			money+=500;
			PlayerPrefs.SetInt("money", money);
			
		}
		if(col.tag == "speedUp"){
			GameObject play = GameObject.Find("SoundLoot");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = speedSound;
		audio.PlayOneShot(speedSound);
			speedMove=6f;
			time = 10f;
			
		}
		if(col.tag=="Player"){
			
			if(!photonView.IsMine){
			rb.mass=100;
			}
		}
		
		
        
    }
	
	void OnTriggerExit2D(Collider2D col)
    {
		if(col.tag == "Enemy"){
		
			rb.velocity = Vector2.zero;
		}
		if(col.tag == "zombieAttack"){
		
			
		}
		if(col.tag=="Player"){
		//	gameObject.GetComponent<PhotonRigidbody2DView>().enabled = false;
		if(!photonView.IsMine){
		rb.mass=1;	
		}		
		}
		
        
    }
	public void quitGame(){
		
		Time.timeScale = 1;
		
		if(PhotonNetwork.IsMasterClient){
		PhotonNetwork.Disconnect();
		SceneManager.LoadScene("Load");		
		}
		else{
		if (PhotonNetwork.InRoom)
		{
        PhotonNetwork.LeaveRoom();
		PhotonNetwork.Disconnect();
		}
				
		}
		
	}
	
	
	
	
    
}
