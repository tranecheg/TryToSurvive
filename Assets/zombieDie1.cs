using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieDie1 : MonoBehaviour
{
    public int countSpawn;
    void Start()
    {
	countSpawn = PlayerPrefs.GetInt("countSpawn");	
    countSpawn--;
	PlayerPrefs.SetInt("countSpawn", countSpawn);
	PlayerPrefs.Save();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
