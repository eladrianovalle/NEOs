using UnityEngine;
using System.Collections;

public class DramaticPauseOnCollision : MonoBehaviour 
{

	public float hitDur, hitMag;

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.gameObject.tag == "Projectile") 
		{
			StartCoroutine (DramaticPause ());
		}


	} // OnCollisionEnter2D

	public IEnumerator DramaticPause() 
	{

		Time.timeScale = 0;

		yield return StartCoroutine(CoroutineUtilities.WaitForRealTime (0.05f));

		Time.timeScale = 1;

		StartCoroutine (CameraEffects.Shake(hitDur, hitMag));


	} // DramaticPause

}
