using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class createEnemy : MonoBehaviour
{
    
	
	public GameObject buttonStage, textNight, mainMusic, gameMusic, deadPlayer, deadTxt, openNight;
	
	public GameObject[] enemyPref1;
	public GameObject[] enemyPref2;
	public GameObject[] enemyPref3;
	public GameObject[] enemyPref4;
	public GameObject[] enemyPref5;
	private int rand;
	public GameObject[] numberEnemy;
	public GameObject[] numberEnemy2;
	public GameObject[] numberEnemy3;
	public GameObject[] numberEnemy4;
	public GameObject[] numberEnemy5;
	public GameObject[] enemies;
	
	float x;
	float y;
	private float SpawnRadius; 
	private float StartSpawn = 11f;
		
	public int stage, count, count2, count3, count4, count5;
	public int countSpawn, countSpawn2, countSpawn3, countSpawn4, countSpawn5;
	private float time=0.5f;
	public float offNight=8f;
	private PhotonView pv;
	
	
    void Start()
    {
       stage = PlayerPrefs.GetInt("stage");
	   
	   pv = gameObject.GetComponent<PhotonView>();
	   PlayerPrefs.Save();
	   
    }
	

    // Update is called once per frame
    void Update()
    {
		
					
	SpawnRadius = StartSpawn;
      
	 	
		 stage = PlayerPrefs.GetInt("stage");
		 countSpawn = PlayerPrefs.GetInt("countSpawn");
		 countSpawn2 = PlayerPrefs.GetInt("countSpawn2");
		 countSpawn3 = PlayerPrefs.GetInt("countSpawn3");
		 countSpawn4 = PlayerPrefs.GetInt("countSpawn4");
		 countSpawn5 = PlayerPrefs.GetInt("countSpawn5");
		
		numberEnemy = GameObject.FindGameObjectsWithTag("zombieAttack");
		numberEnemy2 = GameObject.FindGameObjectsWithTag("zombieAttack2");
		numberEnemy3 = GameObject.FindGameObjectsWithTag("zombieAttack3");
		numberEnemy4 = GameObject.FindGameObjectsWithTag("zombieAttack4");
		numberEnemy5 = GameObject.FindGameObjectsWithTag("zombieAttack5");
		
		if(GameObject.FindGameObjectWithTag("Player")==null){
			countSpawn=0;
			mainMusic.SetActive(false);
			gameMusic.SetActive(false);
			deadPlayer.SetActive(true);
			deadTxt.SetActive(true);
		}
		
		if(countSpawn>0 && GameObject.FindGameObjectWithTag("Player")!=null){
			
			textNight.SetActive(true);
			openNight.SetActive(true);
			
			buttonStage.SetActive(false);
		
			
			
			
			offNight-=Time.deltaTime;
			mainMusic.GetComponent<Animation>().Play("VolumeDown");
			
			if(offNight<0){
				textNight.SetActive(false);
				openNight.SetActive(false);
				mainMusic.GetComponent<Animation>().Stop();
				mainMusic.SetActive(false);
				mainMusic.GetComponent<AudioSource>().Stop();
				
			}
			if(offNight<0.5f){
				
				gameMusic.SetActive(true);
				gameMusic.GetComponent<AudioSource>().volume = 1;
			}
			
		}
		
		
		if (countSpawn==0 && countSpawn2==0 && countSpawn3==0 && countSpawn4==0 && countSpawn5==0 && GameObject.FindGameObjectWithTag("Player")!=null){
			if(PhotonNetwork.IsMasterClient){
			buttonStage.SetActive(true);
			}
			
			if(offNight<8 && offNight>=0.5){
			offNight-=Time.deltaTime;
			
			}
			if(offNight<0.5f){
				textNight.SetActive(false);
				offNight=8f;
			}
			
			gameMusic.GetComponent<Animation>().Play("VolumeDown");
			mainMusic.SetActive(true);
			mainMusic.GetComponent<Animation>().Play("VolumeUp");
		}
		
		
		
		if(mainMusic.GetComponent<AudioSource>().volume>0.98f){
			gameMusic.SetActive(false);
			gameMusic.GetComponent<AudioSource>().volume = 1;
			mainMusic.GetComponent<Animation>().Stop("VolumeUp");
			gameMusic.GetComponent<AudioSource>().Stop();
		}
		
		if(PhotonNetwork.IsMasterClient){
		if(numberEnemy.Length<countSpawn){
			createEnemies();
			
			//pv.RPC("createEnemies", RpcTarget.AllBuffered);
			
		}
		else{
			
		}
		if(numberEnemy2.Length<countSpawn2){
			//createEnemies2();
			pv.RPC("createEnemies2", RpcTarget.AllBuffered);
		}
		else{
			
		}
		if(numberEnemy3.Length<countSpawn3){
			pv.RPC("createEnemies3", RpcTarget.AllBuffered);
			//createEnemies3();
		}
		else{
			
		}
		if(numberEnemy4.Length<countSpawn4){
			pv.RPC("createEnemies4", RpcTarget.AllBuffered);
			//createEnemies4();
		}
		else{
			
		}
		if(numberEnemy5.Length<countSpawn5){
			pv.RPC("createEnemies5", RpcTarget.AllBuffered);
			//createEnemies5();
		}
		else{
			
		}
		}
		
		
		
		
		
		
		
		}
		
[PunRPC]		
	void createEnemies(){
	
		Vector2 SpawnPos = movement.Position;
		SpawnPos = Random.insideUnitCircle.normalized * SpawnRadius * 2f;
		time-=Time.deltaTime;
		if(time<0){
		rand = Random.Range(0, enemyPref1.Length); 
		
		GameObject name = PhotonNetwork.Instantiate(enemyPref1[rand].name, SpawnPos, Quaternion.identity);
		count++;
		name.name = "Enemy" + count;
		time=0.5f;
		
		}
		
	}
	[PunRPC]	
	void createEnemies2(){
	
		Vector2 SpawnPos = movement.Position;
		SpawnPos = Random.insideUnitCircle.normalized * SpawnRadius * 2f;
		
		time-=Time.deltaTime;
		if(time<0){
			rand = Random.Range(0, enemyPref2.Length);
		GameObject name = PhotonNetwork.Instantiate(enemyPref2[rand].name, SpawnPos, Quaternion.identity);
		count2++;
		name.name = "Enemy2" + count2;
		time=0.5f;
		
		}
		
	}
	[PunRPC]
	void createEnemies3(){
	
		Vector2 SpawnPos = movement.Position;
		SpawnPos = Random.insideUnitCircle.normalized * SpawnRadius * 2f;
		
		time-=Time.deltaTime;
		if(time<0){
			rand = Random.Range(0, enemyPref3.Length);
		GameObject name = PhotonNetwork.Instantiate(enemyPref3[rand].name, SpawnPos, Quaternion.identity);
		count3++;
		name.name = "Enemy3" + count3;
		time=0.5f;
		
		}
		
	}
	[PunRPC]
	void createEnemies4(){
	
		Vector2 SpawnPos = movement.Position;
		SpawnPos = Random.insideUnitCircle.normalized * SpawnRadius * 2f;
		
		time-=Time.deltaTime;
		if(time<0){
			rand = Random.Range(0, enemyPref4.Length);
		GameObject name = PhotonNetwork.Instantiate(enemyPref4[rand].name, SpawnPos, Quaternion.identity);
		count4++;
		name.name = "Enemy4" + count4;
		time=0.5f;
		
		}
		
	}
	[PunRPC]
	void createEnemies5(){
	
		Vector2 SpawnPos = movement.Position;
		SpawnPos = Random.insideUnitCircle.normalized * SpawnRadius * 2f;
		
		time-=Time.deltaTime;
		if(time<0){
			rand = Random.Range(0, enemyPref5.Length);
		GameObject name = PhotonNetwork.Instantiate(enemyPref5[rand].name, SpawnPos, Quaternion.identity);
		count5++;
		name.name = "Enemy5" + count5;
		time=0.5f;
		
		}
		
	}
	
	
	
	}
	
	
	

