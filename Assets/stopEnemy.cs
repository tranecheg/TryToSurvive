using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopEnemy : MonoBehaviour
{
   public GameObject enemy;
   private Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(enemy!=null){
	   rb = enemy.GetComponent<Rigidbody2D>();
	   }	   
    }
	void OnTriggerEnter2D(Collider2D col)
    {
		
		if(col.tag == "Enemy"){
			rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			}
    }
	void OnTriggerExit2D(Collider2D col)
    {
		
		if(col.tag == "Enemy"){
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
    }
}
