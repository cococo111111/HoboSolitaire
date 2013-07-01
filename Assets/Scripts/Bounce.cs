using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShakeThis( Transform objectToShake ){
		StartCoroutine (Shake (objectToShake, .1f, .1f));
	}


	IEnumerator Shake( Transform objectToShake, float shakeIntensity, float shakeDuration) {

		float t = 1f; 												// 1 = full shake intensity, 0 = no shaking
		Vector3 basePosition = objectToShake.localPosition;
		while ( t > 0f ) { 			 								// for every frame
			t -= Time.deltaTime / shakeDuration;  					// shrink t a little
			objectToShake.localPosition = basePosition - (objectToShake.up * shakeIntensity) * t;
			yield return 0;			 								// wait a frame
		}

		objectToShake.localPosition = basePosition ;
	}

}
