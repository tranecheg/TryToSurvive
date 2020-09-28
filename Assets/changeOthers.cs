using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeOthers : MonoBehaviour
{
  public int weaponSwitch = 0;
    void Start()
    {
       SelectWeapon();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void SelectWeapon(){
		int i = 0;
		foreach(Transform weapon in transform){
			if(i== weaponSwitch){
				weapon.gameObject.SetActive(true);
			}
			else{
				weapon.gameObject.SetActive(false);
			}
		i++;	
		}
	}
	public void changeWeapon(){
		int currentWeapon = weaponSwitch;
        
			if(weaponSwitch>=transform.childCount - 1){
				weaponSwitch=0;
			}
			else{
			weaponSwitch++;	
			}
			
		
		if(currentWeapon!=weaponSwitch){
			SelectWeapon();
		}
	}
}
