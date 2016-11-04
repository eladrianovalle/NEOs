using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnPointController : MonoBehaviour {

	[SerializeField]
	List<Transform> activeSpawnPoints;

	private List<Transform> inactiveSpawnPoints = new List<Transform>();

	Transform activeSpawnPoint;

	public float timeToWait, timeInterval, distanceFromPlayer;

	void Start () 
	{
		PlaceSpawnPoints ();

		InvokeRepeating ("ReadySpawnPoint", timeToWait, timeInterval );

	}

	void Update () {
		
		if (activeSpawnPoints.Count == 0)
			
			ReactivateSpawnPoints ();

	}

	void ReadySpawnPoint() 
	{
			
			int index = Random.Range (0, activeSpawnPoints.Count);

			activeSpawnPoint = activeSpawnPoints [index];

//			Debug.Log ("The active spawn point is " + activeSpawnPoint.gameObject.name + " at " + Time.time); 

		if (activeSpawnPoint) 
		{

			activeSpawnPoint.SendMessage ("ToggleDidSpawn");

			activeSpawnPoints.RemoveAt (index);

			inactiveSpawnPoints.Add (activeSpawnPoint);

			activeSpawnPoint = null;
		}

	}

	void PlaceSpawnPoints() 
	{
		float deg = 0f;
		float rad = distanceFromPlayer;

		foreach (Transform spawnPoint in activeSpawnPoints) 
		{
			spawnPoint.position = GetSpawnPointCoordinates (deg, rad);
			deg += 45f; 
		}
	}

	Vector3 GetSpawnPointCoordinates(float degrees, float radius) 
	{
		float radians = degrees * Mathf.Deg2Rad;
		float x = Mathf.Cos(radians);
		float y = Mathf.Sin(radians);
		Vector3 pos = new Vector3(x, y, 0); 
		pos = pos * radius;
		return pos;
	}

	void ReactivateSpawnPoints() {
			
		foreach (Transform spawnPoint in inactiveSpawnPoints) {
			
			activeSpawnPoints.Add (spawnPoint);
		}

		inactiveSpawnPoints.Clear();

	}
		
}
