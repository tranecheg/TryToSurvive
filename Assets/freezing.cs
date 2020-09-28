using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezing : MonoBehaviour
{
    private float time = 10f;
	private bool freeze;
	private Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(freeze==true){
			time -= Time.deltaTime;
			gameObject.GetComponent<Enemy>().enabled = false;
		rb = gameObject.GetComponent<Rigidbody2D>();
		rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
		gameObject.GetComponent<Animator>().enabled = false;
		
		gameObject.transform.GetChild(5).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3176f,0.6784f,1f,1f);
		gameObject.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3176f,0.6784f,1f,1f);
		gameObject.transform.GetChild(7).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3176f,0.6784f,1f,1f);
		gameObject.transform.GetChild(8).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3176f,0.6784f,1f,1f);
		gameObject.transform.GetChild(9).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3176f,0.6784f,1f,1f);
		gameObject.transform.GetChild(10).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3176f,0.6784f,1f,1f);
		gameObject.transform.GetChild(11).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3176f,0.6784f,1f,1f);
		gameObject.transform.GetChild(12).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3176f,0.6784f,1f,1f);
			if(time<0){
				freeze=false;
				time=10f;
				gameObject.GetComponent<Enemy>().enabled = true;
		rb = gameObject.GetComponent<Rigidbody2D>();
		rb.constraints = RigidbodyConstraints2D.None;
		gameObject.GetComponent<Animator>().enabled = true;
		
		gameObject.transform.GetChild(5).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7529f,0.7529f,0.7529f,1f);
		gameObject.transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7529f,0.7529f,0.7529f,1f);
		gameObject.transform.GetChild(7).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7529f,0.7529f,0.7529f,1f);
		gameObject.transform.GetChild(8).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7529f,0.7529f,0.7529f,1f);
		gameObject.transform.GetChild(9).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7529f,0.7529f,0.7529f,1f);
		gameObject.transform.GetChild(10).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7529f,0.7529f,0.7529f,1f);
		gameObject.transform.GetChild(11).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7529f,0.7529f,0.7529f,1f);
		gameObject.transform.GetChild(12).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7529f,0.7529f,0.7529f,1f);
			}
		}
		
    }
	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.tag==("freeze")){
		freeze=true;
		}
	}
}
