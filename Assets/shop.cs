using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class shop : MonoBehaviour
{
    public GameObject shopObject, guns, bullets, others, btnBack, btnNext;
	public int open=0;
	public int bulletsShotgun, bulletsAK, bulletsSniper, bulletsBazooka, bulletsFlameThrover, bulletsFreezeGun, bulletsTurret;
	private PhotonView photonView;
	
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     bulletsShotgun = PlayerPrefs.GetInt("bulletsShotgun");  
	 
    }
	public void OpenShop(){
	
		if(open==0){
			shopObject.SetActive(true);
			open=1;
		}
		else{
			shopObject.SetActive(false);
			open=0;
		}
		
		
		
	}
	
	public void buyBulletsShotgun(){
		int money = PlayerPrefs.GetInt("money");
		money-=50;
		PlayerPrefs.SetInt("money", money);
		
		bulletsShotgun = PlayerPrefs.GetInt("bulletsShotgun");
		bulletsShotgun+=2;
		PlayerPrefs.SetInt("bulletsShotgun",bulletsShotgun);
	}
	public void buyBulletsAK(){
		int money = PlayerPrefs.GetInt("money");
		money-=200;
		PlayerPrefs.SetInt("money", money);
		bulletsAK = PlayerPrefs.GetInt("bulletsAK");
		bulletsAK+=30;
		PlayerPrefs.SetInt("bulletsAK",bulletsAK);
	}
	public void buyBulletsSniper(){
		int money = PlayerPrefs.GetInt("money");
		money-=500;
		PlayerPrefs.SetInt("money", money);
		bulletsSniper = PlayerPrefs.GetInt("bulletsSniper");
		bulletsSniper+=6;
		PlayerPrefs.SetInt("bulletsSniper",bulletsSniper);
	}
	public void buyBulletsBazooka(){
		int money = PlayerPrefs.GetInt("money");
		money-=1000;
		PlayerPrefs.SetInt("money", money);
		bulletsBazooka = PlayerPrefs.GetInt("bulletsBazooka");
		bulletsBazooka+=4;
		PlayerPrefs.SetInt("bulletsBazooka",bulletsBazooka);
	}
	public void buyBulletsFlameThrover(){
		int money = PlayerPrefs.GetInt("money");
		money-=2000;
		PlayerPrefs.SetInt("money", money);
		bulletsFlameThrover = PlayerPrefs.GetInt("bulletsFlameThrover");
		bulletsFlameThrover+=50;
		PlayerPrefs.SetInt("bulletsFlameThrover",bulletsFlameThrover);
	}
	public void buyBulletsFreezeGun(){
		int money = PlayerPrefs.GetInt("money");
		money-=500;
		PlayerPrefs.SetInt("money", money);
		bulletsFreezeGun = PlayerPrefs.GetInt("bulletsFreezeGun");
		bulletsFreezeGun+=12;
		PlayerPrefs.SetInt("bulletsFreezeGun",bulletsFreezeGun);
	}
	public void buyBulletsTurret(){
		int money = PlayerPrefs.GetInt("money");
		money-=2000;
		PlayerPrefs.SetInt("money", money);
		bulletsTurret = PlayerPrefs.GetInt("bulletsTurret");
		bulletsTurret+=100;
		PlayerPrefs.SetInt("bulletsTurret",bulletsTurret);
	}
	public void openShopGuns(){
		guns.SetActive(true);
		bullets.SetActive(false);
		others.SetActive(false);
	}
	public void openShopBullets(){
		guns.SetActive(false);
		bullets.SetActive(true);
		others.SetActive(false);
		
	}
	public void openShopOthers(){
		guns.SetActive(false);
		bullets.SetActive(false);
		others.SetActive(true);
		
	}
	public void nextBullet(){
		btnNext.SetActive(true);
		btnBack.SetActive(false);
	}
	public void backBullet(){
		btnNext.SetActive(false);
		btnBack.SetActive(true);
		
	}
	
}
