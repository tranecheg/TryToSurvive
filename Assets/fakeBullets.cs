using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeBullets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     Destroy(gameObject, 1);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Enemy"){
			Destroy(gameObject);
		}
	}
}
