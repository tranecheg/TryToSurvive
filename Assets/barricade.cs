using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class barricade : MonoBehaviour
{
    public int health = 2000;
	private bool attack;
	public TextMesh healthText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		healthText.text = "" + health;
		if(attack==true){
			health--;
		}
       if(health<=0){
		   Destroy(gameObject);
	   }
	int countSpawn = PlayerPrefs.GetInt("countSpawn");
		
		
		if(countSpawn>0){
			gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
	else{
	gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
}		
    }
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag==("zombieAttack")){
			health-=5;
			
		}
		if(col.tag == "zombieAttack2"){
			health-=10;
			
		}
		if(col.tag == "zombieAttack3"){
			health-=20;
			
		}
		if(col.tag == "zombieAttack4"){
			health-=40;
			
		}
		if(col.tag == "zombieAttack5"){
			health-=80;
			
		}
		
		
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.tag==("zombieAttack")){
			//health-=5;
			
		}
		if(col.tag == "zombieAttack2"){
			
			
		}
		if(col.tag == "zombieAttack3"){
			
			
		}
		if(col.tag == "zombieAttack4"){
			
			
		}
		if(col.tag == "zombieAttack5"){
			
			
		}
		
		
	}
}
