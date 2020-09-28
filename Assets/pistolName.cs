using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		if(gameObject.name=="pistol"){
        gameObject.name = "pistol" + gameObject.transform.parent.transform.parent.name;
		}
		if(gameObject.name=="shotgun"){
        gameObject.name = "shotgun" + gameObject.transform.parent.transform.parent.name;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
