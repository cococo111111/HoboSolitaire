using UnityEngine;
using System.Collections;

public class spacebob : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	transform.position += ( new Vector3(0f, .01f, 0f) * Mathf.Sin (Time.time * .02f)) * Time.deltaTime;
	transform.rotation = Quaternion.Euler( new Vector3(0f, 12f, 0f) * Mathf.Sin (Time.time * .01f));	
		
	}
}
