using UnityEngine;
using System.Collections;

public class ObstacleMovementController : MonoBehaviour {

	Rigidbody2D _rbody;

	[SerializeField]
	float speed;


	void Awake () 
	{

		_rbody = this.gameObject.GetComponent<Rigidbody2D> ();
		
	}

	void Start () 
	{
		// set target to center of the camera
		Vector3	target = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2, Screen.height/2, transform.position.z) );

		// set the obstacle's rotation
		Vector3 directionVector = Targeting2D.LookAt2D (target, this.transform.position, Targeting2D.SpriteFacing.Up).eulerAngles;
	
		directionVector.z += Random.Range (-30, 30);

		Debug.Log ("The direction vector for " + this.gameObject.name + " is " + directionVector);

		this.transform.rotation = Quaternion.Euler (directionVector);
	}
	
	void Update () 
	{
		
		// move object
		Vector3 fwd = this.transform.up;
		_rbody.AddForce (fwd * speed);

	}
}
