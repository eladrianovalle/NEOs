using UnityEngine;
using System.Collections;

public class EmitBurstParticlesWhenFiring : MonoBehaviour {

	[SerializeField]
	ParticleSystem burst;

	// Use this for initialization
	void Start () {
		
		// play muzzleflash particle system
		ParticleSystem burstClone = Instantiate(burst);
		burstClone.transform.position = this.transform.position;

		Quaternion blastRotation = new Quaternion(90f, 0, 0, 0);
		blastRotation.z = this.transform.rotation.z;
		burstClone.transform.rotation = blastRotation;

	}
		

}
