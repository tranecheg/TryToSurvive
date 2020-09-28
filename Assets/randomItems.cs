using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomItems : MonoBehaviour
{
	[System.Serializable]
  public class Drop{
	  public string name;
	  public GameObject item;
	  public int dropRarity;
  }
  public List <Drop> lootItems = new List<Drop>();
  public int dropChance;

	public void calculateLoot(){
	int calc_dropChance = Random.Range(0, 100);
	if(calc_dropChance > dropChance){
		return;
	}
	if(calc_dropChance <= dropChance){
		int itemWeight = 0;
		for (int i = 0; i < lootItems.Count; i++){
			itemWeight +=lootItems [i].dropRarity;
		}
		int randomValue = Random.Range(0, itemWeight);
		for (int j = 0; j<lootItems.Count; j++){
			if(randomValue<=lootItems[j].dropRarity){
				Instantiate(lootItems[j].item, transform.position, Quaternion.identity);
				return;
			}
			randomValue-=lootItems[j].dropRarity;
		}
	}
}
	
}
