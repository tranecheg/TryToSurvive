using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;


public class weaponChange : MonoBehaviour
{
   private int weaponSwitch, weaponSwitch1 = 0;
   public GameObject ak, shotgun, sniper, bazooka, flameThrover, freezeGun;
   public Sprite ak_sprite, shotgun_sprite, pistol_sprite, sniper_sprite, bazooka_sprite, flameThrover_sprite, freezeGun_sprite;
   public Button buy_ak, buy_shotgun, buy_bulletsShotgun,buy_bulletsAK, buy_bulletsGrenade, buy_bulletsSniper, buy_bulletsFlameThrover, 
   buy_sniper, buy_bazooka, buy_bulletsBazooka, buy_flameThrover, buy_bulletsFreezeGun, buy_freezeGun;
   public GameObject pistolImg, ShotgunImg, AKImg, sniperImg, bazookaImg, flameThroverImg, freezeGunImg;
   public GameObject pistolImg1, ShotgunImg1, AKImg1, sniperImg1, bazookaImg1, flameThroverImg1, freezeGunImg1;
   private bool check_buy_shotgun, check_buy_AK, check_buy_sniper, check_buy_bazooka, check_buy_flameThrover, check_buy_freezeGun=false;
   
   
   private GameObject shotgunPref;
   
   private PhotonView photonView;
   private string pistolName, shotgunName, AKName, sniperName, flameThroverName, bazookaName, freezeGunName;
   
    void Start()
    {
		photonView  = GetComponent<PhotonView>();
		//if(gameObject.GetComponent<PhotonView>().ViewID==1002){
			if(PhotonNetwork.IsMasterClient){
			 SelectWeapon();
			gameObject.transform.parent.GetChild(13).transform.GetChild(3).gameObject.SetActive(false);
		}
		//if(gameObject.GetComponent<PhotonView>().ViewID==2002){
			if(!PhotonNetwork.IsMasterClient){
			SelectWeapon();
			gameObject.transform.parent.GetChild(13).transform.GetChild(2).gameObject.SetActive(false);
		}
		
      
	    
		
		
    }

