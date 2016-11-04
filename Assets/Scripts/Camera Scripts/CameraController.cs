using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	Transform objToFollow;

	public float dampTime = 0.15f;

	private Vector3 camVelocity = Vector3.zero;



	void FixedUpdate () 
	{
		
		SmoothCameraFollow ();

	}

	void SmoothCameraFollow() 
	{
		if (objToFollow)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(objToFollow.position);
			Vector3 delta = objToFollow.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			this.transform.position = Vector3.SmoothDamp(transform.position, destination, ref camVelocity, dampTime);
		}
	}

}
