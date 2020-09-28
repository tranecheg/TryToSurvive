using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class EnemyLevel3 : MonoBehaviour
{
	public int health;
	private Transform player, barricade, turret;
	
	private Rigidbody2D rb;
	private Vector2 move;
	private GameObject enemy;
	
	public GameObject[] numberEnemy;
	
	private Animator anim;
	
	public bool isAttacking, isDying, isBleeding;
	public bool flame;
	
	float x, y;
	private float SpawnRadius, speedMove;
	public float playerDistance, barricadeDistance, turretDistance; 
	private float StartSpawn = 10f;
	
	
	public bool hand, death = false;
	private GameObject child;
	public int stage, countSpawn3, randomNumber;
	
	GameObject[] players;
	GameObject closest;
	public string nearest;
	
	GameObject[] barricades;
	GameObject closestBarricade;
	public string nearestBarricade;
	
	GameObject[] turrets;
	GameObject closestTurret;
	public string nearestTurret;
	
	public GameObject deadPref;
	private float time = 0.3f;
	private float timeStop = 0.2f;
	private float timeRandom = 3f;
	private float timer = 1f;
	[System.Serializable]
  public class Drop{
	  public string name;
	  public GameObject item;
	  public int dropRarity;
  }
  public List <Drop> lootItems = new List<Drop>();
  public int dropChance;
	
    void Start()
    {
       rb = this.GetComponent<Rigidbody2D>();
	   
	   anim = gameObject.GetComponent<Animator>();
	   
	   stage = PlayerPrefs.GetInt("stage");
	   
	   players =  GameObject.FindGameObjectsWithTag("Player"); 
	  
	   
	   if(gameObject.transform.GetChild(1).name==("Hand3")){
		   health = stage*15 + 290;
	   }
	    gameObject.transform.GetChild(0).gameObject.name = "Attack" + gameObject.name;
	   
    }
	
	GameObject FindClosest(){
	float distance = Mathf.Infinity;
	Vector3 position = transform.position;
	if(GameObject.FindGameObjectWithTag("Player")!=null){
	foreach (GameObject go in players){
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
	
	GameObject FindClosestBarricade(){
	float distance = Mathf.Infinity;
	Vector3 position = transform.position;
	if(GameObject.FindGameObjectWithTag("barricade")!=null){
	foreach (GameObject go in barricades){
		Vector3 diff = go.transform.position - position;
		float curDistance = diff.sqrMagnitude;
		if(curDistance<distance){
			closestBarricade = go;
			distance = curDistance;
		}
	}
	}
	return closestBarricade;
	}
	
	GameObject FindClosestTurret(){
	float distance = Mathf.Infinity;
	Vector3 position = transform.position;
	if(GameObject.FindGameObjectWithTag("turret")!=null){
	foreach (GameObject go in turrets){
		Vector3 diff = go.transform.position - position;
		float curDistance = diff.sqrMagnitude;
		if(curDistance<distance){
			closestTurret = go;
			distance = curDistance;
		}
	}
	}
	return closestTurret;
	}
	
	


    // Update is called once per frame
    void Update()
    {
		if(death == true){
			health=0;
		}
		timeRandom-=Time.deltaTime;
		if(timeRandom<0){
		 randomNumber = Random.Range(1, 3);
		 timeRandom = 3f;
		}
		if(health <=0){
			isDying=true;
			}
		if(flame==true){
			Enemy zombie = this.GetComponent<Enemy>();
			//zombie.TakeDamage(2);
			this.TakeDamage(2);
		}
		else{
			
		}
		
	//	player = GameObject.FindWithTag("Player").transform;
	stage = PlayerPrefs.GetInt("stage");


	if(GameObject.FindGameObjectWithTag("Player")!=null){ 
		
		players =  GameObject.FindGameObjectsWithTag("Player");
		nearest = FindClosest().name;
		player = GameObject.Find(nearest).transform;
		playerDistance = Vector3.Distance(player.position, gameObject.transform.position);
		if(playerDistance<1.2f){
			speedMove = 0;
			rb.mass = 100;
		}
		else if(randomNumber==2){
		speedMove = 0.9f+(stage*0.1f) + 2f;
			rb.mass = 0;
		}
		else if (playerDistance>3){
		speedMove = 0.9f+(stage*0.1f) + 3f;
			rb.mass = 0;
		}
		else if (playerDistance<3 && playerDistance>1.2 && randomNumber<2){
		speedMove = 1.3f+(stage*0.2f);
			rb.mass = 0;
		}	
	if(GameObject.FindGameObjectWithTag("barricade")!=null){
		barricades = GameObject.FindGameObjectsWithTag("barricade");
		nearestBarricade = FindClosestBarricade().name;
		barricade = GameObject.Find(nearestBarricade).transform;
		barricadeDistance = Vector3.Distance(barricade.position, gameObject.transform.position);
	}
	else{
		barricadeDistance=10f;
	}
	
	if(GameObject.FindGameObjectWithTag("turret")!=null){
		turrets = GameObject.FindGameObjectsWithTag("turret");
		nearestTurret = FindClosestTurret().name;
		turret = GameObject.Find(nearestTurret).transform;
		turretDistance = Vector3.Distance(turret.position, gameObject.transform.position);
	}
	else{
		
	}
		
		if(playerDistance<1.5){
			isAttacking=true;	
		}
		else if(barricadeDistance<1.35){
			isAttacking=true;	
		}	
		
		else{
		isAttacking=false;
		}
		
		if(isAttacking==true){
		anim.SetBool("isAttacking", true);
		
		}
		else{
		anim.SetBool("isAttacking", false);
		}
		
		if(isDying==true){
		anim.SetBool("isDying", true);
		rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
		anim.SetBool("isAttacking", false);
		
		}
		else{
		anim.SetBool("isDying", false);
		}
		if(isBleeding==true){
			anim.SetBool("isBleeding", true);
			timeStop-=Time.deltaTime;
			if(timeStop<0){
				isBleeding=false;
				timeStop=0.2f;
				anim.SetBool("isBleeding", false);
				
			}
		}
				
		SpawnRadius = StartSpawn;
	}
	else{
		isAttacking=false;
		anim.SetBool("isAttacking", false);
	}
	  
	  if(GameObject.FindGameObjectWithTag("Player")==null){
		  speedMove = 1f;
	   Vector3 direction  = transform.position;
	   float angle  = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		rb.rotation = angle;
		direction.Normalize();
		move = direction;
		
	  }
	  else{
		  
		  Vector3 direction  = player.position - transform.position;
		  float angle  = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		
		
		rb.rotation = angle;
		direction.Normalize();
		move = direction;
	  }
		
		 stage = PlayerPrefs.GetInt("stage");
		
		 var animatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);
		 
		if (animatorStateInfo.IsName("zombie3Death")){
			time -=Time.deltaTime;
			
			if(time < 0){
		isBleeding = false;
		isAttacking = false;		
		Instantiate(deadPref, gameObject.transform.position, Quaternion.Euler(new Vector3(0 , 0, gameObject.transform.rotation.eulerAngles.z)));
		int money = PlayerPrefs.GetInt("money");
		
				
		
		countSpawn3 = PlayerPrefs.GetInt("countSpawn3"); 
		 if(gameObject.transform.GetChild(1).name==("Hand3")){
			 money+=300; 
			 PlayerPrefs.SetInt("money", money);
			calculateLoot();
			
	//		countSpawn3--;
	//	PlayerPrefs.SetInt("countSpawn3", countSpawn3);
	//	PlayerPrefs.Save();
		 }
		
		if(!PhotonNetwork.IsMasterClient){
			timer-=Time.deltaTime;
			if(timer>0.91f && timer<1f){
		//	gameObject.GetComponent<PhotonView>().RPC("delete", RpcTarget.Others);
			timer=0.9f;
			}
		}
		
		if(gameObject.GetComponent<PhotonView>().IsMine){
		PhotonNetwork.Instantiate(deadPref.name, gameObject.transform.position, Quaternion.Euler(new Vector3(0 , 0, gameObject.transform.rotation.eulerAngles.z)));
		PhotonNetwork.Destroy(gameObject);
		}
	
			}
		}
		
		
		}
		[PunRPC]
		public void delete(){
		death = true;	
		}
		
    
	void FixedUpdate(){
		if(isBleeding==true){
			
		}
		else{
			moveEnemy(move);	
		}	
		
		
	
		
	}
	private void moveEnemy(Vector2 direction){
		stage = PlayerPrefs.GetInt("stage");
		//if(!isAttacking){
		rb.MovePosition((Vector2)transform.position + (direction * (speedMove) * Time.deltaTime));
	//	}
	//	else{
	//		rb.velocity = Vector2.zero;
	//	}
		
	}
	public void TakeDamage(int damage){
		health -=damage;
		
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		
		
	}
	
	void createEnemies(){
	
		Vector2 SpawnPos = movement.Position;
		SpawnPos = Random.insideUnitCircle.normalized * SpawnRadius * 2f;
		
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
		
		if(col.tag==("Bullet")){
			isBleeding=true;
		}
		if(col.tag==("Flame")){
		flame = true;
		
		}
		
		}
		
	
	void OnTriggerExit2D(Collider2D col)
    {
		if(col.tag==("Flame")){
		flame = false;	
		}
		
		
	
	}
	
	public void calculateLoot(){
	int calc_dropChance = Random.Range(0, 100);
	if(calc_dropChance > dropChance){
		return;
	}
	if(calc_dropChance <= dropChance){
		int itemWeight = 0;
		for (int i = 0; i < lootItems.Count; i++){
			itemWeight +=lootItems [i].dropRarity;
		}
		int randomValue = Random.Range(0, itemWeight);
		for (int j = 0; j<lootItems.Count; j++){
			if(randomValue<=lootItems[j].dropRarity){
				Instantiate(lootItems[j].item, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, -3f), Quaternion.identity);
				return;
			}
			randomValue-=lootItems[j].dropRarity;
		}
	}
}
	
	
	
}