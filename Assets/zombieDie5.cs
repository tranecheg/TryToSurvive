using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieDie5 : MonoBehaviour
{
    public int countSpawn5;
    void Start()
    {
	countSpawn5 = PlayerPrefs.GetInt("countSpawn5");	
    countSpawn5--;
	PlayerPrefs.SetInt("countSpawn5", countSpawn5);
	PlayerPrefs.Save();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
