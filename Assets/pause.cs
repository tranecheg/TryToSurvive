using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject joystick, pauseBtnOn, pauseBtnOff, panel;
	private PhotonView pv;
    void Start()
    {
        pv = gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
			Time.timeScale = 0f;
		}
    }
	public void pauseAllOn(){
		pv.RPC("pauseOn", RpcTarget.All);
	}
	
	[PunRPC]
	public void pauseOn(){
		
		
			Time.timeScale = 0.025f;
			
			AudioListener.pause = true;
			joystick.SetActive(false);
			pauseBtnOff.SetActive(true);
			pauseBtnOn.SetActive(false);
			panel.SetActive(true);
			GameObject.Find("CanvasPlayer").transform.GetChild(0).gameObject.SetActive(false);
			GameObject.Find("CanvasPlayer").transform.GetChild(1).gameObject.SetActive(false);
			GameObject.Find("CanvasPlayer").transform.GetChild(2).gameObject.SetActive(false);
			GameObject.Find("CanvasPlayer").transform.GetChild(3).gameObject.SetActive(false);
			GameObject.Find("CanvasPlayer").transform.GetChild(4).gameObject.SetActive(false);
			GameObject.Find("CanvasPlayer").transform.GetChild(5).gameObject.SetActive(false);
			GameObject.Find("CanvasPlayer").transform.GetChild(6).gameObject.SetActive(false);
			GameObject.Find("CanvasPlayer").transform.GetChild(8).gameObject.SetActive(false);
			GameObject.Find("CanvasPlayer").transform.GetChild(9).gameObject.SetActive(false);
		
			
	}
	public void pauseAllOff(){
		pv.RPC("pauseOff", RpcTarget.All);
	}
	[PunRPC]
	public void pauseOff(){
		
		
			Time.timeScale = 1;
			
			AudioListener.pause = false;
			joystick.SetActive(true);
			pauseBtnOn.SetActive(true);
			pauseBtnOff.SetActive(false);
			panel.SetActive(false);
			GameObject.Find("CanvasPlayer").transform.GetChild(0).gameObject.SetActive(true);
			GameObject.Find("CanvasPlayer").transform.GetChild(1).gameObject.SetActive(true);
			GameObject.Find("CanvasPlayer").transform.GetChild(2).gameObject.SetActive(true);
			GameObject.Find("CanvasPlayer").transform.GetChild(3).gameObject.SetActive(true);
			GameObject.Find("CanvasPlayer").transform.GetChild(4).gameObject.SetActive(true);
			GameObject.Find("CanvasPlayer").transform.GetChild(5).gameObject.SetActive(true);
			GameObject.Find("CanvasPlayer").transform.GetChild(6).gameObject.SetActive(true);
			GameObject.Find("CanvasPlayer").transform.GetChild(8).gameObject.SetActive(true);
			
	}
	
	
}
