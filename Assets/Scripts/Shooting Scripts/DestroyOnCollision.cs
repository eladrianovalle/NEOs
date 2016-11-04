using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
		{
			Destroy (this.gameObject);

		}
	}
		

}
