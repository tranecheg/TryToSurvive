using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class stage : MonoBehaviour
{
    public int stageNum, countSpawn,countSpawn2, countSpawn3, countSpawn4, countSpawn5;
	
	public Text stageText;
	private PhotonView photonView;
    void Start()
    {
		PlayerPrefs.DeleteKey("stage"); 
		PlayerPrefs.DeleteKey("countSpawn"); 
		PlayerPrefs.DeleteKey("countSpawn2");
		PlayerPrefs.DeleteKey("countSpawn3");  
		PlayerPrefs.DeleteKey("countSpawn4");
		PlayerPrefs.DeleteKey("countSpawn5");  

		photonView  = GetComponent<PhotonView>(); 		
    }

    // Update is called once per frame
    void Update()
    {
      countSpawn = PlayerPrefs.GetInt("countSpawn");
	countSpawn2 = PlayerPrefs.GetInt("countSpawn2");
	countSpawn3 = PlayerPrefs.GetInt("countSpawn3");
 	countSpawn4 = PlayerPrefs.GetInt("countSpawn4");
	countSpawn5 = PlayerPrefs.GetInt("countSpawn5"); 
	
	stageText.text = "Night " + PlayerPrefs.GetInt("stage");
		
	  
    }
	public void allStage(){
		photonView.RPC("Stage", RpcTarget.AllBuffered, null);
	}
	[PunRPC]
	public void Stage(){
		stageNum = PlayerPrefs.GetInt("stage");
		countSpawn = PlayerPrefs.GetInt("countSpawn");
		countSpawn2 = PlayerPrefs.GetInt("countSpawn2");
		countSpawn3 = PlayerPrefs.GetInt("countSpawn3");
		countSpawn4 = PlayerPrefs.GetInt("countSpawn4");
		countSpawn5 = PlayerPrefs.GetInt("countSpawn5");  		
		stageNum++;
		PlayerPrefs.SetInt("stage", stageNum);
		
		countSpawn=stageNum*1;
		PlayerPrefs.SetInt("countSpawn", countSpawn);
		if(stageNum>=1){
			countSpawn2 = (stageNum-1)+2;
			PlayerPrefs.SetInt("countSpawn2", countSpawn2);
		}
		if(stageNum>=5){
			countSpawn3 = (stageNum-5)+2;
			PlayerPrefs.SetInt("countSpawn3", countSpawn3);
		}
		if(stageNum>=7){
			countSpawn4 = (stageNum-7)+1;
			PlayerPrefs.SetInt("countSpawn4", countSpawn4);
		}
		if(stageNum>=9){
			countSpawn5 = (stageNum-9)+1;
			PlayerPrefs.SetInt("countSpawn5", countSpawn5);
		}
		PlayerPrefs.Save();
	}
}
