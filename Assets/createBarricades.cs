using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;

public class createBarricades : MonoBehaviour
{
	public Button buy_amountBarricades, buy_Turret;
	public GameObject barricadePref, turretPref;
	private int money, amountBarricades, amountTurret, bulletsTurret;
	public Text barricadeAmount, turretAmout, turretBullets;
	public bool otherBarricade, otherTurret;
	private int countBarricade;
    void Start()
    {
       PlayerPrefs.SetInt("bulletsTurret", 0); 
    }

    // Update is called once per frame
    void Update()
    {
		
	money = PlayerPrefs.GetInt("money");
      if(money>=500){
			buy_amountBarricades.interactable= true;
			buy_amountBarricades.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_amountBarricades.interactable = false;
			buy_amountBarricades.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
		
		if(money>=12000){
			buy_Turret.interactable= true;
			buy_Turret.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
			buy_Turret.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,1f);
			buy_Turret.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_Turret.interactable = false;
			buy_Turret.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
			buy_Turret.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0.3f);
			buy_Turret.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
	barricadeAmount.text = "" + amountBarricades;
	
	turretAmout.text ="" + amountTurret;
	turretBullets.text = "" + PlayerPrefs.GetInt("bulletsTurret");
 
	
    }
	public void buySomeBarricades(){
			
		money = PlayerPrefs.GetInt("money");
		money-=500;
		PlayerPrefs.SetInt("money", money);
		//bulletsGrenade = PlayerPrefs.GetInt("bulletsGrenade");
		amountBarricades+=1;
		//PlayerPrefs.SetInt("bulletsGrenade",bulletsGrenade);
		
	}
	public void buyTurret(){
		money = PlayerPrefs.GetInt("money");
		money-=12000;
		PlayerPrefs.SetInt("money", money);
		bulletsTurret +=100;
		PlayerPrefs.SetInt("bulletsTurret", bulletsTurret); 
		amountTurret+=1;
	}
	
	
	public void createBarricade(){
		if(gameObject.transform.GetChild(13).gameObject.transform.GetChild(0).gameObject.transform.Find("Barricade").gameObject.activeInHierarchy == true){
		
		if(otherBarricade==false){
		if(amountBarricades==0){
			 
		 }
		 else{
				GameObject barricadeObject = PhotonNetwork.Instantiate(barricadePref.name, transform.position, Quaternion.identity);
				
				countBarricade++;
				barricadeObject.name = "barricade" + countBarricade;				
				amountBarricades--;				
		 }
		}
		}
		}
	
	
	public void createTurrets(){
		if(gameObject.transform.GetChild(13).gameObject.transform.GetChild(0).gameObject.transform.Find("Turret").gameObject.activeInHierarchy == true){
		
		if(otherTurret==false){
		if(amountTurret==0){
			 
		 }
		 else{
				GameObject turret = PhotonNetwork.Instantiate(turretPref.name, transform.position, Quaternion.identity);
			
				turret.name = "turret";				
				amountTurret--;				
		 }
		}
		}
	
	}
	private void OnTriggerEnter2D(Collider2D col)
    {
		if(col.tag=="barricade"){
			otherBarricade=true;
		}
		if(col.tag=="barricade"){
			otherTurret=true;
		}
	}
	private void OnTriggerExit2D(Collider2D col)
    {
		
		
		if(col.tag=="barricade"){
			otherBarricade=false;
		}
		if(col.tag=="barricade"){
			otherTurret=false;
		}
	}
}
