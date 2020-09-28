using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieDie2 : MonoBehaviour
{
    public int countSpawn2;
    void Start()
    {
	countSpawn2 = PlayerPrefs.GetInt("countSpawn2");	
    countSpawn2--;
	PlayerPrefs.SetInt("countSpawn2", countSpawn2);
	PlayerPrefs.Save();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
