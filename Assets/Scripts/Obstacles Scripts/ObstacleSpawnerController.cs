using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObstacleSpawnerController : MonoBehaviour {

	[SerializeField]
	Transform objToLookAt;

	[SerializeField]
	List<GameObject> objsToSpawn;

	GameObject objSpawned;

	private bool didSpawn = true;
	
	void Update () 
	{

		if (!this.didSpawn) 
		{
			
			Spawn ();

		}
	}

	void Spawn () 
	{
		
		this.didSpawn = true;

		// grab a random object from objToSpawn list
		objSpawned = objsToSpawn[Random.Range(0, objsToSpawn.Count)];

		GameObject spawn = Instantiate (objSpawned);
		spawn.transform.position = this.gameObject.transform.position;
//		spawn.transform.rotation = Targeting2D.LookAt2D (objToLookAt.position, this.transform.position, Targeting2D.SpriteFacing.Up);

	}

	void ToggleDidSpawn() 
	{
		this.didSpawn = !didSpawn;
	}


}
