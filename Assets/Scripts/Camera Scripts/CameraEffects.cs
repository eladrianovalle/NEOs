using UnityEngine;
using System.Collections;

public static class CameraEffects {

	public static IEnumerator Shake(float duration, float magnitude, string shakeAxis = default(string)) {
		
		float elapsed = 0.0f;
		
		Vector3 originalCamPos = Camera.main.transform.position;
		
		while (elapsed < duration) {
			
			elapsed += Time.deltaTime;          
			
			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			
			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= magnitude * damper;
			y *= magnitude * damper;

			if (shakeAxis == "vertical") {
				x = 0;
			}
			else if (shakeAxis == "horizontal") {
				y = 0;
			}
				
			Camera.main.transform.position = new Vector3(x + originalCamPos.x, y + originalCamPos.y, originalCamPos.z);

			yield return null;
		}
		
		Camera.main.transform.position = originalCamPos;
	}

} // CameraEffects

// original camera shake code by Michael Guerrero https://plus.google.com/100300984431039598653/posts
// parameters and shakeAxis variable added by me

// look into Mathf.PerlinNoise()