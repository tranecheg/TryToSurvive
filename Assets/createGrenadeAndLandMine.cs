using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class createGrenadeAndLandMine : MonoBehaviour
{
    public Button buy_bulletsGrenade, buy_bulletsLandMine;
	public GameObject grenadePref, landMine;
	private int money, bulletsGrenade, bulletsLandMine;
	public Text grenadeAmount, landMineAmound;
	public bool otherLandMine;
	private float speed = 7f;
	public Transform firePoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
	money = PlayerPrefs.GetInt("money");
	
      if(money>=300){
		buy_bulletsGrenade.interactable= true;
		buy_bulletsGrenade.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		
		}
		else{
		buy_bulletsGrenade.interactable = false;
		buy_bulletsGrenade.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
	grenadeAmount.text = "" + bulletsGrenade;

 if(money>=500){
		buy_bulletsLandMine.interactable= true;
		buy_bulletsLandMine.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
		buy_bulletsLandMine.interactable = false;
		buy_bulletsLandMine.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
	landMineAmound.text = "" + bulletsLandMine;
	speed-=.1f*Time.deltaTime;	
    
	}
	public void buyBulletsGrenade(){
		money = PlayerPrefs.GetInt("money");
		money-=300;
		PlayerPrefs.SetInt("money", money);
		//bulletsGrenade = PlayerPrefs.GetInt("bulletsGrenade");
		bulletsGrenade+=1;
		//PlayerPrefs.SetInt("bulletsGrenade",bulletsGrenade);
	}
	public void buyBulletsLandMine(){
		money = PlayerPrefs.GetInt("money");
		money-=500;
		PlayerPrefs.SetInt("money", money);
	
		bulletsLandMine+=1;
		}
		
	
	public void createGrenade(){
		
		 if(bulletsGrenade==0){
			 
		 }
		else{
			GameObject grenade = PhotonNetwork.Instantiate(grenadePref.name, transform.position, Quaternion.identity);
			
		   Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
			
		rb.AddForce(firePoint.right * 5f, ForceMode2D.Impulse);
	   
	  
	   	
			bulletsGrenade--;
			
		}
	}
		
		     
	
	public void createLandmine(){
		if(gameObject.transform.GetChild(13).gameObject.transform.GetChild(0).gameObject.transform.Find("LandMine").gameObject.activeInHierarchy == true){
		//if(GameObject.Find("LandMine")!=null){	
		if(otherLandMine==false){
		if(bulletsLandMine==0){
			 
		 }
		 else{
				PhotonNetwork.Instantiate(landMine.name, transform.position, Quaternion.identity);	
				bulletsLandMine--;				
		 }
		}
		}
		}
	
//	}
	private void OnTriggerEnter2D(Collider2D col)
    {
		
		if(col.tag == "box"){
			int number = Random.Range(1,3);
			if(number==1){
			bulletsGrenade++;
			}
			if(number==2){
			bulletsLandMine++;
			}
		}
		if(col.tag=="landMine"){
			otherLandMine=true;
		}
	}
	private void OnTriggerExit2D(Collider2D col)
    {
		
		
		if(col.tag=="landMine"){
			otherLandMine=false;
		}
	}
}
