using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieDie4 : MonoBehaviour
{
    public int countSpawn4;
    void Start()
    {
	countSpawn4 = PlayerPrefs.GetInt("countSpawn4");	
    countSpawn4--;
	PlayerPrefs.SetInt("countSpawn4", countSpawn4);
	PlayerPrefs.Save();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
