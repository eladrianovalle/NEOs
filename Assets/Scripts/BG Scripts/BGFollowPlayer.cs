using UnityEngine;
using System.Collections;

public class BGFollowPlayer : MonoBehaviour {

	public float dampTime = 0.15f;

	private Vector3 bgVelocity = Vector3.zero;

	void FixedUpdate () 
	{
		
		BGFollow ();

	}

	void BGFollow() 
	{

		// set point to follow to be the center of the screen
		Vector3 pointToFollow = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2, Screen.height/2, 20f) );

		//set the center of the screen to be the new position constantly
		Vector3 newPos = pointToFollow; 

		// set the transform to the new position
		this.transform.position = Vector3.SmoothDamp (transform.position, newPos, ref bgVelocity, dampTime);

	}
		
}
