using UnityEngine;
using System.Collections;

public class FollowPlayerPosition : MonoBehaviour {

	[SerializeField]
	Transform objToFollow;

	void Update() 
	{
		if (objToFollow)
			
			FollowObject ();
		
	}

	void FollowObject() 
	{
		//first grab the position of the object to follow
		Vector3 newPos = objToFollow.position; 

		// finally change this position to the position of the objToFollow
		this.transform.position = newPos;
	}

}
