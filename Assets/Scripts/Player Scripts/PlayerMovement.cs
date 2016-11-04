using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	Rigidbody2D _rbody;

	[SerializeField]
	ParticleSystem rearThrusters, fwdThrustersL, fwdThrustersR;

	[SerializeField]
	float speed;

	[SerializeField]
	float rotSpeed;

	public float baseDrag;

	void Update () 
	{
		
		if (Input.GetKey(KeyCode.UpArrow)) 
		{
			ResetDrag ();
			Vector3 fwd = this.transform.up;
			_rbody.AddForce (fwd * speed);
			rearThrusters.Emit (3);
		}
			

		if (Input.GetKey(KeyCode.DownArrow)) 
		{
			fwdThrustersL.Emit (1); 
			fwdThrustersR.Emit (1);

			Vector3 fwd = this.transform.up;

			if (_rbody.drag < 3f) 
				_rbody.drag += speed * Time.deltaTime;
			else 
				_rbody.AddForce (fwd * -speed / _rbody.drag);

		}

		if (Input.GetKey(KeyCode.RightArrow)) 
		{
			ResetDrag ();
			_rbody.AddTorque (-rotSpeed);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			ResetDrag ();
			_rbody.AddTorque (rotSpeed);
		} 
			

	}

	void ResetDrag()
	{
		_rbody.drag = baseDrag;
	}
		


}
