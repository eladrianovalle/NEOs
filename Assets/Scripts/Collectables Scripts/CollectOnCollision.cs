using UnityEngine;
using System.Collections;

public class CollectOnCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player") 
		{
//			Debug.Log ("I hit the player!!!");
			Destroy (this.gameObject);
		}
	}


}
