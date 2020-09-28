using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class enemyChoice : MonoBehaviour
{
    public GameObject[] enemySprites;
	private int rand;
	public GameObject[] enemyPref;
    void Start()
    {
		if(PhotonNetwork.IsMasterClient){
    // gameObject.GetComponent<PhotonView>().RPC("newTest2", RpcTarget.All, null);   
		}
		
    }

    // Update is called once per frame
    void Update()
    {
	//	GameObject choice = enemySprites[rand];
   //     if(choice==null){
	//		Destroy(gameObject);
	//	}
    }
	[PunRPC]
	public void newTest(){
		rand = Random.Range(0, enemySprites.Length); 
		GameObject choice = enemySprites[rand];
		choice.SetActive(true);
		choice.name = gameObject.name + rand;
		choice.transform.GetChild(0).gameObject.name = "target" + Random.Range(0, 100) + Random.Range(0, 100);
	}
	[PunRPC]
	public void newTest2(){
		rand = Random.Range(0, enemyPref.Length); 
		GameObject choice = PhotonNetwork.Instantiate(enemyPref[rand].name, new Vector3(Random.Range(-5f, 5f), Random.Range(5f, -5f)), Quaternion.identity);
		
		choice.name = gameObject.name + rand;
		//choice.transform.GetChild(0).gameObject.name = "target" + Random.Range(0, 100) + Random.Range(0, 100);
	}
}
