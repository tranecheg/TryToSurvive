using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class bullet : MonoBehaviour
{
	private Transform other;
		private PhotonView photonView;
	
	
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
		
		if(hitInfo.tag == "Enemy" && gameObject.name=="bulletPistol"){
		Enemy zombie = hitInfo.transform.parent.gameObject.GetComponent<Enemy>();
		enemyLevel2 zombie2 = hitInfo.transform.parent.gameObject.GetComponent<enemyLevel2>();
		EnemyLevel3 zombie3 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel3>();
		EnemyLevel4 zombie4 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel4>();
		enemyLevel5 zombie5 = hitInfo.transform.parent.gameObject.GetComponent<enemyLevel5>();
		
		if(zombie!=null){
			zombie.TakeDamage(20);//20
			
		}
		if(zombie2!=null){
			zombie2.TakeDamage(20);//20
			
		}
		if(zombie3!=null){
			zombie3.TakeDamage(20);//20
			
		}
		if(zombie4!=null){
			zombie4.TakeDamage(20);//20
			
		}
		if(zombie5!=null){
			zombie5.TakeDamage(20);//20
			
		}
		
       
    }
	if(hitInfo.tag == "Enemy" && gameObject.name=="bulletShotgun"){
		Enemy zombie = hitInfo.transform.parent.gameObject.GetComponent<Enemy>();
		EnemyLevel3 zombie2 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel3>();
		EnemyLevel4 zombie4 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel4>();
		enemyLevel5 zombie5 = hitInfo.transform.parent.gameObject.GetComponent<enemyLevel5>();
		if(zombie!=null){
			zombie.TakeDamage(50);
		}
		if(zombie2!=null){
			zombie2.TakeDamage(50);
		}
		if(zombie4!=null){
			zombie4.TakeDamage(50);
		}
		if(zombie5!=null){
			zombie5.TakeDamage(50);
			
		}
		
   
    }
	if(hitInfo.tag == "Enemy" && gameObject.name=="bulletAK"){
		Enemy zombie = hitInfo.transform.parent.gameObject.GetComponent<Enemy>();
		enemyLevel2 zombie2 = hitInfo.transform.parent.gameObject.GetComponent<enemyLevel2>();
		EnemyLevel3 zombie3 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel3>();
		EnemyLevel4 zombie4 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel4>();
		enemyLevel5 zombie5 = hitInfo.transform.parent.gameObject.GetComponent<enemyLevel5>();
		if(zombie!=null){
			zombie.TakeDamage(10);
			
		}
		if(zombie2!=null){
			zombie2.TakeDamage(10);
			
		}
		if(zombie3!=null){
			zombie3.TakeDamage(10);
			
		}
		if(zombie4!=null){
			zombie4.TakeDamage(10);
			
		}
		if(zombie5!=null){
			zombie5.TakeDamage(10);
			
		}
		
    
    }
	if(hitInfo.tag == "Enemy" && gameObject.name=="bulletSniper"){
		Enemy zombie = hitInfo.transform.parent.gameObject.GetComponent<Enemy>();
		EnemyLevel3 zombie2 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel3>();
		EnemyLevel4 zombie4 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel4>();
		enemyLevel5 zombie5 = hitInfo.transform.parent.gameObject.GetComponent<enemyLevel5>();
		if(zombie!=null){
			zombie.TakeDamage(200);
			
		}
		if(zombie2!=null){
			zombie2.TakeDamage(200);
			
		}
		if(zombie4!=null){
			zombie4.TakeDamage(200);
			
		}
		if(zombie5!=null){
			zombie5.TakeDamage(200);
			
		}
		
     
    }
	if(hitInfo.tag == "Enemy" && gameObject.name=="bulletfreezeGun"){
		Enemy zombie = hitInfo.transform.parent.gameObject.GetComponent<Enemy>();
		EnemyLevel3 zombie2 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel3>();
		EnemyLevel4 zombie4 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel4>();
		enemyLevel5 zombie5 = hitInfo.transform.parent.gameObject.GetComponent<enemyLevel5>();
			if(zombie!=null){
			zombie.TakeDamage(20);
			}
			if(zombie2!=null){
			zombie2.TakeDamage(20);
			}
			if(zombie4!=null){
			zombie4.TakeDamage(20);
			}
			if(zombie5!=null){
			zombie5.TakeDamage(20);
			
		}
		
    }
	if(hitInfo.tag == "Enemy" && gameObject.name=="bulletTurret"){
		Enemy zombie = hitInfo.transform.parent.gameObject.GetComponent<Enemy>();
		EnemyLevel3 zombie2 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel3>();
		EnemyLevel4 zombie4 = hitInfo.transform.parent.gameObject.GetComponent<EnemyLevel4>();
		enemyLevel5 zombie5 = hitInfo.transform.parent.gameObject.GetComponent<enemyLevel5>();
			if(zombie!=null){
			zombie.TakeDamage(10);
			}
			if(zombie2!=null){
			zombie2.TakeDamage(10);
			}
			if(zombie4!=null){
			zombie4.TakeDamage(10);
			}
			if(zombie5!=null){
			zombie5.TakeDamage(10);
			
		}
			
    }
	
	
	
	
}
}
