using UnityEngine;
using System.Collections;

public class ResistanceToFireBeforeDestroy : MonoBehaviour {

	[SerializeField]
	private int shotResistance;
	private int shotsHit;
	public float destroyDelay, explodeDur, explodeMag;

	public int collisionDamage;

	[SerializeField]
	ParticleSystem explosion;

	public AudioSource audioSrc;
	public AudioClip explosionSFX;

	public GameObject spawnOnDestroy;

	[SerializeField]
	Animator _anim;
	Collider2D _collider;
	Rigidbody2D _rbody;

	private bool didExplode;

	void Awake() 
	{
		shotsHit = 0;
		didExplode = false;
		_collider = this.gameObject.GetComponent<Collider2D> ();
		_rbody = this.gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{

		ShotsHitBeforeDestroy (shotResistance);
	
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.gameObject.tag == "Projectile") 
		{
			shotsHit ++;
		}

		if (collision.gameObject.tag == "Obstacle") 
		{
			if (collision.gameObject.name.Contains ("Large Asteroid"))
				
				collisionDamage = shotResistance / 2; 

			if (collision.gameObject.name.Contains ("Medium Asteroid"))
				
				collisionDamage = shotResistance / 3; 

			if (collision.gameObject.name.Contains ("Small Asteroid"))
				
				collisionDamage = shotResistance / 4; 
					
			shotsHit += collisionDamage;
		}

		Debug.Log ("The shots hit of " + this.gameObject.name + " is " + shotsHit);
		
	}

	void ShotsHitBeforeDestroy(int resistance) 
	{
		if (shotsHit >= resistance) 
		{
			Time.timeScale = 1;
			_collider.enabled = false;

			// freeze rigidbody to spawn in same position it was destroyed
			_rbody.constraints = RigidbodyConstraints2D.FreezeAll;


			if (!didExplode && _collider.enabled == false) 
			{
				// set audio to 2D
				audioSrc.spatialBlend = 0.0f;

				// if object has explosion sfx, play explosion sfx
				if (explosionSFX)
					audioSrc.PlayOneShot (explosionSFX);
				
				// do camera shake on destroy
				StartCoroutine (CameraEffects.Shake (explodeDur, explodeMag));

				// if object has an explosion particle system, emit
				if (explosion)
					explosion.Emit ((int)Random.Range(50,100));
				
				// if object has an object to spawn, spawn it
				if (spawnOnDestroy)
					Spawn (this.transform.position);

				// set bool
				didExplode = true;
			}

			_anim.Play ("Explosion Animation");
			Destroy (this.gameObject, destroyDelay);

			if (this.gameObject.tag == "Player")
				Camera.main.gameObject.AddComponent<AudioListener> ();

		}
		
	}

	void Spawn (Vector3 position) 
	{

		GameObject spawn = Instantiate (spawnOnDestroy);
		spawn.transform.position = position;

	}

}
