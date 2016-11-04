using UnityEngine;
using System.Collections;

public class ShootOnSpacebar : MonoBehaviour {

	[SerializeField]
	GameObject projectile;

	[SerializeField]
	Transform player;

	[SerializeField]
	ParticleSystem burst;

	[SerializeField]
	float projectileSpeed;

	void Update () 
	{
	
		ShootLaserOnSpacebarPress ();

	}

	void ShootLaserOnSpacebarPress() 
	{
		// Rapid Fire
//		if (Input.GetKey(KeyCode.Space)) 

		// One Shot
		if (Input.GetKeyDown(KeyCode.Space)) 
			
		{
			// play muzzle burst particle system
			burst.Emit(15);

			// shoot a bullet from the player's position
			GameObject projectileClone = Instantiate(projectile);
			Rigidbody2D projectileBody = projectileClone.GetComponent<Rigidbody2D> ();

			projectileClone.transform.position = this.transform.position;
			projectileClone.transform.rotation = this.transform.rotation;
			projectileBody.AddForce (this.transform.up * projectileSpeed);


			StartCoroutine(DramaticPause());


		}
	}

	public IEnumerator DramaticPause() {

		Time.timeScale = 0;

		yield return StartCoroutine(CoroutineUtilities.WaitForRealTime (0.02f));

		Time.timeScale = 1;

	} // DramaticPause

}
