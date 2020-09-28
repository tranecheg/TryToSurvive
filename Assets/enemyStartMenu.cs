using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStartMenu : MonoBehaviour
{
   private Rigidbody2D rb;
	private Vector2 move;
	private GameObject enemy;
	private float time = 0f;
	public int RandX, RandY;
	
	float x, y;
	private float SpawnRadius, speedMove;
	private float StartSpawn = 10f;
    void Start()
    {
         rb = this.GetComponent<Rigidbody2D>();
		 this.transform.position = new Vector2(Random.Range(-16, 16)/2, Random.Range(-8, 8)/2);
		speedMove = 1f;
    }

    // Update is called once per frame
    void Update()
    {
		
        SpawnRadius = StartSpawn;
		//Vector3 direction  = player.position - transform.position;
		time -= Time.deltaTime;
		if(time<0){
		RandX = Random.Range(-16, 16);
		RandY = Random.Range(-8, 8);
		time=Random.Range(15f, 30f);
		}
		else{
	
		}		
		Vector3 rand = new Vector3(RandX,RandY,0);
		
		Vector3 direction  = rand;
		float angle  = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		
		rb.rotation = angle;
		direction.Normalize();
		move = direction;
    }
	void FixedUpdate(){
	
	moveEnemy(move);	
			
				
	}
	private void moveEnemy(Vector2 direction){
	
		rb.MovePosition((Vector2)transform.position + (direction * (speedMove) * Time.deltaTime));
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag==("box")){
		RandX = Random.Range(-16, 16);
		RandY = Random.Range(-8, 8);
		}
		else{
			
		}
	}
}
