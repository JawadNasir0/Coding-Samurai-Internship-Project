using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   public GameObject[] fruits;
   public GameObject bomb;
   public float xBound, yBound;
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

	
	IEnumerator SpawnObjects()
	{
		yield return new WaitForSeconds(Random.Range(1,2));
		
		int randomFruits = Random.Range(0, fruits.Length);
		if(Random.value <= .7f)
			Instantiate(fruits[randomFruits],
			new Vector2(Random.Range(-xBound,xBound),yBound),Quaternion.identity);
		else
			Instantiate(bomb,
			new Vector2(Random.Range(-xBound,xBound),yBound),Quaternion.identity);
			
		StartCoroutine(SpawnObjects());
	}
}
