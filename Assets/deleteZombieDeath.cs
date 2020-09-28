using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteZombieDeath : MonoBehaviour
{
    private GameObject[] numberDeadZombie;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		numberDeadZombie = GameObject.FindGameObjectsWithTag("DeadZombie");
        if(numberDeadZombie.Length>30){
			Destroy(gameObject);
		}
    }
}
