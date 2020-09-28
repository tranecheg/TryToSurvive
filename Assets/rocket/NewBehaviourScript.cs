using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject rocketPref;
	public Transform firePoint;
	private Rigidbody2D rb;
    void Start()
    {
        rb = rocketPref.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	rb = rocketPref.GetComponent<Rigidbody2D>();
        if(Input.GetKeyDown(KeyCode.Space)){
			Instantiate(rocketPref, firePoint.position, Quaternion.identity);
				rb.AddForce(firePoint.up * 20f, ForceMode2D.Impulse);
		}
    }
}
