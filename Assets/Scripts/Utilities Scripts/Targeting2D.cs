using UnityEngine;
using System.Collections;

public static class Targeting2D {

	public enum SpriteFacing
	{
		Up = 90, Down = 270, Left = 180, Right = 0
	}

	public static Quaternion LookAt2D(Vector3 targetPos, Vector3 sourcePos, SpriteFacing facing) {
		
		// get direction vector 
		Vector3 dir = targetPos - sourcePos;

		// get the angle of the direction vector
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		// subtract 90 to align with sprite's up direction
		angle -= (float)facing;

		// set rotation
		return Quaternion.AngleAxis(angle, Vector3.forward);

	}

}
