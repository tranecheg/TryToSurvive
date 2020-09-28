using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textMoney : MonoBehaviour
{
    public Text money;
	
    void Start()
    {
       money.text = "" + PlayerPrefs.GetInt("money") + "$"; 
    }

    // Update is called once per frame
    void Update()
    {
       money.text = "" + PlayerPrefs.GetInt("money") + "$";  
    }
}
