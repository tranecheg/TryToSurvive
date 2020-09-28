using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class turret : MonoBehaviour
{
    public Transform firePoint;
	
	private Transform enemy;
	GameObject[] enemies;
	GameObject closest;
	public string nearest;
	public float rotateCheck, playerRotate, enemyRotate;
	private float angle;
	private Rigidbody2D rb;
	
	public GameObject bulletPref;
	public GameObject bullet;
	public float bulletForce = 10f;
	private float nextTimeOfFire = 0;
	
	public AudioClip turretSound;
	public GameObject play;
	
	public int health=100;
	
	
	
	public int bulletsTurret;
	 
	 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
		gameObject.name = "turret";
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
	void FixedUpdate(){
		
			
			
	}

    // Update is called once per frame
    void Update()
    {
		bulletsTurret = PlayerPrefs.GetInt("bulletsTurret");
		if(PlayerPrefs.GetInt("countSpawn")>0){
			transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
		else{
			transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
		if(health<=0){
		  Destroy(transform.parent.gameObject);
	   }
       if(GameObject.FindGameObjectWithTag("Enemy")!=null){
			
			enemies =  GameObject.FindGameObjectsWithTag("Enemy");
			nearest = FindClosest().name;
			enemy = GameObject.Find(nearest).transform;
			
			if(GameObject.Find(nearest).transform.parent.GetComponent<SpriteRenderer>().isVisible==true){
			Vector3 direction = enemy.position - transform.position;
			angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
			rb.rotation = angle;		
			if(Time.time >= nextTimeOfFire)
            {
			
			Shoot();
			nextTimeOfFire = Time.time + 0.3f;
			}
			
			
			}
			if(GameObject.Find(nearest).GetComponent<SpriteRenderer>().isVisible==false){
				
				
			}
			
		}
		
		
		
    }
	public void Shoot(){
	
		if(GameObject.Find("turret")!=null && PlayerPrefs.GetInt("bulletsTurret")>0){
		
		
		
		firePoint.transform.rotation = Quaternion.Euler (0,0,Random.Range(gameObject.transform.rotation.eulerAngles.z-1, gameObject.transform.rotation.eulerAngles.z+1));
		//firePoint.transform.Rotate(0,0,Random.Range(0.5f, -0.5f));
		
		
		bullet = PhotonNetwork.Instantiate(bulletPref.name, firePoint.position, firePoint.rotation);
		bullet.name = "bulletTurret";
		
		play = GameObject.Find("Sound");
		AudioSource audio = play.GetComponent<AudioSource>();
		audio.clip = turretSound;
		audio.PlayOneShot(turretSound);
		
		bulletsTurret = PlayerPrefs.GetInt("bulletsTurret");
		
		bulletsTurret--;
		PlayerPrefs.SetInt("bulletsTurret", bulletsTurret);
		
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		bulletForce = 40f; //40f
		rb.AddForce(firePoint.right* bulletForce, ForceMode2D.Impulse);
		
		Destroy(bullet, 1f);
		
		
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag==("zombieAttack")){
			health-=1;
			
		}
		if(col.tag==("zombieAttack2")){
			health-=2;
		}
		if(col.tag==("zombieAttack3")){
			health-=3;
		}
		if(col.tag==("zombieAttack4")){
			health-=4;
		}
		if(col.tag==("zombieAttack5")){
			health-=5;
		}
		
		
	}
	
}
