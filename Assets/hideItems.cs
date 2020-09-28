using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideItems : MonoBehaviour
{
    public GameObject buttonShop, shop, createLandMine, shot;
	public int stage, count, count2, count3, count4, count5;
	public int countSpawn, countSpawn2, countSpawn3, countSpawn4, countSpawn5;
	private float time=0.5f;
	private float offNight=8f;
	public GameObject[] numberEnemy;
	public GameObject[] numberEnemy2;
	public GameObject[] numberEnemy3;
	public GameObject[] numberEnemy4;
	public GameObject[] numberEnemy5;
    void Start()
    {
      stage = PlayerPrefs.GetInt("stage");
	   
	   
	   PlayerPrefs.Save();  
    }

    // Update is called once per frame
    void Update()
    {
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
		
		
		if(countSpawn>0 && Time.timeScale > 0.25){
			
			createLandMine.SetActive(false);
			buttonShop.SetActive(false);
			
			shop.SetActive(false);
			
		shot.SetActive(true);
			
			
			
			
			
		}
		if (countSpawn==0 && countSpawn2==0 && countSpawn3==0 && countSpawn4==0 && countSpawn5==0 && Time.timeScale > 0.25){
			shot.SetActive(false);
			
			
			createLandMine.SetActive(true);
			buttonShop.SetActive(true);
			
			
		}
		
		
		
    }
}
