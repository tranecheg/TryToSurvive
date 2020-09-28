using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class settings2 : MonoBehaviour
{
    public GameObject openNight, mainMusic, GameMusic, deadPlayer, soundSfx, soundLoot;
    void Start()
    {
         if(PlayerPrefs.GetInt("audio")==0){
			openNight.GetComponent<AudioSource>().enabled = true;
			mainMusic.GetComponent<AudioSource>().enabled = true;
			GameMusic.GetComponent<AudioSource>().enabled = true;
			deadPlayer.GetComponent<AudioSource>().enabled = true;
		 }
		 else{
			 openNight.GetComponent<AudioSource>().enabled = false;	
			mainMusic.GetComponent<AudioSource>().enabled = false;	
			GameMusic.GetComponent<AudioSource>().enabled = false;	
			deadPlayer.GetComponent<AudioSource>().enabled = false;	
		 }
		  if(PlayerPrefs.GetInt("sfx")==0){
			soundSfx.GetComponent<AudioSource>().volume = 100f;
			soundLoot.GetComponent<AudioSource>().volume = 100f;
			
		 }
		 else{
			 soundSfx.GetComponent<AudioSource>().volume = 0f;
			 soundLoot.GetComponent<AudioSource>().volume = 0f;
			//soundLoot.GetComponent<AudioSource>().enabled = false;
		 }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("audio")==0){
			openNight.GetComponent<AudioSource>().enabled = true;
			mainMusic.GetComponent<AudioSource>().enabled = true;
			GameMusic.GetComponent<AudioSource>().enabled = true;
			deadPlayer.GetComponent<AudioSource>().enabled = true;
		 }
		 else{
			 openNight.GetComponent<AudioSource>().enabled = false;	
			mainMusic.GetComponent<AudioSource>().enabled = false;	
			GameMusic.GetComponent<AudioSource>().enabled = false;	
			deadPlayer.GetComponent<AudioSource>().enabled = false;	
		 } 
    }
	
}
