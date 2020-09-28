using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteLoot : MonoBehaviour
{
    private float time = 14f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       time-=Time.deltaTime;
	   transform.Rotate(0, 0, 2*Time.timeScale);
	   if(time<0){
		   Destroy(gameObject);
	   }
    }
	
	private void OnTriggerEnter2D(Collider2D col)
    {
		if(col.tag == "Player"){
		 Destroy(gameObject);
		}
		
        
    }
}
