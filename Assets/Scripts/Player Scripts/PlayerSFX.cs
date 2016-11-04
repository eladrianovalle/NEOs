using UnityEngine;
using System.Collections;

public class PlayerSFX : MonoBehaviour {

	private Animator _anim;

	public AudioSource shipAudio, blastersAudio;


	public AudioClip shipCollisionSFX, blasterSFX;


	void Awake () {

		_anim = this.gameObject.GetComponent<Animator> ();

	}

	
	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			_anim.SetBool ("ThrustersOn", true);
		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) 
		{
			_anim.SetBool ("ThrustersOn", false);
		}


		if (Input.GetKeyDown(KeyCode.Space)) {
			
			// play firing sound
			blastersAudio.PlayOneShot(blasterSFX);

		}
			
	}

	void OnCollisionEnter2D(Collision2D collision) {

		if (collision.gameObject.tag == "Obstacle") 
		{
			
			shipAudio.PlayOneShot (shipCollisionSFX, 1f);

		}
	}
		
}
