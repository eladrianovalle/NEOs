using UnityEngine;
using System.Collections;

public class MoveToPlayer : MonoBehaviour {

	GameObject player;

	Rigidbody2D _rBody;

	[SerializeField]
	float moveSpeed;

	void Awake() 
	{

		_rBody = this.gameObject.GetComponent<Rigidbody2D> ();

	}

	void Start () {
	
		player = GameObject.FindWithTag ("Player");

	}
	
	void Update () 
	{

		Vector3 targetPos = player.transform.position;
		Vector3 currPos = this.transform.position;

		Quaternion newRotation= Targeting2D.LookAt2D (targetPos, currPos, Targeting2D.SpriteFacing.Up);
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, newRotation, 0.1f);
//		 try to smooth out the rotation, maybe by time.deltaTime?

		// direction position is target position minus position
		Vector3 direction = targetPos - currPos;

		Debug.Log ("The direction of the enemy is " + direction);

//		direction = direction.normalized;

//		Debug.Log ("The normalized direction of the enemy is " + direction);

		_rBody.AddForce (direction * moveSpeed);

	}

	void ShootWhenClose() 
	{
		// drag this out to a separate script when possible

		// if enemy.position is onscreen, and distance.x or distance.y > 2f, 
		// do enemy shoot

	}

	void TurnShipForAnotherPass() 
	{
		// if distance between player and enemy < 2f
		// enemy has new target immediately opposite of original target by 10f
		// enemy will fly back around toward new target,
		// when less than 2f from new target,
		// target once again becomes player
		
	}



}
