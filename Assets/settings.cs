using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class settings : MonoBehaviour
{
    public GameObject on, off, inputField, multi;
	public string nick;
    void Start()
    {
        if(PlayerPrefs.GetInt("audio")==0){
		GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = true;
		GameObject.Find("Sound_18041").GetComponent<AudioSource>().enabled = true;		
		}
		else{
		GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = false;
		GameObject.Find("Sound_18041").GetComponent<AudioSource>().enabled = false;
			
		}
		nick = PlayerPrefs.GetString("nickName");
		if(nick==null){
		nick = inputField.GetComponent<InputField>().text;
		}
		else{
		inputField.GetComponent<InputField>().text = nick;
		}
    }

    // Update is called once per frame
    void Update()
    {
				
       if(GameObject.Find("Settings")!=null){
			if(PlayerPrefs.GetInt("audio")==0){
		GameObject.Find("AudioOn").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1);
		GameObject.Find("AudioOff").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,0.3921569f);
		}
		else{
		GameObject.Find("AudioOn").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,0.3921569f);
		GameObject.Find("AudioOff").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1);	
		}
		if(PlayerPrefs.GetInt("sfx")==0){
		GameObject.Find("SFXOn").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1);
		GameObject.Find("SFXOff").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,0.3921569f);
		}
		else{
		GameObject.Find("SFXOn").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,0.3921569f);
		GameObject.Find("SFXOff").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1);	
		}
	   }
	   if(Application.internetReachability == NetworkReachability.NotReachable)
        {
             multi.GetComponent<Button>().interactable = false;
			 multi.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,0.3f);
        }
		else{
			multi.GetComponent<Button>().interactable = true;
			 multi.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1);
		}
	   
    }
	public void audioOff(){
		PlayerPrefs.SetInt("audio", 1);
		GameObject.Find("AudioOn").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,0.3921569f);
		GameObject.Find("AudioOff").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1);
		GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = false;
	}
	public void audioOn(){
		PlayerPrefs.SetInt("audio", 0);
		GameObject.Find("AudioOn").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1);
		GameObject.Find("AudioOff").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,0.3921569f);
			GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = true;
	}
	public void sfxOff(){
		PlayerPrefs.SetInt("sfx", 1);
		GameObject.Find("SFXOn").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,0.3921569f);
		GameObject.Find("SFXOff").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1);
		
	}
	public void  sfxOn(){
		PlayerPrefs.SetInt("sfx", 0);
		GameObject.Find("SFXOn").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,1);
		GameObject.Find("SFXOff").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1,1,1,0.3921569f);
		
	}
	public void ChangeNickName(){
	nick = inputField.GetComponent<InputField>().text;
	PlayerPrefs.SetString("nickName", nick);
	PhotonNetwork.NickName = nick;
	}
	public void OnLeftRoom()
	{
    PhotonNetwork.LoadLevel("Load");
	}
}