    // Update is called once per frame
    void Update()
    {
		if(PhotonNetwork.IsMasterClient){
			 SelectWeapon();
			gameObject.transform.parent.GetChild(13).transform.GetChild(3).gameObject.SetActive(false);
		}
		//if(gameObject.GetComponent<PhotonView>().ViewID==2002){
			if(!PhotonNetwork.IsMasterClient){
			SelectWeapon();
			gameObject.transform.parent.GetChild(13).transform.GetChild(2).gameObject.SetActive(false);
		}
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		pistolName = "pistol" + gameObject.transform.parent.gameObject.name;
		shotgunName = "shotgun" + gameObject.transform.parent.gameObject.name;
		AKName = "AK" + gameObject.transform.parent.gameObject.name;
		sniperName = "sniperRifle" + gameObject.transform.parent.gameObject.name;
		flameThroverName = "flameThrover" + gameObject.transform.parent.gameObject.name;
		bazookaName = "bazooka" + gameObject.transform.parent.gameObject.name;
		freezeGunName = "freezeGun" + gameObject.transform.parent.gameObject.name;
		int money = PlayerPrefs.GetInt("money");
		if(GameObject.Find(pistolName)!=null){
			//player.GetComponent<SpriteRenderer>().sprite = pistol_sprite;
			pistolImg.SetActive(true);
			pistolImg1.SetActive(true);
			ShotgunImg.SetActive(false);
			ShotgunImg1.SetActive(false);
			AKImg.SetActive(false);
			AKImg1.SetActive(false);
			sniperImg.SetActive(false);
			sniperImg1.SetActive(false);
			bazookaImg.SetActive(false);
			bazookaImg1.SetActive(false);
			flameThroverImg.SetActive(false);
			flameThroverImg1.SetActive(false);
			freezeGunImg.SetActive(false);
			freezeGunImg1.SetActive(false);
		}
		if(GameObject.Find(shotgunName)!=null){
			//player.GetComponent<SpriteRenderer>().sprite = pistol_sprite;
			pistolImg.SetActive(false);
			pistolImg1.SetActive(false);
			ShotgunImg.SetActive(true);
			ShotgunImg1.SetActive(true);
			AKImg.SetActive(false);
			AKImg1.SetActive(false);
			sniperImg.SetActive(false);
			sniperImg1.SetActive(false);
			bazookaImg.SetActive(false);
			bazookaImg1.SetActive(false);
			flameThroverImg.SetActive(false);
			flameThroverImg1.SetActive(false);
			freezeGunImg.SetActive(false);
			freezeGunImg1.SetActive(false);
		}
		if(GameObject.Find(AKName)!=null){
			//player.GetComponent<SpriteRenderer>().sprite = pistol_sprite;
			pistolImg.SetActive(false);
			pistolImg1.SetActive(false);
			ShotgunImg.SetActive(false);
			ShotgunImg1.SetActive(false);
			AKImg.SetActive(true);
			AKImg1.SetActive(true);
			sniperImg.SetActive(false);
			sniperImg1.SetActive(false);
			bazookaImg.SetActive(false);
			bazookaImg1.SetActive(false);
			flameThroverImg.SetActive(false);
			flameThroverImg1.SetActive(false);
			freezeGunImg.SetActive(false);
			freezeGunImg1.SetActive(false);
		}
		if(GameObject.Find(sniperName)!=null){
			//player.GetComponent<SpriteRenderer>().sprite = pistol_sprite;
			pistolImg.SetActive(false);
			pistolImg1.SetActive(false);
			ShotgunImg.SetActive(false);
			ShotgunImg1.SetActive(false);
			AKImg.SetActive(false);
			AKImg1.SetActive(false);
			sniperImg.SetActive(true);
			sniperImg1.SetActive(true);
			bazookaImg.SetActive(false);
			bazookaImg1.SetActive(false);
			flameThroverImg.SetActive(false);
			flameThroverImg1.SetActive(false);
			freezeGunImg.SetActive(false);
			freezeGunImg1.SetActive(false);
		}
		if(GameObject.Find(flameThroverName)!=null){
			//player.GetComponent<SpriteRenderer>().sprite = pistol_sprite;
			pistolImg.SetActive(false);
			pistolImg1.SetActive(false);
			ShotgunImg.SetActive(false);
			ShotgunImg1.SetActive(false);
			AKImg.SetActive(false);
			AKImg1.SetActive(false);
			sniperImg.SetActive(false);
			sniperImg1.SetActive(false);
			bazookaImg.SetActive(false);
			bazookaImg1.SetActive(false);
			flameThroverImg.SetActive(true);
			flameThroverImg1.SetActive(true);
			freezeGunImg.SetActive(false);
			freezeGunImg1.SetActive(false);
		}
		if(GameObject.Find(bazookaName)!=null){
			//player.GetComponent<SpriteRenderer>().sprite = pistol_sprite;
			pistolImg.SetActive(false);
			pistolImg1.SetActive(false);
			ShotgunImg.SetActive(false);
			ShotgunImg1.SetActive(false);
			AKImg.SetActive(false);
			AKImg1.SetActive(false);
			sniperImg.SetActive(false);
			sniperImg1.SetActive(false);
			bazookaImg.SetActive(true);
			bazookaImg1.SetActive(true);
			flameThroverImg.SetActive(false);
			flameThroverImg1.SetActive(false);
			freezeGunImg.SetActive(false);
			freezeGunImg1.SetActive(false);
		}
		if(GameObject.Find(freezeGunName)!=null){
			//player.GetComponent<SpriteRenderer>().sprite = pistol_sprite;
			pistolImg.SetActive(false);
			pistolImg1.SetActive(false);
			ShotgunImg.SetActive(false);
			ShotgunImg1.SetActive(false);
			AKImg.SetActive(false);
			AKImg1.SetActive(false);
			sniperImg.SetActive(false);
			sniperImg1.SetActive(false);
			bazookaImg.SetActive(false);
			bazookaImg1.SetActive(false);
			flameThroverImg.SetActive(false);
			flameThroverImg1.SetActive(false);
			freezeGunImg.SetActive(true);
			freezeGunImg1.SetActive(true);
		}
		
		
		
		
		if(money>=50 && check_buy_shotgun==true){
			buy_bulletsShotgun.interactable=true;
			buy_bulletsShotgun.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_bulletsShotgun.interactable=false;
			buy_bulletsShotgun.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
		
		if(money>=200 && check_buy_AK==true){
			buy_bulletsAK.interactable=true;
			buy_bulletsAK.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_bulletsAK.interactable=false;
			buy_bulletsAK.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
		
		if(money>=500 && check_buy_sniper==true){
			buy_bulletsSniper.interactable=true;
			buy_bulletsSniper.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_bulletsSniper.interactable=false;
			buy_bulletsSniper.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
		if(money>=500 && check_buy_sniper==true){
			buy_bulletsSniper.interactable=true;
			buy_bulletsSniper.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_bulletsSniper.interactable=false;
			buy_bulletsSniper.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
		if(money>=200 && check_buy_bazooka==true){
			buy_bulletsBazooka.interactable=true;
			buy_bulletsBazooka.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_bulletsBazooka.interactable=false;
			buy_bulletsBazooka.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
		if(money>=500 && check_buy_freezeGun==true){
			buy_bulletsFreezeGun.interactable=true;
			buy_bulletsFreezeGun.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_bulletsFreezeGun.interactable=false;
			buy_bulletsFreezeGun.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
		if(money>=2000 && check_buy_flameThrover==true){
			buy_bulletsFlameThrover.interactable=true;
			buy_bulletsFlameThrover.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_bulletsFlameThrover.interactable=false;
			buy_bulletsFlameThrover.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.3f);
		}
		
		
		
		
		if(money>=2000 && check_buy_shotgun==false){
			buy_shotgun.interactable = true;
			buy_shotgun.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_shotgun.interactable = false;
			buy_shotgun.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.5f);
			
		}
		
		if(money>=6000 && check_buy_AK==false){
			buy_ak.interactable = true;
			buy_ak.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_ak.interactable = false;
			buy_ak.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.5f);
			
		}
		if(money>=8000 && check_buy_sniper==false){
			buy_sniper.interactable = true;
			buy_sniper.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
			
			
		}
		else{
			buy_sniper.interactable = false;
			buy_sniper.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.5f);
		}
		if(money>=10000 && check_buy_bazooka==false){
			buy_bazooka.interactable = true;
			buy_bazooka.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_bazooka.interactable = false;
			buy_bazooka.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.5f);
			
		}
		if(money>=7000 && check_buy_flameThrover==false){
			buy_flameThrover.interactable = true;
			buy_flameThrover.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_flameThrover.interactable = false;
			buy_flameThrover.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.5f);
			
		}
		if(money>=15000 && check_buy_freezeGun==false){
			buy_freezeGun.interactable = true;
			buy_freezeGun.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1f);
		}
		else{
			buy_freezeGun.interactable = false;
			buy_freezeGun.transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0.5f);
			
		}
		
		
		
		
		
		
		
		
    }

	
	public void BuyAK(){
		int money = PlayerPrefs.GetInt("money");
		money-=6000;
		check_buy_AK=true;
		PlayerPrefs.SetInt("money", money);
		GameObject akPref = PhotonNetwork.Instantiate(ak.name, transform.position, transform.rotation);
		akPref.transform.parent = transform;
		
		PlayerPrefs.SetInt("bulletsAK",0);
		buy_ak.interactable = false;
		buy_ak.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color32(255,255,255,100);
		
	}
	public void testBuyShotgun(){
		//photonView.RPC("BuyShotgun", RpcTarget.AllBuffered, null);
		BuyShotgun();
	}
	[PunRPC]
	public void BuyShotgun(){
		int money = PlayerPrefs.GetInt("money");
		money-=2000;
		check_buy_shotgun=true;
		PlayerPrefs.SetInt("money", money);
		photonView = GetComponent<PhotonView>();	
		
		shotgunPref = PhotonNetwork.Instantiate(shotgun.name, transform.position, transform.rotation);
		//shotgunPref.name = "shotgun" + PhotonView.Find(gameObject.GetComponent<PhotonView>().ViewID/1000*1001).gameObject.name;
		shotgunPref.transform.parent = transform;
				
		PlayerPrefs.SetInt("bulletsShotgun",0);
		buy_shotgun.interactable = false;
		buy_shotgun.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color32(255,255,255,100);
		
	}

	
	public void BuySniperRifle(){
		int money = PlayerPrefs.GetInt("money");
		money-=8000;
		check_buy_sniper=true;
		PlayerPrefs.SetInt("money", money);
		GameObject sniperPref = PhotonNetwork.Instantiate(sniper.name, transform.position, transform.rotation);
		
		sniperPref.transform.parent =transform;
		PlayerPrefs.SetInt("bulletsSniper",0);
		buy_sniper.interactable = false;
		buy_sniper.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color32(255,255,255,100);
		
		
	}
	public void BuyBazooka(){
		int money = PlayerPrefs.GetInt("money");
		money-=10000;
		check_buy_bazooka=true;
		PlayerPrefs.SetInt("money", money);
		//GameObject bazookaPref = Instantiate(bazooka, transform.position, transform.rotation) as GameObject;
		GameObject bazookaPref = PhotonNetwork.Instantiate(bazooka.name, transform.position, transform.rotation);
		
		bazookaPref.transform.parent =transform;
		PlayerPrefs.SetInt("bulletsBazooka",0);
		buy_bazooka.interactable = false;
		buy_bazooka.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color32(255,255,255,100);
		
		
	}
	public void BuyFlameThrover(){
		int money = PlayerPrefs.GetInt("money");
		money-=7000;
		check_buy_flameThrover=true;
		PlayerPrefs.SetInt("money", money);
		GameObject flameThroverPref = PhotonNetwork.Instantiate(flameThrover.name, transform.position, transform.rotation);
		
		flameThroverPref.transform.parent  = transform;
		PlayerPrefs.SetInt("bulletsFlameThrover",50);
		buy_flameThrover.interactable = false;
		buy_flameThrover.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color32(255,255,255,100);
		
		
	}
	public void BuyFreezeGun(){
		int money = PlayerPrefs.GetInt("money");
		money-=15000;
		check_buy_freezeGun=true;
		PlayerPrefs.SetInt("money", money);
		GameObject freezeGunPref = PhotonNetwork.Instantiate(freezeGun.name, transform.position, transform.rotation);
		
		freezeGunPref.transform.parent = transform;
		PlayerPrefs.SetInt("bulletsFreezeGun",0);
		buy_freezeGun.interactable = false;
		buy_freezeGun.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color32(255,255,255,100);
		
		
	}
	public void test(){
	//if(gameObject.transform.parent.GetComponent<PhotonView>().ViewID==1001 && gameObject.transform.parent.GetChild(13)!=null){
		if(gameObject.transform.parent.GetComponent<PhotonView>().IsMine && gameObject.transform.parent.GetChild(13)!=null){
		photonView.RPC("changeWeapon", RpcTarget.AllBuffered, null);
		}
		
		
	}
	public void test1(){
	//if(gameObject.transform.parent.GetComponent<PhotonView>().ViewID==2001 && gameObject.transform.parent.GetChild(13)!=null){
		if(gameObject.transform.parent.GetChild(13)!=null){
		photonView.RPC("changeWeapon1", RpcTarget.AllBuffered, null);
		}
		
		
	}
	
	private void SelectWeapon(){
		int i = 0;
		foreach(Transform weapon in transform){
		//	if(i== weaponSwitch && weapon.transform.parent.GetComponent<PhotonView>().ViewID==1002){
			if(i== weaponSwitch){	
				
				weapon.gameObject.SetActive(true);
			}
			else{
				//GameObject gm1 = PhotonView.Find(1001).gameObject;
				//gm1.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
				weapon.gameObject.SetActive(false);
			}
		i++;	
		}
	}
	private void SelectWeapon1(){
		int i = 0;
		foreach(Transform weapon1 in transform){
			//if(i== weaponSwitch1 && weapon1.transform.parent.GetComponent<PhotonView>().ViewID==2002){
			if(i== weaponSwitch){	
				
				weapon1.gameObject.SetActive(true);
			}
			else{
				//GameObject gm1 = PhotonView.Find(1001).gameObject;
				//gm1.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
				weapon1.gameObject.SetActive(false);
			}
		i++;	
		}
	}
[PunRPC]
	public void changeWeapon(){
		int currentWeapon = weaponSwitch;
        
			if(weaponSwitch>=transform.childCount - 1){
				weaponSwitch=0;
			}
			else{
			weaponSwitch++;	
			}
			
		
		if(currentWeapon!=weaponSwitch){
			SelectWeapon();
			//GetComponent<PhotonView>().RPC("SelectWeapon", Photon.Pun.RpcTarget.AllBuffered, null);
		}
	}
	[PunRPC]
	public void changeWeapon1(){
		int currentWeapon1 = weaponSwitch1;
        
			if(weaponSwitch1>=transform.childCount - 1){
				weaponSwitch1=0;
			}
			else{
			weaponSwitch1++;	
			}
			
		
		if(currentWeapon1!=weaponSwitch1){
			SelectWeapon1();
			//GetComponent<PhotonView>().RPC("SelectWeapon", Photon.Pun.RpcTarget.AllBuffered, null);
		}
	}
	
}
