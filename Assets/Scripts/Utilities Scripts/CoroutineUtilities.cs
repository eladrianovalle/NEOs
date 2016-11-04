using UnityEngine;
using System.Collections;

public static class CoroutineUtilities 
{

	public static IEnumerator WaitForRealTime (float time) 
	{
		float start = Time.realtimeSinceStartup;

		while (Time.realtimeSinceStartup < start + time) 
		{
			yield return null;
		}

	}
		

}
