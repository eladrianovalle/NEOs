using UnityEngine;
using System.Collections;

public class DestroyParentObject : MonoBehaviour {

	public float destroyDelay;

	void Update () {
	
		DestroyIfNoParent ();

	}

	void DestroyIfNoParent() 
	{

		if (this.gameObject.transform.parent == null)
			Destroy (this.gameObject, destroyDelay);

	} // DestroyIfNoParent

} // DestroyParentObject
