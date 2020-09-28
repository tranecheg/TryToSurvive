using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieDie3 : MonoBehaviour
{
    public int countSpawn3;
    void Start()
    {
	countSpawn3 = PlayerPrefs.GetInt("countSpawn3");	
    countSpawn3--;
	PlayerPrefs.SetInt("countSpawn3", countSpawn3);
	PlayerPrefs.Save();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
