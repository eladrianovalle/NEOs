using UnityEngine;
using System.Collections;

public class CameraShakeOnCollision : MonoBehaviour {

	public float shakeDuration, shakeMagnitude;

	public CameraController camControlScript;

	void OnCollisionStay2D(Collision2D collision) 
	{
		// check if collision is with obstacle
		if (collision.gameObject.tag == "Obstacle") 
		{
			// turn off camera controller script
			camControlScript.enabled = false;
			// do camera shake
			StartCoroutine(CameraEffects.Shake (shakeDuration, shakeMagnitude));
			// wait for shake to finish
			StartCoroutine(CoroutineUtilities.WaitForRealTime (shakeDuration));
			// turn camera controller script back on
			camControlScript.enabled = true;


		}

	} // OnCollisionStay2D
		
} // CameraShakeOnCollision
