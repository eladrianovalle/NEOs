using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class ScreenOverlayController : MonoBehaviour {

	public static ScreenOverlayController instance;
	public ScreenOverlay screenOverlayScript;

	private float multiplyModeValue = 6f;
	private float multiplyLightestVal = 6f;
	private float multiplyDarkestVal = 2f;
	private float multiplyInterval = 0.3f;

//	private float overlayModeValue = 0.2f;
//	private float overlayLightestVal = 0.2f;
//	private float overlayDarkestVal = 2f;
//	private float overlayInterval = 0.2f;

	private bool increaseVal = true;

	void Awake() {
		MakeInstance ();
	}

	void Start() {
		screenOverlayScript.blendMode = ScreenOverlay.OverlayBlendMode.Multiply;
		screenOverlayScript.intensity = multiplyModeValue;
	}

	public void AlterCameraEffectForNextRound() {
		// change value of Overlay blend mode
//		if (screenOverlayScript.blendMode == ScreenOverlay.OverlayBlendMode.Overlay) {
//			// Check whether value increases or decreases 
//			if (overlayModeValue == overlayLightestVal) {
//				increaseVal = true;
//			} else if (overlayModeValue == overlayDarkestVal) {
//				increaseVal = false;
//			}
//
//			// increase or decrease value
//			if (increaseVal) {
//				overlayModeValue += overlayInterval;
//			} else {
//				overlayModeValue -= overlayInterval;
//			}
//
//			// assign value to Screen Overlay intensity
//			screenOverlayScript.intensity = overlayModeValue;
//		}

		// change value of multiply blend mode
		if (screenOverlayScript.blendMode == ScreenOverlay.OverlayBlendMode.Multiply) {
			// Check whether value increases or decreases 
			if (multiplyModeValue == multiplyLightestVal) {
				increaseVal = false;
			} else if (multiplyModeValue == multiplyDarkestVal) {
				increaseVal = true;
			}

			// increase or decrease value
			if (increaseVal) {
				multiplyModeValue += multiplyInterval;
			} else {
				multiplyModeValue -= multiplyInterval;
			}

			// assign value to Screen Overlay intensity
			screenOverlayScript.intensity = multiplyModeValue;
		}
	}

//	void ChangeBlendMode() {
//		if (screenOverlayScript.blendMode == ScreenOverlay.OverlayBlendMode.Multiply) {
//
//			screenOverlayScript.blendMode = ScreenOverlay.OverlayBlendMode.Overlay;
//
//		} else {
//
//			screenOverlayScript.blendMode = ScreenOverlay.OverlayBlendMode.Multiply;
//
//		}
//	}

//	void MakeSceneDarker() {
//		if (screenOverlayScript.blendMode == ScreenOverlay.OverlayBlendMode.Multiply) {
//
//			multiplyModeValue += 0.5f;
//			
//		} else if (screenOverlayScript.blendMode == ScreenOverlay.OverlayBlendMode.Overlay) {
//
//			overlayModeValue += 0.2f;
//
//		}
//	}
//
//	void MakeSceneLighter() {
//		if (screenOverlayScript.blendMode == ScreenOverlay.OverlayBlendMode.Multiply) {
//
//			multiplyModeValue -= 0.5f;
//
//		} else if (screenOverlayScript.blendMode == ScreenOverlay.OverlayBlendMode.Overlay) {
//
//			overlayModeValue -= 0.2f;
//
//		}
//	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}
}
